﻿using DotNetNote.DotNetNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNetNote.DotNetNote
{
    public partial class BoardDelete : System.Web.UI.Page
    {
        private string _Id;
        protected void Page_Load(object sender, EventArgs e)
        {

            _Id = Request.QueryString["Id"];
            lnkCancel.NavigateUrl = "BoardView.aspx?Id=" + _Id + "&ANum=" + Request["ANum"]; ;
            lblId.Text = Request.QueryString["ANum"];

            btnDelete.Attributes["onclick"] = "return ConfirmDelete()"; // 클라이언트 이벤트 리턴

            if (String.IsNullOrEmpty(_Id))
            {
                Response.Redirect("BoardList.aspx");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (new NoteRepository().DeleteNote(Convert.ToInt32(_Id), txtPassword.Text) > 0) {
                Response.Redirect("BoardList.aspx");
            }
            else
            {
                lblMessage.Text = "비밀번호를 확인 해주세요.";
            }
        }
    }
}