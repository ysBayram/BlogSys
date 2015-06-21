using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BSEntities;
using BSDAL;

namespace BSUI
{
    public partial class Detail : System.Web.UI.Page
    {
        protected BSPost _Post { get; set; }

        BSRepository BSRepo = new BSRepository();
        BSUser usr;

        protected void Page_Load(object sender, EventArgs e)
        {
            int PostId = Convert.ToInt32(RouteData.Values["ID"]);

            BSCacheRepository cacheRepo = new BSCacheRepository();
            _Post = cacheRepo.Get<BSPost>().FirstOrDefault(x => x.ID == PostId);

            rptComment.DataSource = BSRepo.GetAll<BSComment>().Where(x => x.Post.ID == _Post.ID).ToList();
            rptComment.DataBind();

            usr = Session["User"] as BSUser;
            if (usr.Name != null) { CommenterName.Value = usr.Name; }
        }

        protected void btnSendComment_Click(object sender, EventArgs e)
        {
            BSRepo.Insert<BSComment>(new BSComment()
            {
                CommenterName = CommenterName.Value,
                Content = CommentContent.Value,
                Date = DateTime.Now,
                Post = _Post
            });

            usr.Name = CommenterName.Value;

            rptComment.DataSource = BSRepo.GetAll<BSComment>().Where(x => x.Post.ID == _Post.ID).ToList();
            rptComment.DataBind();
        }
    }
}