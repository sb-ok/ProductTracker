using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using ProductTracker.ProductStructure;
using ProductTracker.Properties;

namespace ProductTracker.Autorisation
{
    public partial class AutorisationForm : Form
    {
        public AutorisationForm()
        {
            InitializeComponent();
        }

        private void afButLog_Click(object sender, EventArgs e)
        {
            if (loginBox.Text == String.Empty & pswBox.Text == String.Empty)
            {
                MessageBox.Show(Resources.afButLog_login_emptyData, 
                    Resources.afButLog_login_emptyData_MessageCaption);
                return;
            }
            if (loginBox.Text == String.Empty)
            {
                MessageBox.Show(Resources.afButLog_login_emptyLogin,
                    Resources.afButLog_login_emptyData_MessageCaption);
                return;
            }
            if (pswBox.Text == String.Empty)
            {
                MessageBox.Show(Resources.afButLog_login_emptyPsw, 
                    Resources.afButLog_login_emptyData_MessageCaption);
                return;
            }

            var user = new User();
            user.Login = loginBox.Text;
            if (user.Autorisation(pswBox.Text))
            {
                switch (user.UserInRole())
                {
                    case 1:
                        var adminWindows = new AdministrationWindows(/*user*/);
                        adminWindows.Show();
                        break;
                }
                Hide();
            }
        }
    }
}
