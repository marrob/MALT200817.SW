namespace MALT200817.Explorer.Client
{
    using System;
    using System.IO;
    using System.Text;
    using System.Net.Sockets;
    using Common;


    public class MaltClient : IDisposable
    {
        TcpClient _client;
        NetworkStream _networkStream;
        StreamReader _streamReader;

        bool _disposed = false;

        public static MaltClient Instance { get; } = new MaltClient();

        public delegate string WriteReadDelagte(string line);
        public WriteReadDelagte WriteReadFnPtr;

        public bool IsConnected { get; private set; } = false;
        public Exception LastException { get; private set; } = null;

        private MaltClient()
        {
            
        }

        public void Start(string hostname, int port)
        {
            try
            {
                _client = new TcpClient();
                _client.Connect(hostname, port);
                _networkStream = _client.GetStream();
                _networkStream.ReadTimeout = 2000;
                _streamReader = new StreamReader(_networkStream, Encoding.UTF8);
                WriteReadFnPtr = WriteReadLine;
                IsConnected = true;
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
                string ptMessage = Console.ReadLine();
                byte[] bytes = Encoding.UTF8.GetBytes(line);
                _networkStream.Write(bytes, 0, bytes.Length);
                return _streamReader.ReadLine();
            }
            catch (Exception ex)
            {
                if (LastException != null)
                    LastException = ex;
                throw ex;
            }
        }
        public void UpdateDevicesInfo()
        {
            var resp = WriteReadFnPtr("DO#UPDATE:DEVICES:INFO");

            if (resp != "OK")
                throw new ApplicationException(resp);
        }
        public LiveDeviceCollection GetDevices()
        {
            var retval = new LiveDeviceCollection();
            var response = WriteReadFnPtr("GET#DEVICES");

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
                        FirstName = items[5]

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
            var response = WriteReadFnPtr(request);
            if (response[0] == '!')
            {
                throw new ApplicationException("Request: " + request + "\r\n" + "Response: " +  response);
            }
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
            var response = WriteReadFnPtr(request);
            if (response != "OK")
            {
                throw new ApplicationException("Request: " + request + "\r\n" + "Response: " + response);
            }
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
            var response = WriteReadFnPtr(request);
            if (response != "OK")
                throw new ApplicationException("Request: " + request + "\r\n" + "Response: " + response);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            IsConnected = false;

            if (_disposed)
                return;


            if (disposing)
            {
                
                if (_client != null && _client.Connected)
                    _client.Close();
            }
            _disposed = true;
        }
    }
}
