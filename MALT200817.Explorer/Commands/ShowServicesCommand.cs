
namespace MALT200817.Explorer.Commands
{
    using System;
    using System.Windows.Forms;
    using Configuration;
    using Common;
    using System.Diagnostics;
    using Properties;

    class ShowServicesCommand : ToolStripButton
    {
        public ShowServicesCommand()
        {
            DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            Image = Resources.services32;
            Text = "Services";
        }

        protected override void OnClick(EventArgs e)
        { 
            base.OnClick(e);

            var myProcess = new Process();
            myProcess.StartInfo.FileName = "services.msc";
            myProcess.Start();

        }
    }
}
