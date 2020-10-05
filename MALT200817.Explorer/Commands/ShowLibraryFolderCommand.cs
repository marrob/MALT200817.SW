
namespace MALT200817.Explorer.Commands
{
    using System;
    using System.Windows.Forms;
    using Configuration;
    using Common;
    using Events;

    class ShowLibraryFolderCommand : ToolStripButton
    {
        public ShowLibraryFolderCommand()
        {
            DisplayStyle = ToolStripItemDisplayStyle.Text;
            //    Size = new System.Drawing.Size(50, 50);
            Text = "Show Library Folder";

            EventAggregator.Instance.Subscribe((Action<UserChangedAppEvent>)
            (e => {

                if (e.User.Role == UserRole.ADMINISTRATOR ||
                   e.User.Role == UserRole.DEVELOPER
                )
                    Visible = true;
                else
                    Visible = false; 
            }));
        }
        protected override void OnClick(EventArgs e)
        {
            Tools.OpenFolder(AppConstants.LibraryDirectory) ;

        }

    }
}
