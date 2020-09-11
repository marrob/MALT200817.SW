
namespace MALT200817.Explorer.Commands
{
    using System;
    using System.Windows.Forms;
    using Configuration;
    using Common;

    class ShowLogCommand : ToolStripButton
    {
        public ShowLogCommand()
        {
            DisplayStyle = ToolStripItemDisplayStyle.Text;
            //    Size = new System.Drawing.Size(50, 50);
            Text = "Show Log";
        }
        protected override void OnClick(EventArgs e)
        {
            Tools.RunNotepadOrNpp(AppConstants.LogDirectory) ;

        }

    }
}
