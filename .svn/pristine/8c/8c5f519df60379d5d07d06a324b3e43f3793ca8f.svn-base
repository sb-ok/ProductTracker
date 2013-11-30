using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProductTracker.Properties;

namespace ProductTracker
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void RegistrationButtom_Click(object sender, EventArgs e)
        {
            var user = new User();
            if (user.LoginAvailable(loginField.Text))
            {
                MessageBox.Show(Resources.user_there_in_db, Resources.error_operation_msg);
            }
            else
            {
                user.CreateNew(loginField.Text, pswField.Text);
            }
        }
    }
}
