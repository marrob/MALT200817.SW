﻿namespace MALT200817.Explorer
{
    using System;
    using System.IO;
    using System.Text;
    using System.Net.Sockets;
    using System.Collections.Generic;

    public class MaltTcpClient : IDisposable
    {
        TcpClient _client = new TcpClient();
        NetworkStream _networkStream;
        StreamReader _streamReader;

        bool _disposed = false;

        //public static MaltTcpClient Instance { get; } = new MaltTcpClient();

        public MaltTcpClient()
        {

        }

        public void Start(string hostname, int port)
        { 
            _client.Connect("", 9999);
            _networkStream = _client.GetStream();
            _networkStream.ReadTimeout = 2000;
            _streamReader = new StreamReader(_networkStream, Encoding.UTF8);
        }

        string WriteReadLine(string line)
        {
            string ptMessage = Console.ReadLine();
            byte[] bytes = Encoding.UTF8.GetBytes(line);
            _networkStream.Write(bytes, 0, bytes.Length);
            return _streamReader.ReadLine();
        }

        public List<string> GetDevices()
        {
            var response = WriteReadLine("GET#DEVICES");
            Console.WriteLine(response);
            return null;
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
