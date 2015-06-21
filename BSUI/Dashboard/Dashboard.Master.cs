using BSEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BSUI.Dashboard
{
    public partial class Dashboard : System.Web.UI.MasterPage
    {
        protected BSUser _Usr { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            _Usr = Session["User"] as BSUser;
            if (!Page.IsPostBack)
            {
                if (_Usr.Role == BSUserRole.Guest)
                {
                    Response.Redirect("Login");
                }
            }
        }
    }
}