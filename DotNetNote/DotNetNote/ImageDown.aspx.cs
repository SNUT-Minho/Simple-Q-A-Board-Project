using System;
using System.IO;

namespace DotNetNote.DotNetNote
{
    /// <summary>
    /// 게시판의 이미지 전용 다운 페이지
    /// </summary>
    public partial class ImageDown : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.Params["FileName"])) {
                Response.End();
            }

            string strFileName = Request.Params["FileName"].ToString();
            string strFileExt = Path.GetExtension(strFileName);
            string strContentType = "";
            if (strFileExt == ".gif" || strFileExt == ".jpg" || strFileExt == ".jpeg" || strFileExt == ".png") {
                switch (strFileExt)
                {
                    case ".gif":
                        strContentType = "image/gif";
                           break;

                    case ".jpg":
                        strContentType = "image/jpg";
                        break;

                    case ".jpeg":
                        strContentType = "image/jpeg";
                        break;

                    case ".png":
                        strContentType = "image/png";
                        break;

                    default:
                        break;
                }
            }
            else
            {
                Response.Write(
                   "<script language='javascript'> alert('이미지 파일이 아닙니다.')</script>"
                    );
            }
            string strFilePath = Server.MapPath("./MyFiles/") + strFileName;

            // 강제 다운로드 로직 적용
            Response.Clear();
            Response.ContentType = strContentType;
            Response.WriteFile(strFilePath);
            Response.End();
        }
    }
}