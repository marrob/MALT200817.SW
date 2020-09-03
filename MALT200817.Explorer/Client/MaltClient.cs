namespace MALT200817.Explorer.Client
{
    using System;
    using System.IO;
    using System.Text;
    using System.Net.Sockets;
    using System.Collections.Generic;
    using System.Runtime.Remoting.Messaging;

    public class MaltClient : IDisposable
    {
        TcpClient _client = new TcpClient();
        NetworkStream _networkStream;
        StreamReader _streamReader;

        bool _disposed = false;

        //public static MaltTcpClient Instance { get; } = new MaltTcpClient();

        public delegate string WriteReadDelagte(string line);
        public WriteReadDelagte WriteReadFnPtr;

        public MaltClient()
        {
            
        }

        public void Start(string hostname, int port)
        { 
            _client.Connect("", 9999);
            _networkStream = _client.GetStream();
            _networkStream.ReadTimeout = 2000;
            _streamReader = new StreamReader(_networkStream, Encoding.UTF8);
            WriteReadFnPtr = WriteReadLine;


        }

        string WriteReadLine(string line)
        {
            string ptMessage = Console.ReadLine();
            byte[] bytes = Encoding.UTF8.GetBytes(line);
            _networkStream.Write(bytes, 0, bytes.Length);
            return _streamReader.ReadLine();
        }

        public DeviceCollection GetDevices()
        {
            var retval = new DeviceCollection();
            var response = WriteReadFnPtr("GET#DEVICES");
            var devs = response.Split(';');
            foreach (string dev in devs)
            {
                var items = dev.Split(':');

                retval.Add(new DeviceItem("",cardType: items[5] + "-" + items[0],
                                            address: items[1],
                                            version: items[3],
                                            serialNumber: items[4]));

            }
            return retval ;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
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
