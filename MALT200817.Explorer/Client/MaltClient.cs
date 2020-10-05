namespace MALT200817.Explorer.Client
{
    using System;
    using System.IO;
    using System.Text;
    using System.Net.Sockets;
    using Common;
    using Events;



    public class MaltClient : IDisposable
    {
        TcpClient _client;
        NetworkStream _networkStream;
        StreamReader _streamReader;

        bool _disposed = false;
        public static MaltClient Instance { get; } = new MaltClient();
        public delegate string WriteReadDelagte(string line);
        public bool IsConnected { get; private set; } = false;

        private MaltClient()
        {
            
        }

        public void Start(string hostname, int port, double connectionTimeoutSec)
        {
            try
            {
                _client = new TcpClient();
                //_client.Connect(hostname, port);
                //_client.SendTimeout = 100000;
                //_client.ReceiveTimeout = 10000;

                var result = _client.BeginConnect(hostname, port, null, null);

                result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(connectionTimeoutSec));
                if (!_client.Connected)
                    throw new Exception("Failed to connect.");

                // we have connected
                _client.EndConnect(result);
                _networkStream = _client.GetStream();
                _streamReader = new StreamReader(_networkStream, Encoding.UTF8);
                IsConnected = true;
                EventAggregator.Instance.Publish(new ConnectionChangedAppEvent(IsConnected));
            }
            catch (Exception ex)
            {
                throw new IOException("MALT200817.Service is not responding to the start request.\r\n" + ex.Message);
            }
        }

        string WriteReadLine(string line)
        {
            try
            {
                if (!IsConnected)
                    throw new ApplicationException("Not connected.");
                string ptMessage = Console.ReadLine();
                byte[] bytes = Encoding.UTF8.GetBytes(line);
                _networkStream.Write(bytes, 0, bytes.Length);
                return _streamReader.ReadLine();
            }
            catch (Exception ex)
            {
                IsConnected = false;
                EventAggregator.Instance.Publish(new ConnectionChangedAppEvent(IsConnected));
                throw ex;
            }
        }
        public void UpdateDevicesInfo()
        {
            var resp = WriteReadLine("UPDATE#DEVICES:INFO");

            if (resp != "OK")
                throw new ApplicationException(resp);
        }
        public LiveDeviceCollection GetDevices()
        {
            var retval = new LiveDeviceCollection();
            var request = "GET#DEVICES";
            var response = WriteReadLine(request);
            if (response[0] == '!')
                throw new ApplicationException("Request: " + request + "\r\n" + "Response: " + response);

            if (response != "NOT FOUND")
            {
                var devs = response.Split(';');
                foreach (string dev in devs)
                {
                    var items = dev.Split(':');

                    retval.Add(new LiveDeviceItem()
                    {
                        FamilyCode = Tools.HexaByteStrToInt(items[0].Substring(1)),
                        Address = Tools.HexaByteStrToInt(items[1]),
                        OptionCode = Tools.HexaByteStrToInt(items[2]),
                        Version = items[3],
                        SerialNumber = items[4],
                        FamilyName = items[5],
                        FirstName = items[6]
                    });
                }
            }
            return retval;
        }

        public bool GetOne(int familyCode, int address,  int port)
        {
            var result = GetOne(familyCode.ToString("X2"), address.ToString("X2"), port);
            return result;
        }
        public bool GetOne(string familyCode, string address, int port)
        {
            var request = "@" + familyCode +  ":" + address + ":" +  "GET#ONE:" + port.ToString("X2");
            var response = WriteReadLine(request);
            if (response[0] == '!')
                throw new ApplicationException("Request: " + request + "\r\n" + "Response: " +  response);
            var result = response.Substring(response.Length - 3);
            if (result == "CLR")
                return false;
            else if (result == "SET")
                return true;
            else
                throw new ApplicationException("Request: " + request + "\r\n" + "Response: " + response);
        }

        public void SetOne(int familyCode, int address, int port, bool state)
        {
            SetOne(familyCode.ToString("X2"), address.ToString("X2"), port, state);
        }

        public void Reset(string familyCode, string address)
        {
            var request = "@" + familyCode + ":" + address + ":" + "RESET";
            var response = WriteReadLine(request);
            if (response != "OK")
                throw new ApplicationException("Request: " + request + "\r\n" + "Response: " + response);
        }

        /// <summary>
        /// 
        /// /// </summary>
        /// <param name="familyCode"></param>
        /// <param name="address"></param>
        /// <param name="port">port0=>K1 </param>
        /// <param name="state"></param>
        public void SetOne(string familyCode, string address, int port, bool state) 
        {
            var request = "@" + familyCode + ":" + address + ":" + (state == true ? "SET#ONE" : "CLR#ONE") + ":" + port.ToString("X2");
            var response = WriteReadLine(request);
            if (response != "OK")
                throw new ApplicationException("Request: " + request + "\r\n" + "Response: " + response);
        }

        public int GetCounter(string familyCode, string address, int port)
        {
           var request = "@" + familyCode + ":" + address + ":GET#COUNTER:" + port.ToString("X2");
           var response = WriteReadLine(request);
            if (response[0] == '!')
                throw new ApplicationException("Request: " + request + "\r\n" + "Response: " + response);
            return Tools.HexaByteStrToInt(response.Split(':')[4]);
        }

        public void SetCounter(string familyCode, string address, int port, int value)
        {
            var request = "@" + familyCode + ":" + address + ":SET#COUNTER:" + port.ToString("X2") + ":" + value.ToString("X4");
            var response = WriteReadLine(request);
            if (response != "OK")
                throw new ApplicationException("Request: " + request + "\r\n" + "Response: " + response);
        }

        public void SaveCounters(string familyCode, string address)
        {
            var request = "@" + familyCode + ":" + address + ":SAVE#COUNTER";
            var response = WriteReadLine(request);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Disconnect()
        {
            Dispose();
        }

        private void Dispose(bool disposing)
        {
            IsConnected = false;
            EventAggregator.Instance.Publish(new ConnectionChangedAppEvent(IsConnected));

            if (_disposed)
                return;
            if (disposing)
            {

                if (_client != null && _client.Connected)
                {
                    _client.Close();
                }
            }
            _disposed = true;
        }
    }
}
