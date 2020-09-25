namespace MALT200817.Service
{
    using System;
    using System.Text;
    using System.Threading;
    using System.Net;
    using System.Net.Sockets;
    using System.ComponentModel;
    using Common;
    using Configuration;

    class TcpService : IDisposable
    {

        public int ClientsCount {  get; private set; }

        readonly BackgroundWorker _bw;
        readonly TcpListener _server;
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
            _server = new TcpListener(IPAddress.Any, AppConfiguration.Instance.ServicePort);
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

            while (true)
            {
                TcpClient client = _server.AcceptTcpClient();
                new Thread(() => HandleClient(client)).Start();
                ClientsCount++;
                Console.WriteLine("Enter New client");
                AppLog.Instance.WriteLine("Welcome:" + " New Client! Clients count is:" + ClientsCount.ToString());

                if (_bw.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }

            }
        }

        public void HandleClient(TcpClient client)
        {
            while (client.Connected)
            {
                try
                {
                    NetworkStream ns = client.GetStream();
                    byte[] msg = new byte[1024];
                    ns.Read(msg, 0, msg.Length);
                    var cmd = Encoding.Default.GetString(msg).Trim('\0');

                    if (cmd.Length != 0)
                    {
                        string response = "Empty\r\n";
                        if (ParserCallback != null)
                        {
                            //AppLog.Instance.WriteLine("Service Request:" + cmd);
                            response = ParserCallback(cmd);
                            //AppLog.Instance.WriteLine("Service Response:" + response);
                            var array = Encoding.Default.GetBytes(response + "\r\n");
                            ns.Write(array, 0, array.Length);
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    AppLog.Instance.WriteLine(ex.Message);
                }
            }
            Console.WriteLine("Goodbye client");
            AppLog.Instance.WriteLine("Goodbye:" + ".Clients count is:" + ClientsCount.ToString());
            ClientsCount--;
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
