using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetNote.DotNetNote.Models
{
    /// <summary>
    /// 코멘트(댓글) 뷰 모델
    /// </summary>
    public class NoteComment
    {
        public int Id { get; set; }
        public string BoardName { get; set; }
        public int BoardId { get; set; }
        public string Name { get; set; }
        public string Opinion { get; set; }
        public DateTime PostDate { get; set; }
        public string Password { get; set; }
    }
}