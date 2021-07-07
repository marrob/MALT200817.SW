
namespace MALT200817.Explorer.View
{
    using Client;
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;

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
            public string FamilyName { get; set; }
            public string Address { get; set; }
            public string Version { get; set; }
            public string SerialNumber { get; set; }
            public string OptionCode { get; set; }
        }

        
        public LiveDeviceCollection LiveDevices;
        public BindingList<DeviceListViewItem> DevicesListView;
        DataGridView _dgv;
        DeviceListViewItem _selectedItem;

        public DevicePresenter(DataGridView dgv)
        {

            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            _dgv = dgv;
            DevicesListView = new BindingList<DeviceListViewItem>();
            dgv.DataSource = DevicesListView;
            dgv.DoubleClick += DeviceDgv_DoubleClick;
        }

        private void DeviceDgv_DoubleClick(object sender, EventArgs e)
        {
            _selectedItem = (_dgv.CurrentRow.DataBoundItem as DeviceListViewItem);
            if (!(_selectedItem.FamilyName.Contains("Error")))
            {
                ShowDevice();
            }
        }

        int saveRow = 0;
        int SelectedRowIndex = 0;
        public void Update(LiveDeviceCollection devices)
        {
            if (_dgv.Rows.Count > 0 && _dgv.FirstDisplayedCell != null)
                saveRow = _dgv.FirstDisplayedCell.RowIndex;

            if (_dgv.SelectedRows.Count > 0) 
                SelectedRowIndex = _dgv.SelectedRows[0].Index; 

            DevicesListView.Clear();
          
            foreach (LiveDeviceItem dev in devices)
            {
                DevicesListView.Add(new DeviceListViewItem()
                {
                    FirstName = dev.OptionName,
                    FamilyCode = dev.FamilyCode.ToString("X2"),
                    FamilyName = dev.FamilyName,
                    Address = dev.Address.ToString("X2"),
                    Version = dev.Version,
                    SerialNumber = dev.SerialNumber,
                    OptionCode = dev.OptionCode.ToString("X2")
                }); 
            }

            if (saveRow != 0 && saveRow < _dgv.Rows.Count)
                _dgv.FirstDisplayedScrollingRowIndex = saveRow;

            if ((_dgv.Rows.Count - 1) >= SelectedRowIndex) 
                _dgv.Rows[SelectedRowIndex].Selected = true;
        }

        public void ShowDevice()
        {
            var dev = new DeviceForm();
            dev.Address = _selectedItem.Address;
            dev.FamilyCode = _selectedItem.FamilyCode;
            dev.FamilyName = _selectedItem.FamilyName;
            dev.OptionCode = _selectedItem.OptionCode;
            dev.SerialNumber = _selectedItem.SerialNumber;
            dev.FwVersion = _selectedItem.Version;
            dev.Show();
        }
    }
}
