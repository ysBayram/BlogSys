using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BSDAL;
using BSEntities;

namespace BSUI
{
    public partial class Default : System.Web.UI.Page
    {
        BSCacheRepository bsrep = new BSCacheRepository();
        public int CurrentPage
        {
            get
            {
                object o = this.ViewState["_CurrentPage"];
                if (o == null)
                    return 0;
                else
                    return (int)o;
            }

            set
            {
                this.ViewState["_CurrentPage"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //rptPost.DataSource = bsrep.Get<BSPost>();
                //rptPost.DataBind();
                GetPosts();
            }
        }

        protected void GetPosts()
        {
            PagedDataSource pd = new PagedDataSource();
            pd.AllowPaging = true;
            pd.PageSize = 10;
            pd.DataSource = bsrep.Get<BSPost>();
            pd.CurrentPageIndex = CurrentPage;
            PageNumber.Text = "Sayfa: " + (CurrentPage).ToString();
            btnPrev.Enabled = !pd.IsFirstPage;
            btnNext.Enabled = !pd.IsLastPage;

            rptPost.DataSource = null;
            rptPost.DataSource = pd;
            rptPost.DataBind();
        }

        protected void btnPrev_Click(object sender, EventArgs e)
        {
            CurrentPage -= 1;
            GetPosts();
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            GetPosts();
        }
    }
}