using DotNetNote.DotNetNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNetNote.DotNetNote
{
    public partial class BoardView : System.Web.UI.Page
    {
        private string _Id;

        protected void Page_Load(object sender, EventArgs e)
        {
            lnkDelte.NavigateUrl = "BoardDelete.aspx?Id=" + Request["Id"] +"&ANum=" + Request["ANum"];
            lnkModify.NavigateUrl = "BoardModify.aspx?Id=" + Request["Id"] + "&ANum=" + Request["ANum"];
            lnkReply.NavigateUrl = "BoardReply.aspx?Id=" + Request["Id"] + "&ANum=" + Request["ANum"];

            _Id = Request.QueryString["Id"];
            if(_Id == null)
            {
                Response.Redirect("./BoardList.aspx");
            }
            if (!this.IsPostBack)
            {
                DisplayData();
            }
        }

        private void DisplayData()
        {
            var note = (new NoteRepository().GetNoteById(Convert.ToInt32(_Id)));

            lblNum.Text = Request.QueryString["ANum"].ToString();
            lblName.Text = note.Name;
            if(!String.IsNullOrEmpty(note.Email)) { lblEmail.Text = String.Format("<a href='mailto:{0}'>{0}</a>", note.Email); } else { lblEmail.Text = "None"; }
           
           
            string strContent = note.Content;

            // 인코딩 방식에 따른 데이터 출력
            string strEocoding = note.Encoding;
            //if (strEocoding == "Text")
            //{
            //    lblContent.Text = strContent.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\r\n", "<br />");
            //}
            //else if (strEocoding == "Mixed")
            //{
            //    lblContent.Text = strContent.Replace("\r\n", "<br />");
            //}
            //else
            //{
                lblContent.Text = strContent;
            //}

            lblReadCount.Text = note.ReadCount.ToString();
            //lblHomepage.Text = String.Format($"<a href=\"{note.Homepage}\" target=\"_blank\">{note.Homepage}</a>");
            lblPostDate.Text = note.PostDate.ToString("yyyy-MM-dd");
            //lblPostIP.Text = note.PostIp;

            
            if (note.FileName.Length > 1)
            {
                lblFile.Text = $"<a href=\"./BoardDown.aspx?Id={note.Id}\">{note.FileName}</a>";
                if (Dul.BoardLibrary.IsPhoto(note.FileName)) {
                    ltlImage.Text = $"<img src=\'ImageDown.aspx?FileName={Server.UrlEncode(note.FileName)}\' width=\"300px\" height=\"400px\" >";
                }
            }
            else
            {
                lblFile.Text = "None";
            }
        }
    }
}