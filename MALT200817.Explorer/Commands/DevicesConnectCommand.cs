
namespace MALT200817.Explorer.Commands
{
    using MALT200817.Explorer.Client;
    using System;
    using System.Windows.Forms;
    using View;
    using Configuration;

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
                MaltClient.Instance.Disconnect();
            }
            else
            {
                MaltClient.Instance.Start(AppConfiguration.Instance.ServiceIPAddress,
                                          AppConfiguration.Instance.ServicePort,
                                          AppConfiguration.Instance.ClientConnectionTimoutSec);
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
