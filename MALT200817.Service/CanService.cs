namespace MALT200817.Service
{
    using System;
    using System.Text;
    using System.Threading;
    using System.Net;
    using System.Net.Sockets;
    using System.ComponentModel;
    using Common;
    using Devices;
    using System.Diagnostics;
    using System.Reflection;

    public class CanService : IDisposable
    {
        ICanInterface _itf;
        IExplorer _explorer;

        private AutoResetEvent _readyToDisposeEvent;

        bool _disposed = false;
        BackgroundWorker _bw;
        readonly AutoResetEvent _waitForDoneEvent;

        public CanService(ICanInterface itf, IExplorer explorer)
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

            AppLog.Instance.WriteLine(GetType().Namespace + "." +
                GetType().Name + "." +
                MethodBase.GetCurrentMethod().Name +
                "Resource Freeing");

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

            AppLog.Instance.WriteLine(GetType().Namespace + "." +
            GetType().Name + "." +
            MethodBase.GetCurrentMethod().Name +
            "Dispose Complete");
        }
    }
}
