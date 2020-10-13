
namespace MALT200817.Explorer.Commands
{
    using System;
    using System.Windows.Forms;
    using Configuration;
    using Common;

    class ShowLogFolderCommand : ToolStripButton
    {
        public ShowLogFolderCommand()
        {
            DisplayStyle = ToolStripItemDisplayStyle.Text;
            //    Size = new System.Drawing.Size(50, 50);
            Text = "Log Folder";
        }
        protected override void OnClick(EventArgs e)
        {
            Tools.OpenFolder(AppConfiguration.Instance.LogDirectory);
        }

    }
}
