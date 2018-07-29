using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dul
{
    public static class StringLibrary
    {
        /// <summary>
        /// 주어진 문자열을 앞의 3글자만 제외하고 자르기
        /// </summary>
        /// <param name="str"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string CutStringUnicode(this String str, int length)
        {
            string result = str;
            var si = new System.Globalization.StringInfo(str);
            var l = si.LengthInTextElements;

            if (l > (length - 3))
            {
                result = si.SubstringByTextElements(0, length - 3) + "...";
            }
            return result;
        }

        /// <summary>
        /// 이모티콘 등 유니코드가 포함된 문자열 자르기
        /// </summary>
        /// <param name="strCut"></param>
        /// <param name="intChar"></param>
        /// <returns></returns>
        public static string CutString(this string strCut, int intChar)
        {
            if (strCut.Length > (intChar - 3))
            {
                return strCut.Substring(0, intChar - 3) + "...";
            }
            return strCut;
        }
    }
}
