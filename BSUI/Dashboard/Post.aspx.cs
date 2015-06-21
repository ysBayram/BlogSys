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
    public partial class Post : System.Web.UI.Page
    {
        int AddEdit = 0;
        BSCacheRepository CacheRepo;
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

            CacheRepo = new BSCacheRepository();
            Repo = new BSRepository();

            if (!Page.IsPostBack)
            {
                GetPostPageDetail();
                usr = Session["User"] as BSUser;
                if (AddEdit != 0)
                {
                    btnProcess.Text = "Düzenle";
                    BSPost _post = CacheRepo.Get<BSPost>().Where(x => x.ID == AddEdit).FirstOrDefault();
                    txtTitle.Text = _post.Title;
                    txtDate.Text = string.Format("{0:dd/MM/yyyy hh:mm}", _post.Date);
                    ddlUser.SelectedValue = _post.User.ID.ToString();
                    tbIcerik.InnerText = _post.Content;
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

                    if (!string.IsNullOrEmpty(txtTitle.Text) && !string.IsNullOrEmpty(txtDate.Text) && (ddlUser.SelectedIndex != -1) && !string.IsNullOrEmpty(tbIcerik.InnerText))
                    {
                        Repo.Insert<BSPost>(new BSPost()
                        {
                            Title = txtTitle.Text,
                            Date = Convert.ToDateTime(txtDate.Text),
                            User = Repo.GetAll<BSUser>().ToList().Where(x => x.ID == Convert.ToInt32(ddlUser.SelectedValue)).FirstOrDefault(),
                            Content = tbIcerik.InnerText
                        });
                        Sonuc.Attributes.Add("class", "nNote nSuccess hideit");
                        Sonuc.InnerHtml = "<p><strong>BAŞARILI: </strong>Bilgiler Kaydedildi.</p>";
                    }
                    else
                    {
                        Sonuc.Attributes.Add("class", "nNote nFailure hideit");
                        Sonuc.InnerHtml = "<p><strong>HATALI: </strong>Bilgiler Kaydedilemedi.</p>";
                    }
                    GetPostPageDetail();
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtTitle.Text) && !string.IsNullOrEmpty(txtDate.Text) && (ddlUser.SelectedIndex != -1) && !string.IsNullOrEmpty(tbIcerik.InnerText))
                    {
                        BSPost EditPost = Repo.GetAll<BSPost>().ToList().Where(x => x.ID == AddEdit).FirstOrDefault();
                        EditPost.Title = txtTitle.Text;
                        EditPost.Date = Convert.ToDateTime(txtDate.Text);
                        EditPost.User = Repo.GetAll<BSUser>().ToList().Where(x => x.ID == Convert.ToInt32(ddlUser.SelectedValue)).FirstOrDefault();
                        EditPost.Content = tbIcerik.InnerText;
                        Repo.Update<BSPost>();
                        Sonuc.Attributes.Add("class", "nNote nSuccess hideit");
                        Sonuc.InnerHtml = "<p><strong>BAŞARILI: </strong>Bilgiler Güncellendi.</p>";
                    }
                    else
                    {
                        Sonuc.Attributes.Add("class", "nNote nFailure hideit");
                        Sonuc.InnerHtml = "<p><strong>HATALI: </strong>Bilgiler Güncellenemedi.</p>";
                    }
                    GetPostPageDetail();
                }

            }
            catch (Exception)
            {
                Sonuc.Attributes.Add("class", "nNote nFailure hideit");
                Sonuc.InnerHtml = "<p><strong>HATALI: </strong>Bilgiler Güncellenemedi.</p>";
            }

            Sonuc.Visible = true;
        }

        protected void rptPosts_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Sil")
            {
                Repo.Delete<BSPost>(CacheRepo.Get<BSPost>().FirstOrDefault(x => x.ID == Convert.ToInt32(e.CommandArgument)));
                GetPostPageDetail();
            }
            if (e.CommandName == "Edit") { Response.Redirect("Post?ID=" + e.CommandArgument); }
        }

        protected void GetPostPageDetail()
        {
            ddlUser.DataSource = Repo.GetAll<BSUser>();
            ddlUser.DataTextField = "Account";
            ddlUser.DataValueField = "ID";
            ddlUser.DataBind();

            rptPosts.DataSource = CacheRepo.Get<BSPost>();
            rptPosts.DataBind();
        }

    }
}