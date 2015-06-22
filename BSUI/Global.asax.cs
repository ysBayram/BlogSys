using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace BSUI
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            if (BSDAL.BSContextProvider.BSdb.Database.Exists())
            {
                //Bu komutlar var olan db deki cache sistemini ayarlamak için

                //Environment.SpecialFolder.Windows + @"\Microsoft.NET\Framework64\v4.0.30319\aspnet_regsql -S . -E -d BSEntities -ed
                //Environment.SpecialFolder.Windows + @"\Microsoft.NET\Framework64\v4.0.30319\aspnet_regsql -S . -E -d BSEntities -t BSPost -et

                SqlDependency.Start(ConfigurationManager.ConnectionStrings["BSConnectionString"].ConnectionString);
            }

            RouteTable.Routes.MapPageRoute("Anasayfa","Anasayfa","~/Default.aspx");
            RouteTable.Routes.MapPageRoute("PostDetail", "Detay-{Title}-{ID}", "~/Detail.aspx");
            RouteTable.Routes.MapPageRoute("Dashboard/Dash", "Dashboard/Dash", "~/Dashboard/Dash.aspx");
            RouteTable.Routes.MapPageRoute("Dashboard/Login", "Dashboard/Login", "~/Dashboard/Login.aspx");
            RouteTable.Routes.MapPageRoute("Dashboard/Post", "Dashboard/Post", "~/Dashboard/Post.aspx");
            RouteTable.Routes.MapPageRoute("Dashboard/User", "Dashboard/User", "~/Dashboard/User.aspx");
            RouteTable.Routes.MapPageRoute("Dashboard/Comment", "Dashboard/Comment", "~/Dashboard/Comment.aspx");
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session.Add("User", new BSEntities.BSUser() 
            { 
                Account = Session.SessionID,
                Name = null,
                Role = BSEntities.BSUserRole.Guest
            });
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            
        }

        protected void Application_End(object sender, EventArgs e)
        {
            
        }
    }
}