
namespace MALT200817.Explorer.Commands
{
    using System;
    using System.Windows.Forms;
    using Configuration;
    using Common;
    using Events;

    class ShowConfigurationCommand : ToolStripButton
    {
        public ShowConfigurationCommand()
        {
            DisplayStyle = ToolStripItemDisplayStyle.Text;
            //    Size = new System.Drawing.Size(50, 50);
            Text = "Show Configuration";

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
