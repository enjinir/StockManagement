using DatabaseHelper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppManagement
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if the user is logged in
            if (Session[SessionKeys.Username] == null)
            {
                // If not, redirect the user to the login page.
                Response.Redirect("Login.aspx");
            }   

        }

        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            DBHelper.CurrentUser = null;
            Session[SessionKeys.Username] = null;
            Response.Redirect("Login.aspx");

        }

        protected void LogButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Logs.aspx");
        }
    }
}