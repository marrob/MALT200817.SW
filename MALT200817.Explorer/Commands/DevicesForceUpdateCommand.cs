
namespace MALT200817.Explorer.Commands
{
    using MALT200817.Explorer.Client;
    using System;
    using System.Windows.Forms;
    using View;

    class DevicesForceUpdateCommand : ToolStripButton
    {
        IApp _app;
        public DevicesForceUpdateCommand(IApp app)
        {
            _app = app;
            //    Image = Resources.Delete32x32;
            DisplayStyle = ToolStripItemDisplayStyle.Text;
            //    Size = new System.Drawing.Size(50, 50);
            Text = "Devices Force Upate";
            //   _diagnosticsView = diagnosticsView;
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            _app.UpdateDeviceList();
        }
    }
}
