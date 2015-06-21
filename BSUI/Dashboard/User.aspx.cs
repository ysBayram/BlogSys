using BSDAL;
using BSEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace BSUI.Dashboard
{
    public partial class User : System.Web.UI.Page
    {
        int AddEdit = 0;
        BSRepository Repo;
        BSUser usr;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                AddEdit = 0;
            }
            else
            {
                AddEdit = Convert.ToInt32(Request.QueryString["ID"]);
            }

            Repo = new BSRepository();

            if (!Page.IsPostBack)
            {
                GetUserDetail();
                usr = Session["User"] as BSUser;
                if (AddEdit != 0)
                {
                    btnProcess.Text = "Düzenle";
                    BSUser _usr = Repo.GetAll<BSUser>().Where(x => x.ID == AddEdit).FirstOrDefault();
                    txtAccount.Text = _usr.Account;
                    txtPassword.Text = _usr.Mail;
                    txtName.Text = _usr.Name;
                    txtSurname.Text = _usr.Surname;
                    ddlRole.SelectedValue = (Convert.ToInt32(_usr.Role)).ToString();
                }
            }
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            HtmlGenericControl Sonuc = (HtmlGenericControl)Master.FindControl("divSonuc");
            try
            {
                if (AddEdit == 0)
                {

                    if (!string.IsNullOrEmpty(txtAccount.Text) && !string.IsNullOrEmpty(txtPassword.Text) && !string.IsNullOrEmpty(txtMail.Text) && !string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtSurname.Text) && (ddlRole.SelectedIndex != -1) && fuAvatar.HasFile)
                    {
                        Repo.Insert<BSUser>(new BSUser()
                        {
                            Account = txtAccount.Text,
                            Password = txtPassword.Text.ToMD5Encrypt(),
                            Mail = txtMail.Text,
                            Name = txtName.Text,
                            Surname = txtSurname.Text,
                            Avatar = fuAvatar.FileName,
                            Role = (BSUserRole)Convert.ToInt32(ddlRole.SelectedValue)
                        });
                        Sonuc.Attributes.Add("class", "nNote nSuccess hideit");
                        Sonuc.InnerHtml = "<p><strong>BAŞARILI: </strong>Bilgiler Kaydedildi.</p>";
                    }
                    else
                    {
                        Sonuc.Attributes.Add("class", "nNote nFailure hideit");
                        Sonuc.InnerHtml = "<p><strong>HATALI: </strong>Bilgiler Kaydedilemedi.</p>";
                    }
                    GetUserDetail();
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtAccount.Text) && !string.IsNullOrEmpty(txtPassword.Text) && !string.IsNullOrEmpty(txtMail.Text) && !string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtSurname.Text) && (ddlRole.SelectedIndex != -1) && fuAvatar.HasFile)
                    {
                        BSUser EditUser = Repo.GetAll<BSUser>().ToList().Where(x => x.ID == AddEdit).FirstOrDefault();
                        EditUser.Account = txtAccount.Text;
                        EditUser.Password = txtPassword.Text.ToMD5Encrypt();
                        EditUser.Mail = txtMail.Text;
                        EditUser.Name = txtName.Text;
                        EditUser.Surname = txtSurname.Text;
                        EditUser.Avatar = fuAvatar.FileName;
                        EditUser.Role = (BSUserRole)Convert.ToInt32(ddlRole.SelectedValue);
                        Repo.Update<BSUser>();
                        Sonuc.Attributes.Add("class", "nNote nSuccess hideit");
                        Sonuc.InnerHtml = "<p><strong>BAŞARILI: </strong>Bilgiler Güncellendi.</p>";
                    }
                    else
                    {
                        Sonuc.Attributes.Add("class", "nNote nFailure hideit");
                        Sonuc.InnerHtml = "<p><strong>HATALI: </strong>Bilgiler Güncellenemedi.</p>";
                    }
                    GetUserDetail();
                }

            }
            catch (Exception)
            {
                Sonuc.Attributes.Add("class", "nNote nFailure hideit");
                Sonuc.InnerHtml = "<p><strong>HATALI: </strong>Bilgiler Güncellenemedi.</p>";
            }

            Sonuc.Visible = true;
        }

        protected void rptUsers_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Sil")
            {
                Repo.Delete<BSUser>(Repo.GetAll<BSUser>().FirstOrDefault(x => x.ID == Convert.ToInt32(e.CommandArgument)));
                GetUserDetail();
            }
            if (e.CommandName == "Edit") { Response.Redirect("User?ID=" + e.CommandArgument); }
        }

        protected void GetUserDetail()
        {
            ddlRole.DataSource = Tools.Enumeration.GetAll<BSUserRole>();
            ddlRole.DataTextField = "Value";
            ddlRole.DataValueField = "Key";
            ddlRole.DataBind();

            rptUsers.DataSource = Repo.GetAll<BSUser>();
            rptUsers.DataBind();
        }

    }
}