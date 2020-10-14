
namespace MALT200817.Explorer.Commands
{
    using System;
    using System.Windows.Forms;
    using Configuration;
    using Common;
    using Properties;
    class ShowLogFolderCommand : ToolStripButton
    {
        public ShowLogFolderCommand()
        {
            DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            Image = Resources.log24;
            Text = "Log Folder";
        }
        protected override void OnClick(EventArgs e)
        {
            Tools.OpenFolder(AppConfiguration.Instance.LogDirectory);
        }

    }
}
