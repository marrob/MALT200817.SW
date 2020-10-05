

namespace MALT200817.Explorer.Commands
{
    using System;
    using System.Windows.Forms;
    using System.ComponentModel;
    using Client;
    using Events;
    using Configuration;

    class CountersSaveCommand : ToolStripButton
    {
        readonly BindingList<CounterItem> Counters;
        readonly string FamilyCode;
        readonly string Address;

        public CountersSaveCommand(BindingList<CounterItem> counters, string familyCode, string address)
        {
            Counters = counters;
            FamilyCode = familyCode;
            Address = address;

        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);


        }
    }
}
