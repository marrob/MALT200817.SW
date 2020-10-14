
namespace MALT200817.Explorer.Commands
{
    using System;
    using System.Windows.Forms;
    using View;
    using Properties;
    
    class AlwaysOnTopCommand : ToolStripButton
    {
        readonly Form _mainForm;

        public AlwaysOnTopCommand(Form mainForm)
        {
            
            DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            Image = Resources.pin32;
            Text = "Always On Top";

            _mainForm = mainForm;
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            _mainForm.TopMost = !_mainForm.TopMost;
            Checked = _mainForm.TopMost;
        }
    }
}
