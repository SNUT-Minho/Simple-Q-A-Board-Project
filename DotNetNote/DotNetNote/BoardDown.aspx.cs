using DotNetNote.DotNetNote.Models;
using System;

namespace DotNetNote.DotNetNote
{
    public partial class BoardDown : System.Web.UI.Page
    {
        private string strFileName = "";
        private string strBaseDir = "";
        private NoteRepository _repository = new NoteRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            // 넘겨져 온 번호에 해당하는 파일명 가져오기(보안때문에... 파일명 숨김)
            strFileName = _repository.GetFileNameById(Convert.ToInt32(Request["Id"]));

            // 다운로드 폴더 지정 : 실제 사용시 반드시 변경
            strBaseDir = Server.MapPath("./MyFiles/");
    

            if (strFileName == null)
            {
                Response.Redirect("./BoardList.aspx");
            }
            else
            {
                // 다운 카운트 증가 메서드  호출
                _repository.UpdateDownCount(strFileName);

                // 강제 다운로드 창 띄우기 주요 로직
                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment;filename="
                    + Server.UrlPathEncode(((strFileName.Length > 50) ? strFileName.Substring(strFileName.Length - 50, 50) : strFileName)));
                Response.WriteFile(strBaseDir + strFileName);
                Response.End();
            }
        }
    }
}