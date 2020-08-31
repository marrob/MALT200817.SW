namespace MALT200817.Service
{
    using System;
    using System.Text;
    using System.Threading;
    using System.Net;
    using System.Net.Sockets;
    using System.ComponentModel;
    using MALT200817.Service.Common;

    class TcpService : IDisposable
    {
        BackgroundWorker _bw;
        TcpListener _server;
        readonly AutoResetEvent _waitForDoneEvent;
        bool _disposed = false;

        public delegate string ParserDelegate(string attribute);

        public Func<string, string> ParserCallback;

        public event RunWorkerCompletedEventHandler Completed
        {
            remove { _bw.RunWorkerCompleted -= value; }
            add { _bw.RunWorkerCompleted += value; }
        }

        public TcpService()
        {
            _bw = new BackgroundWorker();
            _server = new TcpListener(IPAddress.Any, 9999);
            _waitForDoneEvent = new AutoResetEvent(false);
            _bw.DoWork += DoWork;

        }

        public void Begin(object argument)
        {
            _bw.WorkerReportsProgress = true;
            _bw.WorkerSupportsCancellation = true;
            _server.Start();
            _bw.RunWorkerAsync(argument);
        }

        private void DoWork(object sender, DoWorkEventArgs e)
        {
            int i = 0;
            double d = 0;

            while (true)
            {
                TcpClient client = _server.AcceptTcpClient();
                NetworkStream ns = client.GetStream();

                while (client.Connected)
                {
                    try
                    {
                        byte[] msg = new byte[1024];
                        ns.Read(msg, 0, msg.Length);
                        var cmd = Encoding.Default.GetString(msg).Trim('\0');

                        if (cmd.Length == 0)
                            break;

                        string response = "Empty\r\n";
                        if (ParserCallback != null)
                        {
                            response = ParserCallback(cmd);
                            var array = Encoding.Default.GetBytes(response + "\r\n");
                            ns.Write(array, 0, array.Length);
                        }

                        if (_bw.CancellationPending)
                        {
                            e.Cancel = true;
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        AppLog.Instance.WirteLine(ex.Message);

                    }
                }

                if (_bw.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }

            }
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
                _server.Stop();

                if (_bw.IsBusy)
                {
                    _bw.CancelAsync();
                    _waitForDoneEvent.WaitOne();
                }

            }
            _disposed = true;
        }
    }
}
