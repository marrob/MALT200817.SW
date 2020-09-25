
namespace MALT200817.Explorer.View
{

    using Client;
    using Common;
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
    using Configuration;

    public interface IDevicePresenter
    {
        void Update(LiveDeviceCollection devices);
    }

    public class DevicePresenter: IDevicePresenter
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

        public DevicePresenter(DataGridView deviceDgv)
        {
            _deviceDgv = deviceDgv;
            _deviceViewLists = new BindingList<DeviceListViewItem>();
            deviceDgv.DataSource = _deviceViewLists;
            deviceDgv.DoubleClick += DeviceDgv_DoubleClick;
        }

        private void DeviceDgv_DoubleClick(object sender, EventArgs e)
        {
            _selected = (_deviceDgv.CurrentRow.DataBoundItem as DeviceListViewItem);
            ShowDevice();
        }

        public void Update(LiveDeviceCollection devices)
        {
            _deviceViewLists.Clear();
            foreach (LiveDeviceItem dev in devices)
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
            var dev = new DeviceFormNextGen();
            dev.Address = _selected.Address;
            dev.FamilyCode = _selected.FamilyCode;
            dev.OptionCode = _selected.OptionCode;
            dev.SerialNumber = _selected.SerialNumber;
            dev.Show();
        }
    }
}
