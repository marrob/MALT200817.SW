
namespace MALT200817.Explorer.Commands
{
    using System;
    using System.Windows.Forms;
    using Configuration;
    using Common;
    using Events;
    using Properties;
    class ShowConfigurationCommand : ToolStripButton
    {
        public ShowConfigurationCommand()
        {
            DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            Image = Resources.configure32x32;
            Text = "Configuration";

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
            Tools.RunNotepadOrNpp(AppConstants.AppConfigurationFilePath);
            base.OnClick(e);

        }
    }
}
