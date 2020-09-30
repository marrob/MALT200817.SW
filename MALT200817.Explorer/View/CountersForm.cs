﻿namespace MALT200817.Explorer.View
{
    using MALT200817.Library;
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    using System.Diagnostics;

    public partial class CountersForm : Form
    {

    public class CounterItem
    {
        public string Label { get; set; }
        public int Port { get; set; }
        public string Value { get; set; }
    }
       public BindingList<CounterItem> CountersView { get; set; }

        public string Address
        {
            get { return toolStripStatusLabelAddress.Text; }
            set { toolStripStatusLabelAddress.Text = value; }
        }

        public string FamilyCode
        {
            get { return toolStripStatusLabelFamilyCode.Text; }
            set { toolStripStatusLabelFamilyCode.Text = value; }
        }

        public string OptionCode
        {
            get { return toolStripStatusLabelOptionCode.Text; }
            set { toolStripStatusLabelOptionCode.Text = value; }
        }
        DeviceItem _deviceItem;

        public CountersForm()
        {
            InitializeComponent();
            knvDataGridView1.AutoGenerateColumns = false;
            CountersView = new BindingList<CounterItem>();
            knvDataGridView1.DataSource = CountersView;
        }
        private void CountersForm_Load(object sender, EventArgs e)
        {
            _deviceItem = Devices.Library.Search(FamilyCode, OptionCode);
            toolStripStatusLabelVersion.Text = Application.ProductVersion;
            Text = _deviceItem.FirstName + "-" + Address + " Counters";
            foreach (IComponentItem comp in _deviceItem.Components)
            {
                CountersView.Add(new CounterItem()
                {
                    Label = comp.Label,
                    Port = comp.Port,
                    Value = "?"
                });
            }

            ReadUpdate();
        }

        public void ReadUpdate()
        {
            var sw = new Stopwatch();
            sw.Start();


            foreach (CounterItem item in CountersView)
            {
                item.Value = Client.MaltClient.Instance.GetCounter(FamilyCode, Address, item.Port).ToString();
            }
            sw.Stop();
            toolStripStatusLabelUpdateTime.Text = sw.ElapsedMilliseconds.ToString() + "ms";
        }

        private void UpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReadUpdate();
        }
    }
}
