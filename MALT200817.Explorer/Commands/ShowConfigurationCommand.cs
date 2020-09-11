
namespace MALT200817.Explorer.Commands
{
    using System;
    using System.Windows.Forms;
    using Configuration;
    using Common;

    class ShowConfigurationCommand : ToolStripButton
    {
        public ShowConfigurationCommand()
        {
            DisplayStyle = ToolStripItemDisplayStyle.Text;
            //    Size = new System.Drawing.Size(50, 50);
            Text = "Show Configuration";
        }

        protected override void OnClick(EventArgs e)
        { 
            Tools.RunNotepadOrNpp(AppConstants.AppConfigurationFilePath);
            base.OnClick(e);

        }
    }
}
