using DatabaseHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppManagement
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // if user already logged in redirect to default.aspx
            if (Session[SessionKeys.Username] != null)
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string username = UsernameText.Text;
            string password = PasswordText.Text;
            bool isLoggedIn = DBHelper.CheckAdminLogin(username, password);
            if (isLoggedIn)
            {
                Session[SessionKeys.Username] = username;
                Response.Redirect("Default.aspx");
            }
            else
            {
                ResultLabel.Text = "Your username or password is invalid, please try again.";
            }

        }
    }
}