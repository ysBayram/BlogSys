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
    public partial class Comment : System.Web.UI.Page
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
                GetCommentPageDetail();
                usr = Session["User"] as BSUser;
                if (AddEdit != 0)
                {
                    btnProcess.Text = "Düzenle";
                    BSComment _comm = Repo.GetAll<BSComment>().Where(x => x.ID == AddEdit).FirstOrDefault();
                    txtCName.Text = _comm.CommenterName;
                    txtDate.Text = string.Format("{0:dd/MM/yyyy hh:mm}", _comm.Date);
                    ddlPost.SelectedValue = _comm.Post.ID.ToString();
                    tbIcerik.InnerText = _comm.Content;
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

                    if (!string.IsNullOrEmpty(txtCName.Text) && !string.IsNullOrEmpty(txtDate.Text) && (ddlPost.SelectedIndex != -1) && !string.IsNullOrEmpty(tbIcerik.InnerText))
                    {
                        Repo.Insert<BSComment>(new BSComment()
                        {
                            CommenterName = txtCName.Text,
                            Date = Convert.ToDateTime(txtDate.Text),
                            Post = Repo.GetAll<BSPost>().ToList().Where(x => x.ID == Convert.ToInt32(ddlPost.SelectedValue)).FirstOrDefault(),
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
                    GetCommentPageDetail();
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtCName.Text) && !string.IsNullOrEmpty(txtDate.Text) && (ddlPost.SelectedIndex != -1) && !string.IsNullOrEmpty(tbIcerik.InnerText))
                    {
                        BSComment EditComm = Repo.GetAll<BSComment>().ToList().Where(x => x.ID == AddEdit).FirstOrDefault();
                        EditComm.CommenterName = txtCName.Text;
                        EditComm.Date = Convert.ToDateTime(txtDate.Text);
                        EditComm.Post = Repo.GetAll<BSPost>().ToList().Where(x => x.ID == Convert.ToInt32(ddlPost.SelectedValue)).FirstOrDefault();
                        EditComm.Content = tbIcerik.InnerText;
                        Repo.Update<BSComment>();
                        Sonuc.Attributes.Add("class", "nNote nSuccess hideit");
                        Sonuc.InnerHtml = "<p><strong>BAŞARILI: </strong>Bilgiler Güncellendi.</p>";
                    }
                    else
                    {
                        Sonuc.Attributes.Add("class", "nNote nFailure hideit");
                        Sonuc.InnerHtml = "<p><strong>HATALI: </strong>Bilgiler Güncellenemedi.</p>";
                    }
                    GetCommentPageDetail();
                }
            }
            catch (Exception)
            {
                Sonuc.Attributes.Add("class", "nNote nFailure hideit");
                Sonuc.InnerHtml = "<p><strong>HATALI: </strong>Bilgiler Güncellenemedi.</p>";
            }

            Sonuc.Visible = true;
        }

        protected void rptComments_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Sil")
            {
                Repo.Delete<BSComment>(Repo.GetAll<BSComment>().FirstOrDefault(x => x.ID == Convert.ToInt32(e.CommandArgument)));
                GetCommentPageDetail();
            }
            if (e.CommandName == "Edit") { Response.Redirect("Comment?ID=" + e.CommandArgument); }
        }

        protected void GetCommentPageDetail()
        {
            ddlPost.DataSource = Repo.GetAll<BSPost>();
            ddlPost.DataTextField = "Title";
            ddlPost.DataValueField = "ID";
            ddlPost.DataBind();

            rptComments.DataSource = Repo.GetAll<BSComment>();
            rptComments.DataBind();
        }

    }
}