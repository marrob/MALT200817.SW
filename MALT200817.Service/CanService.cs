namespace MALT200817.Service
{
    using System;
    using System.Text;
    using System.Threading;
    using System.Net;
    using System.Net.Sockets;
    using System.ComponentModel;
    using Common;
    using System.Diagnostics;
    using System.Reflection;

    public class CanService : IDisposable
    {
        readonly ICanInterface _itf;
        readonly Explorer _explorer;
        private readonly AutoResetEvent _readyToDisposeEvent;
        bool _disposed = false;
        readonly BackgroundWorker _bw;
        private readonly AutoResetEvent _waitForDoneEvent;

        public CanService(ICanInterface itf, Explorer explorer)
        {
            _explorer = explorer;
            _itf = itf; 
            _bw = new BackgroundWorker();
            _waitForDoneEvent = new AutoResetEvent(false);
            _readyToDisposeEvent = new AutoResetEvent(false);
            _bw.DoWork += DoWork;
        }

        public event RunWorkerCompletedEventHandler Completed
        {
            remove { _bw.RunWorkerCompleted -= value; }
            add { _bw.RunWorkerCompleted += value; }
        }

        public void Begin(object argument)
        {
            _bw.WorkerReportsProgress = true;
            _bw.WorkerSupportsCancellation = true;
            _bw.RunWorkerAsync(argument);
        }

        private void DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {

                var framesIn =  _itf.ReadFrame();
                foreach (CanMsg msg in framesIn) 
                _explorer.FramesIn(msg);

                if (_explorer.TxQueue.Count != 0)
                {
                    var msg = _explorer.TxQueue.Dequeue();
                    _itf.WriteFrame(new CanMsg[] { msg });
                }


                if (_bw.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }

               // Thread.Sleep(1);

            }

            #region Resource Freeing
            AppLog.Instance.WriteLine("CanService:DoWork:Resource Free");
            _itf.Dispose();
            _readyToDisposeEvent.Set();
            #endregion
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            AppLog.Instance.WriteLine("CanService:Dispose Begin");
            if (_disposed)
                return;

            if (disposing)
            {        

                if (_bw.IsBusy)
                {
                    _bw.CancelAsync();
                    _readyToDisposeEvent.WaitOne();
                    
                }
            }
            _disposed = true;
            AppLog.Instance.WriteLine("CanService:Dispose Complete");
        }
    }
}
