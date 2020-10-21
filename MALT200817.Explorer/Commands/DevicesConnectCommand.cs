
namespace MALT200817.Explorer.Commands
{
    using MALT200817.Explorer.Client;
    using System;
    using System.Windows.Forms;
    using View;
    using Configuration;
    using Properties;
    using Events;

    internal class DevicesConnectCommand : ToolStripButton
    {
        private readonly IApp _app;
        public DevicesConnectCommand(IApp app)
        {
            _app = app;
            DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            if (MaltClient.Instance.IsConnected)
            {
                Text = "Press to disconnect";
                Image = Resources.netconnect32;
            }
            else
            {
                Text = "Press to connect";
                Image = Resources.Stop_Normal_Red32;
            }

            EventAggregator.Instance.Subscribe((Action<ConnectionChangedAppEvent>)
            (e => {

                if (e.IsConnected )
                {
                    Text = "Press to disconnect";  
                    Image = Resources.netconnect32;
                }
                else
                {
                    Text = "Press to connect";
                   Image = Resources.Stop_Normal_Red32;
                }
            }));
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
                                          AppConfiguration.Instance.ClientConnectionTimoutMs);
            }
        }
    }
}
