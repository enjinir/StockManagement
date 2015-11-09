using DatabaseHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppManagement
{
    public partial class Logs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[SessionKeys.Username] != null)
            {
                // Do nothing..
            }
            else
            {
                // Redirect to Login.aspx
                Response.Redirect("Login.aspx");
            }

        }

        private void ShowLogs()
        {
            LogsView.DataSource = DBHelper.GetLogTable();
            LogsView.DataBind();
        }
    }
}