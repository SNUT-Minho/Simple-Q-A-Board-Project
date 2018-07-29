using DotNetNote.DotNetNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNetNote.DotNetNote
{
    public partial class BoardCommentDelete : System.Web.UI.Page
    {
        public int BoardId { get; set; }
        public int Id { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if((Request["BoardId"] != null) && (Request.QueryString["Id"] != null)){
                BoardId = Convert.ToInt32(Request["BoardId"]);
                Id = Convert.ToInt32(Request["Id"]);
            }
            else
            {

            }
        }

        protected void btnCommentDelete_Click(object sender, EventArgs e) {
            var repo = new NoteCommentRepository();
            if (repo.GetCountBy(BoardId, Id, txtPassword.Text.Replace("--", "")) > 0)
            {
                repo.DeleteComment(BoardId, Id, txtPassword.Text.Replace("--", ""));
                Response.Redirect($"BoardView.aspx?Id={BoardId}&ANum={Request["ANum"]}");
            }
            else
            {
                lblError.Text = "암호가 틀립니다. 다시 입력해주세요.";
            }
        }
    }
}