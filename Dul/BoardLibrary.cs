using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dul
{
    public class BoardLibrary
    {

        #region 각 글의 Step별 들여쓰기 처리
        /// <summary>
        /// 각 글의 Step별 들여쓰기 처리
        /// </summary>
        /// <param name="objStep">1, 2, 3</param>
        /// <returns>Re 이미지를 포함한 Step만큼 들여쓰기</returns>
        public static string FuncStep(object objStep)
        {
            int intStep = Convert.ToInt32(objStep);
            string strTemp = String.Empty;
            if (intStep == 0)
            {

            }
            else
            {
                for (int i = 0; i < intStep; i++)
                {
                    strTemp += "&nbsp;&nbsp;"; 
                }
                strTemp += "→ ";
            }
            return strTemp;
        }
        #endregion


        #region 코멘트의 갯수를 표시
        /// <summary>
        /// 코멘트 갯수를 표현하는 메서드
        /// </summary>
        /// <param name="objCommentCount">코멘트 수</param>
        /// <returns>코멘트 이미지와 함께 숫자 표시</returns>
        public static string ShowCommentCount(object objCommentCount)
        {
            string strTemp = "";
            try
            {
                if (Convert.ToInt32(objCommentCount) > 0)
                {

                    strTemp += $"<span style=\"font-size:13px;\">[{objCommentCount.ToString()}]</span>";
                }
            }
            catch (Exception)
            {
                strTemp = "";
            }
            return strTemp;
        }
        #endregion

        #region 24시간내에 올라온 글 new 이미지 표시하기
        /// <summary>
        /// 24시간내에 올라온 글 new 이미지 표시하기
        /// </summary>
        /// <param name="strDate"></param>
        /// <returns></returns>

        public static string FuncNew(object strDate)
        {
            if (strDate != null)
            {
                if (!String.IsNullOrEmpty(strDate.ToString()))
                {
                    DateTime originDate = Convert.ToDateTime(strDate);

                    TimeSpan objTs = DateTime.Now - originDate;
                    string newImage = "";
                    if (objTs.TotalMinutes < 1440)
                    {
                        newImage = "<span class=\"label label-danger\" style=\"font-size:70%; height: auto; width: 2px; margin-bottom:2px;  padding:0 0 0 0 ;\" >new</span>";
                    }
                    return newImage;
                }
            }
            return "";
        }


        #endregion

        #region 파일 다운로드
        /// <summary>
        /// 파일 다운로드
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string DownLoadFile(String fileName)
        {
            string strTemp = "";
            if (fileName != null)
            {
                if (!String.IsNullOrEmpty(fileName))
                {
                    strTemp = "<span class=\"glyphicon glyphicon-download-alt\" aria-hidden=\"true\"></span>";
                }
                else
                {
                    strTemp = "";
                }
            }
            return strTemp;
        }
        #endregion

        #region 넘겨온 날짜 형식이 오늘 날짜면 시간 표시
        /// <summary>
        /// 넘겨온 날짜 형식이 오늘 날짜면 시간 표시, 
        /// 그렇지않으면 날짜표시
        /// </summary>
        public static string FuncShowTime(object date)
        {
            if (date != null)
            {
                if (!String.IsNullOrEmpty(date.ToString()))
                {
                    string strPostDate =
                      Convert.ToDateTime(date).ToString("yyyy-MM-dd");
                    if (strPostDate == DateTime.Now.ToString("yyyy-MM-dd"))
                    {
                        return Convert.ToDateTime(date).ToString("tt hh:mm:ss");
                    }
                    else
                    {
                        return strPostDate;
                    }
                }
            }
            return "-";
        }
        #endregion


        #region IsPhoto() 함수
        /// <summary>
        /// 첨부된 파일이 이미지 파일인지 검사
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool IsPhoto(string fileName)
        {
            string strFileExt = Path.GetExtension(fileName).Replace(".", "").ToLower();
            bool blnResult = false;
            if (strFileExt == "gif" || strFileExt == "jpg" || strFileExt == "jpeg" || strFileExt == "png")
            {
                blnResult = true;
            }
            else
            {
                blnResult = false;
            }
            return blnResult;
            #endregion
        }
    }
}
