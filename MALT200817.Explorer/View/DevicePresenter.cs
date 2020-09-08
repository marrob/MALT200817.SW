
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

    public class DevicePresenter
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


        public DeviceCollection _devices;
        public BindingList<DeviceListViewItem> _deviceViewLists;
        DataGridView _deviceDgv;

        public DevicePresenter(DataGridView deviceDgv, DeviceCollection devices)
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
            var selcted = (_deviceDgv.CurrentRow.DataBoundItem as DeviceListViewItem);
            var familyCode = Tools.HexaByteStrToInt(selcted.FamilyCode);  
            var address = Tools.HexaByteStrToInt(selcted.Address);
            var option = Tools.HexaByteStrToInt(selcted.OptionCode);
            ShowDevice(familyCode, address, option);
        }

        public void Update()
        {
            _deviceViewLists.Clear();
            foreach (DeviceItem dev in _devices)
            {
                var firstName = Library.Descriptors.Search(dev.FamilyCode, dev.OptionCode).FirstName;
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


        public void ShowDevice(int familyCode, int address, int optionCode)
        {
            var descriptor = Library.Descriptors.Search(familyCode, optionCode);
            var form = new DeviceForm();
            form.Components = descriptor.Components;
            form.FamilyCode = familyCode.ToString("X2");
            form.Address = address.ToString("X2");
            form.OptionCode = optionCode.ToString("X2");
            form.Show();
        }
    }
}
