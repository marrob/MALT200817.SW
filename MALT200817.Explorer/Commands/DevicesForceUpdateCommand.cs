
namespace MALT200817.Explorer.Commands
{
    using MALT200817.Explorer.Client;
    using System;
    using System.Windows.Forms;
    using View;
    using Properties;

    class DevicesForceUpdateCommand : ToolStripButton
    {
        readonly IApp _app;
        public DevicesForceUpdateCommand(IApp app)
        {
            _app = app;
            DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            Image = Resources.refresh32;
            Text = "Devices Force Upate";
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            _app.UpdateDeviceList();
        }
    }
}
