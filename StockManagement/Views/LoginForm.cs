using DatabaseHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManagement.Views
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter your credentials.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool loggedIn = DBHelper.CheckLogin(username, password);

            if (!loggedIn)
            {
                MessageBox.Show("The credentials were not correct, please enter valid credentials or register a new account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                (new HomeForm()).Show();
                this.Hide();
            }
        }
    }
}
