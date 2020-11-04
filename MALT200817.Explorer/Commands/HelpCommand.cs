
namespace MALT200817.Explorer.Commands
{
    using System;
    using System.Windows.Forms;
    using View;
    using Properties;
    
    class HelpCommand : ToolStripButton
    { 
        public HelpCommand()
        {
            
            DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            Image = Resources.help32;
            Text = "Help";
        }

        protected override void OnClick(EventArgs e)
        {

            new HelpForm().Show();

            base.OnClick(e);
        }
    }
}
