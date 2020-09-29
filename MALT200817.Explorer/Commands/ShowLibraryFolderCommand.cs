
namespace MALT200817.Explorer.Commands
{
    using System;
    using System.Windows.Forms;
    using Configuration;
    using Common;

    class ShowLibraryFolderCommand : ToolStripButton
    {
        public ShowLibraryFolderCommand()
        {
            DisplayStyle = ToolStripItemDisplayStyle.Text;
            //    Size = new System.Drawing.Size(50, 50);
            Text = "Show Library Folder";
        }
        protected override void OnClick(EventArgs e)
        {
            Tools.OpenFolder(AppConstants.LibraryDirectory) ;

        }

    }
}
