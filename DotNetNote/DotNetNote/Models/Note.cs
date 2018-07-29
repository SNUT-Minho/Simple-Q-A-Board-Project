using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetNote.Models
{
    /// <summary>
    /// Note 테이블과 1:1로 매핑되는 ViewModel클래스
    /// </summary>
    public class Note
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public DateTime PostDate { get; set; }
        public string PostIp { get; set; }
        public string Content { get; set; }
        public string Password { get; set; }
        public int ReadCount { get; set; }
        public string Encoding { get; set; }
        public string Homepage { get; set; }
        public DateTime ModifyDate { get; set; }
        public string ModifyIp { get; set; }
        public string FileName { get; set; }
        public int FileSize { get; set; }
        public int DownCount { get; set; }
        public int Ref { get; set; }
        public int Step { get; set; }
        public int RefOrder { get; set; }
        public int AnswerNum { get; set; }
        public int ParentNum { get; set; }
        public int CommentCount { get; set; }
        public string Category { get; set; }

        
    }
}