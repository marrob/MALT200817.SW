
namespace MALT200817.Explorer.Commands
{
    using MALT200817.Explorer.Client;
    using System;
    using System.Windows.Forms;
    using View;
    using Configuration;
    using Properties;

    class DevicesConnectCommand : ToolStripButton
    {
        IApp _app;
        public DevicesConnectCommand(IApp app)
        {
            _app = app;
            DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            if (MaltClient.Instance.IsConnected)
            {
                Text = "Disconnect";
                Image = Resources.disconnect32;
            }
            else
            {
                Text = "Connecting";
                Image = Resources.connect32;
            }
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
