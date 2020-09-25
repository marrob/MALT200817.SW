

namespace MALT200817.Explorer.ErrorHandling
{ 
    using System;
    using System.Windows.Forms;

    public interface IErrorHandlingProgressDialog
    {
        event EventHandler UserCanceled;
        string Comment { get; set; }
        bool AllowCancel { get; set; }

        void Show();
        void Start();
        void End();
    }

    /// <summary>
    /// 
    /// </summary>
    public partial class ErrorHandlingProgressDialog : Form, IErrorHandlingProgressDialog
    {
        public event EventHandler UserCanceled;

        public string Comment
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }

        public bool AllowCancel { get; set; }

        public ErrorHandlingProgressDialog()
        {
            InitializeComponent();
        }


        public void Start()
        {
            progressBar1.Style = ProgressBarStyle.Marquee;
        }

        public void End()
        {
            Timer windowHoldTimer = new Timer();
            windowHoldTimer.Interval = 1000;
            windowHoldTimer.Start();
            windowHoldTimer.Tick += (s, e) =>
                {
                    windowHoldTimer.Stop();
                    this.Close();
                };
        }

        private void ProgressDialog_Shown(object sender, EventArgs e)
        {
            buttonCancel.Visible = AllowCancel;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (UserCanceled != null)
                UserCanceled(this, EventArgs.Empty);
        }
    }
}
