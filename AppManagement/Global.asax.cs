using DatabaseHelper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace AppManagement
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            if (!DBHelper.IsConnected)
            {
                string connectionString = ConfigurationSettings.AppSettings["AppManager.ConnectionString"];
                DBHelper.Connect(connectionString);
            }
        }
    }
}