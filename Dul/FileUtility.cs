using System.IO;

/// <summary>
/// Devlopment Utility Library
/// </summary>
namespace Dul
{
    public class FileUtility
    {
        #region
        /// <summary>
        /// GetFilePath :  파일명 뒤에 번호 붙이는 메서드
        /// </summary>
        /// <param name="strBaseDirTemp">경로(c:\MyFiles)</param>
        /// <param name="strFileNameTemp">Text.txt</param>
        /// <returns></returns>
        public static string GetFileNameWithNumbering(string strBaseDirTemp, string strFileNameTemp)
        {
            string strName = Path.GetFileNameWithoutExtension(strFileNameTemp); // 순수 파일명 : Test
            string strExt = Path.GetExtension(strFileNameTemp);
            bool blnExists = true;
            int i = 0;
            while (blnExists)
            {
                //Path.Combine(경로, 파일명) = 경로+파일명
                if (File.Exists(Path.Combine(strBaseDirTemp, strFileNameTemp)))
                {
                    strFileNameTemp = strName + "(" + ++i + ")" + strExt; // Test(3).txt
                }
                else
                {
                    blnExists = false;
                }
            }
            return strFileNameTemp;
        }
        #endregion
    }
}
