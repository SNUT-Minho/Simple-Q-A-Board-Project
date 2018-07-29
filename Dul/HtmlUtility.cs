using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dul
{
    public class HtmlUtility
    {

        # region EncodeWithTabAndSpace() 함수
        
        /// <summary>
        /// 주어진 문자열을 HTML 코드로 바꿈, 특히 탭이나 공백도 처리함. (바꿀 문자열)
        /// </summary>
        /// <param name="strContent"></param>
        /// <returns></returns>
        public static string EncodeWithTabAndSpace(string strContent) {

            string strTemp = "";
            if (strContent == null || strContent.Length == 0)
            {
                strTemp = "";
            }
            else {
                strTemp = strContent;
                strTemp = strTemp.Replace("&", "&amp;");
                strTemp = strTemp.Replace(">", "&gt;");
                strTemp = strTemp.Replace("<", "&lt;");
                strTemp = strTemp.Replace("\r\n", "<br>");
                strTemp = strTemp.Replace("\'", "&#34;");
                strTemp = strTemp.Replace("\t", "&nbsp;&nbsp;&nbsp;&nbsp;");
                strTemp = strTemp.Replace(" " + " ", "&nbsp;&nbsp;");
            }
            return strTemp;
        }
        #endregion


        #region Encode() 함수
        /// <summary>
        /// 주어진 문자열을 HTML 코드로 바꿈. (바꿀 문자열)
        /// 바꾸는 이유는 해당 태그가 실행되지않도록.
        /// </summary>
        /// <param name="strContent"></param>
        /// <returns></returns>
        public static string Encode(string strContent)
        {

            string strTemp = "";
            if (String.IsNullOrEmpty(strContent))
            {
                strTemp = "";
            }
            else
            {
                strTemp = strContent;
                strTemp = strTemp.Replace("&", "&amp;");
                strTemp = strTemp.Replace(">", "&gt;");
                strTemp = strTemp.Replace("<", "&lt;");
                strTemp = strTemp.Replace("\r\n", "<br>");
                strTemp = strTemp.Replace("\'", "&#34;");
            }
            return strTemp;
        }
        #endregion


        #region Decode() 함수
        /// <summary>
        /// 데이터베이스에 HTML 태그로 저장되어있는 데이터를 다시 Decode (Reply)
        /// 바꾸는 이유는 해당 태그가 다시 실행되도록
        /// </summary>
        /// <param name="strContent"></param>
        /// <returns></returns>
        public static string Decode(string strContent)
        {

            string strTemp = "";
            if (String.IsNullOrEmpty(strContent))
            {
                strTemp = "";
            }
            else
            {
                strTemp = strContent;
                strTemp = strTemp.Replace("&amp;", "&");
                strTemp = strTemp.Replace("&gt;", ">"); 
                strTemp = strTemp.Replace("&lt;", "<"); 
                strTemp = strTemp.Replace("<br>", "\r\n"); 
                strTemp = strTemp.Replace("&#34;", "\'"); 
            }
            return strTemp;
        }
        #endregion
    }
}
