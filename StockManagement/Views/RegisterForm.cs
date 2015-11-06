using DatabaseHelper;
using DatabaseHelper.Models;
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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           bool registered = DBHelper.Register(new User() 
            {
                FullName = NameTextBox.Text,
                Email = EmailTextBox.Text,
                Password = PasswordTextBox.Text,
                Username = UsernameTextBox.Text,
                RegistrationDate = DateTime.Now
            });

           if (registered)
           {
               this.Hide();
               (new LoginForm()).Show();
           }


        }
    }
}
