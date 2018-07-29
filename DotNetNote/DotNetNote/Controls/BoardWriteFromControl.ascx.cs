using DotNetNote.DotNetNote.Models;
using DotNetNote.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dul;

namespace DotNetNote.DotNetNote
{
    public partial class BoardWriteFromControl : System.Web.UI.UserControl
    {
        private string _BaseDir = String.Empty; //파일 업로드 폴드
        private string _FileName = String.Empty; //파일명 저장 필드
        private int _FileSize = 0; //파일크기 저장 필드

        protected void Page_Load(object sender, EventArgs e)
        {
            // Empty
        }


        /// <summary>
        /// 저장 버튼 클릭스 해당 정보를 Note 객채로 변환해 DB에 저장
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnWrite_Click(object sender, EventArgs e)
        {
            if (IsImageTextCorrect())
            {
                UploadProcess(); // 파일 업로드 프로세스 구현

                Note note = new Note();
                note.Name = txtName.Text;
                note.Email = HtmlUtility.Encode(txtEmail.Text);
                note.Homepage = txtHomepage.Text;
                note.Title = txtTitle.Text;
                
                note.Content = HtmlUtility.Encode(txtContent.Text);
                note.FileName = _FileName;
                note.FileSize = _FileSize;
                note.Password = txtPassword.Text;
                note.PostIp = Request.UserHostAddress;
                note.Encoding = rdoEncoding.SelectedValue;

                NoteRepository repo = new NoteRepository();
                repo.Add(note);

                
                Response.Redirect("BoardList.aspx");
            }
            else
            {
                lblError.Text = "보안코드가 틀립니다. 다시 입력하세요.";
            }
        }

        private void UploadProcess()
        {
            // 파일 업로드처리 시작
            _BaseDir = Server.MapPath("./MyFiles");
            _FileName = String.Empty;
            _FileSize = 0;
            if (txtFileName.PostedFile != null) {
                if (txtFileName.PostedFile.FileName.Trim().Length > 0 && txtFileName.PostedFile.ContentLength > 0) {
                    _FileName = Dul.FileUtility.GetFileNameWithNumbering(_BaseDir, Path.GetFileName(txtFileName.PostedFile.FileName));
                    _FileSize = txtFileName.PostedFile.ContentLength;
                    // 업로드 처리 : SaveAs()
                    txtFileName.PostedFile.SaveAs(Path.Combine(_BaseDir,_FileName));
                }
            }// 파일 업로드 처리 끝
        }

        /// <summary>
        /// 로그인한 사용자이거나, 보안코드의 텍스트 값을 정상적으로 입력하면 True 반환
        /// </summary>
        /// <returns></returns>
        private bool IsImageTextCorrect()
        {
            if (Page.User.Identity.IsAuthenticated)
            {
                return true;
            }
            else {
                if (Session["ImageText"] != null) {
                    return (txtImageText.Text == Session["ImageText"].ToString());
                }
            }
            return false;
        }


        // 파일 첨부 레이어 보이기/감추기
        protected void chkUpload_checkedChange(object sender, EventArgs e)
        {
            pnlFile.Visible = !pnlFile.Visible;

        }
    }
}