using DotNetNote.DotNetNote.Models;
using DotNetNote.Models;
using Dul;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNetNote.DotNetNote.Controls
{
    public partial class BoardEditorFormControl : System.Web.UI.UserControl
    {
        private string _Id; // 앞(리스트)에서 넘겨져 온 번 호 저장
        // 공통속성
        public BoardWriteFormType FormType { get; set; }
        public string TitleDescription { get; set; }

        private string _BaseDir = String.Empty; //파일 업로드 폴드
        private string _FileName = String.Empty; //파일명 저장 필드
        private int _FileSize = 0; //파일크기 저장 필드
        private object lblContent;

        protected void Page_Load(object sender, EventArgs e)
        {
            _Id = Request.QueryString["Id"];


            lblTitleDescription.Text = TitleDescription;

            if (!Page.IsPostBack)
            {
                switch (FormType)
                {
                    case BoardWriteFormType.Write:
                        lblTitleDescription.Text = "글 쓰기 - 아래 항목을 작성해주세요.";
                        break;

                    case BoardWriteFormType.Modify:
                        lblTitleDescription.Text = "글 수정 - 아래 항목을 수정해주세요.";
                        DisplayDataForModify();
                        break;

                    case BoardWriteFormType.Reply:
                        lblTitleDescription.Text = "글 답변 - 다음 필드들을 채워주세요.";
                        DisplayDataForReply();
                        break;

                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 수정용 데이터 상세
        /// </summary>
        private void DisplayDataForModify()
        {
            var note = (new NoteRepository().GetNoteById(Convert.ToInt32(_Id)));

            txtName.Text = note.Name;
            txtEmail.Text = note.Email;
            txtTitle.Text = note.Title;
            txtContent.Text = note.Content;

            // 인코딩 방식에 따른 라디오 버튼 선택
            string strEocoding = note.Encoding;
            if (strEocoding == "Text")
            {
                rdoEncoding.SelectedIndex = 0;
            }
            else if (strEocoding == "Mixed")
            {
                rdoEncoding.SelectedIndex = 2;
            }
            else
            {
                rdoEncoding.SelectedIndex = 1;
            }


            txtHomepage.Text = note.Homepage;
            
            // 첨부된 파일이 있는지 확인
            if (note.FileName.Length > 1)
            {
                Response.Write("여기!");
                ViewState["FileName"] = note.FileName;
                ViewState["FileSize"] = note.FileSize;

                lblFileNamePrevious.Visible = true; 
                lblFileNamePrevious.Text = $"기존 업로드 파일명 : {note.FileName}";
            }
            else
            {
                ViewState["FileName"] = "";
                ViewState["FileSize"] = 0;
            }
        }

        /// <summary>
        /// 답변 게시글에 Re 붙이기?
        /// </summary>
        private void DisplayDataForReply()
        {

            var note = (new NoteRepository().GetNoteById(Convert.ToInt32(_Id)));

            txtTitle.Text = $"re: {note.Title}";
            txtContent.Text = $"\n\nOn {note.PostDate}, '{note.Name}' wrote:\n-----------\n> {HtmlUtility.Decode(note.Content.Replace("\n", "\n>"))}\n----------";

            // 인코딩 방식에 따른 라디오 버튼 선택
            string strEocoding = note.Encoding;
            if (strEocoding == "Text")
            {
                rdoEncoding.SelectedIndex = 0;
            }
            else if (strEocoding == "Mixed")
            {
                rdoEncoding.SelectedIndex = 2;
            }
            else
            {
                rdoEncoding.SelectedIndex = 1;
            }
           
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
                note.Id = Convert.ToInt32(_Id);
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

                switch (FormType)
                {
                    case BoardWriteFormType.Write:
                        repo.Add(note);
                        Response.Redirect("BoardList.aspx");
                        break;

                    case BoardWriteFormType.Modify:
                      
                        note.ModifyIp = Request.UserHostAddress;
                        note.FileName = ViewState["FileName"].ToString();
                        note.FileSize = Convert.ToInt32(ViewState["FileSize"]);
                        int result = repo.UpdateNote(note);
                       
                        // 업데이트 성공
                        if (result > 0)
                        {
                            Response.Redirect($"BoardView.aspx?Id={_Id}&ANum={Request["ANum"]}");
                        }
                        else
                        {
                            lblError.Text = "암호를 확인하세요.";
                        }
                      
                        break;

                    case BoardWriteFormType.Reply:
                        note.ParentNum = Convert.ToInt32(_Id);
                        repo.ReplyNote(note);
                        Response.Redirect("BoardList.aspx");
                        break;

                    default:
                        repo.Add(note);
                        Response.Redirect("BoardList.aspx");
                        break;
                }
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
            if (txtFileName.PostedFile != null)
            {
                if (txtFileName.PostedFile.FileName.Trim().Length > 0 && txtFileName.PostedFile.ContentLength > 0)
                {
                    if(FormType == BoardWriteFormType.Modify)
                    {
                        ViewState["FileName"] = Dul.FileUtility.GetFileNameWithNumbering(_BaseDir, Path.GetFileName(txtFileName.PostedFile.FileName));
                        ViewState["FileSize"] = txtFileName.PostedFile.ContentLength;
                        // 업로드 처리 : SaveAs()
                        txtFileName.PostedFile.SaveAs(Path.Combine(_BaseDir, ViewState["FileName"].ToString()));
                    }
                    else // BoardWrite, BoardReply
                    {
                        _FileName = Dul.FileUtility.GetFileNameWithNumbering(_BaseDir, Path.GetFileName(txtFileName.PostedFile.FileName));
                        _FileSize = txtFileName.PostedFile.ContentLength;
                        // 업로드 처리 : SaveAs()
                        txtFileName.PostedFile.SaveAs(Path.Combine(_BaseDir, _FileName));
                    }
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
            else
            {
                if (Session["ImageText"] != null)
                {
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