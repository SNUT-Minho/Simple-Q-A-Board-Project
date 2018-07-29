using DotNetNote.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using System.Data;

namespace DotNetNote.DotNetNote.Models
{
    public class NoteCommentRepository
    {
        private SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        /// <summary>
        /// 특정 게시물에 코멘트 추가
        /// </summary>
        /// <param name="model"></param>
        public void AddNoteComment(NoteComment model)
        {
            // 파라미터 추가
            var parameters = new DynamicParameters();
            parameters.Add("@BoardId", value: model.BoardId, dbType: DbType.Int32);
            parameters.Add("@Name", value: model.Name, dbType: DbType.String);
            parameters.Add("@Opinion", value: model.Opinion, dbType: DbType.String);
            parameters.Add("@Password", value: model.Password, dbType: DbType.String);

            // 데이터 삽입 후 부모글에 코멘트 수 +1
            string sql = "Insert Into NoteComments(BoardId, Name, Opinion, Password) values(@BoardId, @Name, @Opinion, @Password)";
            sql += "Update Notes Set CommentCount = CommentCount +1  Where Id = @BoardId";
            con.Execute(sql, parameters, commandType: CommandType.Text);
        }


        /// <summary>
        /// 특정 게시물에 해당하는 코멘트 리스트
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public List<NoteComment> GetNoteComments(int boardId)
        {
            return con.Query<NoteComment>("Select * From NoteComments Where BoardId = @BoardId",new { BoardId = boardId }, commandType: CommandType.Text).ToList();
        }

        /// <summary>
        /// 특정 게시물의 특정 Id에 해당하는 코멘트 카운트
        /// </summary>
        /// <param name="searchField"></param>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        internal int GetCountBy(int boardId, int id, string password)
        {
            return con.Query<int>("Select Count(*) From NoteComments Where BoardId = @BoardId And Id = @Id And Password = @Password",
                new {BoardId = boardId, Id = id, Password = password}
                ,commandType: CommandType.Text).SingleOrDefault();
        }      

        /// <summary>
        /// 코멘트삭제
        /// </summary>
        /// <param name="id"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int DeleteComment(int boardId, int id, string password)
        {
            return con.Execute("Delete NoteComments Where BoardId = @BoardId And Id = @Id And Password = @Password;" +
                "Update Notes Set CommentCount = CommentCount - 1  Where Id = @BoardId",
                 new { BoardId = boardId, Id = id, Password = password },commandType: CommandType.Text);
        }
    }
}
