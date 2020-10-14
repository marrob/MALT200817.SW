
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

        DeviceListViewItem SelectedItem;
        public LiveDeviceCollection LiveDevices;
        public BindingList<DeviceListViewItem> DevicesListView;
        DataGridView Dgv;

        public DevicePresenter(DataGridView dgv)
        {

            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            Dgv = dgv;
            DevicesListView = new BindingList<DeviceListViewItem>();
            dgv.DataSource = DevicesListView;
            dgv.DoubleClick += DeviceDgv_DoubleClick;
        }

        private void DeviceDgv_DoubleClick(object sender, EventArgs e)
        {
            SelectedItem = (Dgv.CurrentRow.DataBoundItem as DeviceListViewItem);
            ShowDevice();
        }

        int saveRow = 0;
        int SelectedRowIndex = 0;
        public void Update(LiveDeviceCollection devices)
        {
            if (Dgv.Rows.Count > 0 && Dgv.FirstDisplayedCell != null)
                saveRow = Dgv.FirstDisplayedCell.RowIndex;

            if (Dgv.SelectedRows.Count > 0) 
                SelectedRowIndex = Dgv.SelectedRows[0].Index; 

            DevicesListView.Clear();
          
            foreach (LiveDeviceItem dev in devices)
            {
                DevicesListView.Add(new DeviceListViewItem()
                {
                    FirstName = dev.FirstName,
                    FamilyCode = dev.FamilyCode.ToString("X2"),
                    FamilyName = dev.FamilyName,
                    Address = dev.Address.ToString("X2"),
                    Version = dev.Version,
                    SerialNumber = dev.SerialNumber,
                    OptionCode = dev.OptionCode.ToString("X2")
                }); 
            }

            if (saveRow != 0 && saveRow < Dgv.Rows.Count)
                Dgv.FirstDisplayedScrollingRowIndex = saveRow;

            if ((Dgv.Rows.Count - 1) >= SelectedRowIndex) 
                Dgv.Rows[SelectedRowIndex].Selected = true;
        }

        public void ShowDevice()
        {
            var dev = new DeviceForm();
            dev.Address = SelectedItem.Address;
            dev.FamilyCode = SelectedItem.FamilyCode;
            dev.FamilyName = SelectedItem.FamilyName;
            dev.OptionCode = SelectedItem.OptionCode;
            dev.SerialNumber = SelectedItem.SerialNumber;
            dev.FwVersion = SelectedItem.Version;
            dev.Show();
        }
    }
}
