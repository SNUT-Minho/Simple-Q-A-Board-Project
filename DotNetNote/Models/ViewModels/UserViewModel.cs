using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace DotNetNote.Models
{
    public class UserViewModel
    {

        public UserViewModel()
        {
            //Empty
        }

        public UserViewModel(int uid)
        {
            this.UID = uid;
        }

        // 기본 속성들 : 필수
        public int UID { get; set; }    // Auto Implemented Properties
        public string DomainID { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime LastLoginDate { get; set; }
        public string LastLoginIP { get; set; }
        public int VisitiedCount { get; set; }
        public string Description { get; set; }
        public bool Blocked { get; set; }
        public string DomainType { get; set; }  // SQL: TYPE 필드, C#: DomainType 속성

        // 추가 속성들 : 옵션
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string BirthDate { get; set; }
        public string Country { get; set; }

        public string DisplayName
        {
            get
            {
                return $"{DomainID}({Name})";
            }
        }

        /// <summary>
        /// UserID에 대한 유효성 검사 : 잘못된 문자열 입력 방지
        /// </summary>
        /// <param name="strUserID"></param>
        /// <returns> 사용 가능(true), 사용 불가(false)</returns>
        public static Boolean ValidUserID(string strUserID)
        {
            string[] arrChar = { @"\", @"/", ":", "?", "*", "" + (char)34, "<", ">", "|", " ", "'", "%", "&", "+" };
            bool blnTemp = true;
            foreach (string s in arrChar)
            {
                if (strUserID.IndexOf(s) != -1)
                {
                    blnTemp = false;
                }
            }
            return blnTemp;
        }

        public Boolean ValidateEmail()
        {
            var valid = true;

            if (String.IsNullOrWhiteSpace(this.Email))
            {
                valid = false;
            }

            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            valid = regex.IsMatch(this.Email);

            var isRealDomain = true;

            if (!isRealDomain)
            {
                valid = false;
            }

            return valid;
        }
    }
}