
namespace MALT200817.Explorer.Commands
{
    using MALT200817.Explorer.Client;
    using System;
    using System.Windows.Forms;
    using View;

    class DevicesConnectCommand : ToolStripButton
    {
        IApp _app;
        public DevicesConnectCommand(IApp app)
        {
            _app = app;
            //    Image = Resources.Delete32x32;
            DisplayStyle = ToolStripItemDisplayStyle.Text;
            //    Size = new System.Drawing.Size(50, 50);
            if (MaltClient.Instance.IsConnected)
            {
                Text = "Disconnect";
            }
            else
            {
                Text = "Connecting";
            }
            //   _diagnosticsView = diagnosticsView;
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if (MaltClient.Instance.IsConnected)
            {
                _app.Disconnect();
            }
            else
            {
                _app.Connect();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (MaltClient.Instance.IsConnected)
            {
                Text = "Disconnect";
            }
            else
            {
                Text = "Connecting";
            }
            base.OnPaint(e);
        }

        protected override void OnLayout(LayoutEventArgs e)
        {
            if (MaltClient.Instance.IsConnected)
            {
                Text = "Disconnect";
            }
            else
            {
                Text = "Connecting";
            }

            base.OnLayout(e);
        }

    }
}
