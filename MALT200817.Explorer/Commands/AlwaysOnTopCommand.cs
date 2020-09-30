
namespace MALT200817.Explorer.Commands
{
    using System;
    using System.Windows.Forms;
    using View;

    class AlwaysOnTopCommand : ToolStripButton
    {
        readonly Form _mainForm;

        public AlwaysOnTopCommand(Form mainForm)
        {
            //    Image = Resources.Delete32x32;
            DisplayStyle = ToolStripItemDisplayStyle.Text;
            //    Size = new System.Drawing.Size(50, 50);
            Text = "Always On Top";

            _mainForm = mainForm;
            //   _diagnosticsView = diagnosticsView;
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            _mainForm.TopMost = !_mainForm.TopMost;
            Checked = _mainForm.TopMost;
        }
    }
}
