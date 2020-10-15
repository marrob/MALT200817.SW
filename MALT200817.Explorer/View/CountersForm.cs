namespace MALT200817.Explorer.View
{
    using MALT200817.Library;
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    using System.Diagnostics;
    using Client;
    using Events;
    using Configuration;
    using MALT200817.Explorer.Common;
    using System.Security.Cryptography.X509Certificates;

    public partial class CountersForm : Form
    {

        public BindingList<CounterItem> Counters { get; set; }

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
            Counters = new BindingList<CounterItem>();
            knvDataGridView1.DataSource = Counters;

            if (App.CurrentUser.Role == UserRole.ADMINISTRATOR ||
                App.CurrentUser.Role == UserRole.DEVELOPER)
            ModeAdmin();
                else
            ModeOperartor();

            EventAggregator.Instance.Subscribe((Action<UserChangedAppEvent>)
            (e => {

                if (e.User.Role == UserRole.ADMINISTRATOR ||
                   e.User.Role == UserRole.DEVELOPER)
                    ModeAdmin();
                else
                    ModeOperartor();
            }));
        }

        void ModeOperartor()
        {
            ToolStripMenuItemSave.Visible = false;
            ToolStripMenuItemReset.Visible = false;
        }

        void ModeAdmin()
        {
            ToolStripMenuItemSave.Visible = true;
            ToolStripMenuItemReset.Visible = true;
        }

        private void CountersForm_Load(object sender, EventArgs e)
        {
            _deviceItem = Devices.Library.Search(FamilyCode, OptionCode);
            toolStripStatusLabelVersion.Text = Application.ProductVersion;
            Text = _deviceItem.FirstName + "-" + Address + " Counters";
            foreach (IComponentItem comp in _deviceItem.Components)
            {
                Counters.Add(new CounterItem()
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
            foreach (CounterItem item in Counters)
                item.Value = MaltClient.Instance.GetCounter(FamilyCode, Address, item.Port).ToString();
            sw.Stop();
            toolStripStatusLabelUpdateTime.Text = sw.ElapsedMilliseconds.ToString() + "ms";
            AppLog.Instance.WriteLine(FamilyCode + Address + "Counters Update:" + toolStripStatusLabelUpdateTime.Text);
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sw = new Stopwatch();
            sw.Start();
            foreach (CounterItem item in Counters)
                MaltClient.Instance.SetCounter(FamilyCode, Address, item.Port, int.Parse(item.Value));
            MaltClient.Instance.SaveCounters(FamilyCode, Address);
            sw.Stop();
            toolStripStatusLabelUpdateTime.Text = sw.ElapsedMilliseconds.ToString() + "ms";
            AppLog.Instance.WriteLine(FamilyCode + Address + "Counters Save:" + toolStripStatusLabelUpdateTime.Text);
        }

        private void ResetToolStripMenuItemReset_Click(object sender, EventArgs e)
        {
            foreach (CounterItem item in Counters)
                item.Value = "0";
        }

        private void ToolStripStatusLabelLogo_Click(object sender, EventArgs e)
        {
            new UserLoginForm().ShowDialog();
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReadUpdate();
        }
    }
}