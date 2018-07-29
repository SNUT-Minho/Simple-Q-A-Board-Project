using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNetNote.DotNetNote
{
    public partial class ThumbNail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 변수 초기화
            int boxWidth = 100;
            int boxHeight = 100;
            double scale = 0;

            // 파일 이름을 설정
            string strFileName = String.Empty;
            string strSelectedFile = String.Empty;

            if(Request["FileName"] != null)
            {
                strSelectedFile = Request.QueryString["FileName"];
                strFileName = Server.MapPath("./MyFiles/" + strSelectedFile);
            }
            else
            {
                strSelectedFile = "./images/re.jpg"; //기본 이미지로 초기화
                strFileName = Server.MapPath("./images/re.jpg");
            }

            int tmpW = 0;
            int tmpH = 0;

            if (Request.QueryString["Width"] != null && Request.QueryString["Height"] != null) {
                tmpW = Convert.ToInt32(Request.QueryString["Width"]);
                tmpH = Convert.ToInt32(Request.QueryString["Height"]);
            }
            
            if(tmpW >0 && tmpH > 0)
            {
                boxWidth = tmpW;
                boxHeight = tmpH;
            }

            // 새 이미지 생성
            Bitmap b = new Bitmap(strFileName);

            // 크기 비율을 계산한다
            if(b.Height < b.Width)
            {
                scale = ((double)boxHeight) / b.Width;
            }
            else
            {
                scale = ((double)boxWidth) / b.Height;
            }

            // 새 너비와 높이를 설정한다.
            int newWidth = (int)(scale * b.Width);
            int newHeight = (int)(scale * b.Height);

            // 출력 비트맵을 생성, 출력한다.
            Bitmap bOut = new Bitmap(b, newWidth, newHeight);
            bOut.Save(Response.OutputStream, b.RawFormat);

            // 마무리
            b.Dispose();
            bOut.Dispose();
        }
    }
}