

namespace MALT200817.Explorer.View
{
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using Configuration;
    using Events;

    public partial class UserLoginForm : Form
    {
        private UserItem User;

        public UserLoginForm()
        {
            InitializeComponent();
        }

        private void TextBoxPassword_TextChanged(object sender, EventArgs e)
        {
            User = AppConfiguration.Instance.Users.FirstOrDefault(n => n.Password == textBoxPassword.Text);
            if (User != null)
            {
                textBoxYourRole.Text = User.Role.ToString();
                textBoxYourName.Text = User.Name;
                buttonOK.Enabled = true;
            }
            else
            {
                textBoxYourName.Text = "Invalid password";
                textBoxYourRole.Text = "Invalid password";
                buttonOK.Enabled = false;
            }
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            EventAggregator.Instance.Publish(new UserChangedAppEvent(User));
            DialogResult = DialogResult.OK;
        }
    }
}
