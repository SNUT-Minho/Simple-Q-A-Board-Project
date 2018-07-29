using DotNetNote.DotNetNote.Models;
using DotNetNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNetNote.DotNetNote.Controls
{
    public partial class BoardCommentControl : System.Web.UI.UserControl
    {
        private NoteCommentRepository repo = new NoteCommentRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // 코멘트 출력
                ctlCommentList.DataSource = repo.GetNoteComments(Convert.ToInt32(Request["Id"]));
                ctlCommentList.DataBind();
            }
        }

        protected void btnWriteComment_OnClick(object sender, EventArgs e)
        {
            // 코멘트 객체 생성
            NoteComment comment = new NoteComment();
            comment.BoardId = Convert.ToInt32(Request["Id"]);
            comment.Name = txtName.Text;
            comment.Password = txtPassword.Text;
            comment.Opinion = txtOpinion.Text;

            // 코멘트 입력
            repo.AddNoteComment(comment);
            Response.Redirect($"{Request.ServerVariables["SCRIPT_NAME"]}?Id={Request["Id"]}&ANum={Request["ANum"]}");
        }
    }
}