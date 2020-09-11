
namespace MALT200817.Explorer.Commands
{
    using MALT200817.Explorer.Client;
    using System;
    using System.Windows.Forms;
    using View;

    class DevicesForceUpdateCommand : ToolStripButton
    {
        IDevicePresenter _devicePresenter;
        public DevicesForceUpdateCommand(IDevicePresenter devicePresenter)
        {
            _devicePresenter = devicePresenter;
            //    Image = Resources.Delete32x32;
            DisplayStyle = ToolStripItemDisplayStyle.Text;
            //    Size = new System.Drawing.Size(50, 50);
            Text = "Devices Force Upate";
            //   _diagnosticsView = diagnosticsView;
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            MaltClient.Instance.UpdateDevicesInfo();
            _devicePresenter.Update();
        }
    }
}
