

namespace MALT200817.Explorer.View
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Configuration;
    using Events;

    public partial class UserLoginForm : Form
    {
        private UserItem _userItem;

        public UserLoginForm()
        {
            InitializeComponent();
        }

        private void TextBoxPassword_TextChanged(object sender, EventArgs e)
        {
            _userItem = AppConfiguration.Instance.Users.FirstOrDefault(n => n.Password == textBoxPassword.Text);
            if (_userItem != null)
            {
                textBoxYourRole.Text = _userItem.Role.ToString();
                textBoxYourName.Text = _userItem.Name;
                buttonOK.Enabled = true;
            }
            else
            {
                textBoxYourName.Text = "Invalid password";
                textBoxYourRole.Text = "Invalid password";
                buttonOK.Enabled = false;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            EventAggregator.Instance.Publish(new UserChangedAppEvent(_userItem));
            DialogResult = DialogResult.OK;
        }
    }
}
