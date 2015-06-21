using BSDAL;
using BSEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BSUI.Dashboard
{
    public partial class Login : System.Web.UI.Page
    {
        BSRepository BSRepo = new BSRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ex"] == "1")
            {
                Session.Remove("User");
                Session.Add("User", new BSEntities.BSUser()
                {
                    Account = Session.SessionID,
                    Name = null,
                    Role = BSEntities.BSUserRole.Guest
                });
            }

            BSUser usr = Session["User"] as BSUser;
            if (usr.Role != BSUserRole.Guest)
            {
                Response.Redirect("Dash");
            }

        }

        protected void btnGiris_Click(object sender, EventArgs e)
        {
            if (Page.IsValid && !string.IsNullOrEmpty(req1.Value) && !string.IsNullOrEmpty(req2.Value))
            {
                BSUser usr = BSRepo.GetAll<BSUser>()
                    .FirstOrDefault(x => (x.Account == req1.Value) && (x.Password == req2.Value.ToMD5Encrypt()));

                if (usr != null)
                {
                    Session["User"] = usr;
                    Response.Redirect("Dash");
                }
                else
                {
                    divSonuc.Visible = true;
                }
            }
        }
    }
}