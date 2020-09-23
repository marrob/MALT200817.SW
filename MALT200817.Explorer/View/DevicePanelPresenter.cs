
namespace MALT200817.Explorer.View
{

    using MALT200817.Explorer.Client;
    using MALT200817.Explorer.Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Library;
    using MALT200817.Configuration;

    public interface IDevicePresenter
    {
        void Update();
    }

    public class DevicePanelPresenter: IDevicePresenter
    {
        public class DeviceListViewItem
        { 
            public string FirstName { get; set; }
            public string FamilyCode { get; set; }
            public string Address { get; set; }
            public string Version { get; set; }
            public string SerialNumber { get; set; }
            public string OptionCode { get; set; }
        }

        DeviceListViewItem _selected;
        public LiveDeviceCollection _devices;
        public BindingList<DeviceListViewItem> _deviceViewLists;
        DataGridView _deviceDgv;

        public DevicePanelPresenter(DataGridView deviceDgv, LiveDeviceCollection devices)
        {
            _deviceDgv = deviceDgv;
            _devices = devices;
            _deviceViewLists = new BindingList<DeviceListViewItem>();
            
            deviceDgv.DataSource = _deviceViewLists;
            deviceDgv.DoubleClick += DeviceDgv_DoubleClick;
            Update();
        }

        private void DeviceDgv_DoubleClick(object sender, EventArgs e)
        {
            var selected = (_deviceDgv.CurrentRow.DataBoundItem as DeviceListViewItem);
            _selected = (_deviceDgv.CurrentRow.DataBoundItem as DeviceListViewItem);
            ShowDevice();
        }

        public void Update()
        {
            _deviceViewLists.Clear();
            foreach (LiveDeviceItem dev in _devices)
            {
                var firstName = Devices.Instance.Search(dev.FamilyCode, dev.OptionCode).FirstName;
                _deviceViewLists.Add(new DeviceListViewItem()
                {
                    FirstName = firstName,
                    FamilyCode = dev.FamilyCode.ToString("X2"),
                    Address = dev.Address.ToString("X2"),
                    Version = dev.Version,
                    SerialNumber = dev.SerialNumber,
                    OptionCode = dev.OptionCode.ToString("X2")
                }) ;
            }    
        }


        public void ShowDevice()
        {
            var familyCode = Tools.HexaByteStrToInt(_selected.FamilyCode);
            var optionCode = Tools.HexaByteStrToInt(_selected.OptionCode);
            var lib = Devices.Instance.Search(familyCode, optionCode);
            var form = new DeviceForm();
            form.Text = lib.FirstName + ":" + _selected.Address + " " + AppConstants.SoftwareCustomer;
            form.Components = lib.Components;
            form.FamilyCode = familyCode.ToString("X2");
            form.Address = _selected.Address;
            form.OptionCode = optionCode.ToString("X2");
            form.Size = lib.DefaultWinodwSize;
            form.FwVersion = _selected.Version;
            form.SN = _selected.SerialNumber;
            form.FamilyName = lib.FamilyName;
            form.FirstName = lib.FirstName;
            form.LibVersion = lib.LibVersion;
            form.Show();
        }
    }
}
