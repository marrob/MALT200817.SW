
namespace MALT200817.Explorer.Commands
{
    using System;
    using System.Windows.Forms;
    using Configuration;
    using Common;
    using System.Diagnostics;

    class ShowServicesCommand : ToolStripButton
    {
        public ShowServicesCommand()
        {
            DisplayStyle = ToolStripItemDisplayStyle.Text;
            //    Size = new System.Drawing.Size(50, 50);
            Text = "Show Services";
        }

        protected override void OnClick(EventArgs e)
        { 
            Tools.RunNotepadOrNpp(AppConstants.AppConfigurationFilePath);
            base.OnClick(e);

            var myProcess = new Process();
            myProcess.StartInfo.FileName = "services.msc";
            myProcess.Start();

        }
    }
}
