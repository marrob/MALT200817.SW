
namespace MALT200817.Explorer.Commands
{
    using System;
    using System.Windows.Forms;
    using Configuration;
    using Common;
    using Events;
    using Properties;
    class ShowLibraryFolderCommand : ToolStripButton
    {
        public ShowLibraryFolderCommand()
        {
            DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            Image = Resources.data32;
            Text = "Library Folder";

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
