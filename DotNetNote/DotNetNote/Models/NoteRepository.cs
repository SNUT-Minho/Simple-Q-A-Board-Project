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
    /// <summary>
    /// Repository 클래스는 특정 테이블에 대한 CRUD를 모아놓은 클래스
    /// </summary>
    public class NoteRepository
    {
        private SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        public void Add(Note model)
        {
            // 파라미터 추가
            var parameters = new DynamicParameters();
            parameters.Add("@Name",     value: model.Name	,   dbType: DbType.String);
            parameters.Add("@Email",    value: model.Email	,   dbType: DbType.String);
            parameters.Add("@Title",    value: model.Title	,   dbType: DbType.String);
            parameters.Add("@PostIp",   value: model.PostIp	,   dbType: DbType.String);
            parameters.Add("@Content",  value: model.Content,   dbType: DbType.String);
            parameters.Add("@Password", value: model.Password,  dbType: DbType.String);
            parameters.Add("@Encoding", value: model.Encoding,  dbType: DbType.String);
            parameters.Add("@Homepage", value: model.Homepage,  dbType: DbType.String);
            parameters.Add("@FileName", value: model.FileName,  dbType: DbType.String);
            parameters.Add("@FileSize", value: model.FileSize,  dbType: DbType.Int32);

            con.Execute("WriteNote", parameters, commandType: CommandType.StoredProcedure);
        }

     

        /// <summary>
        /// 전체 리스트 출력
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public List<Note> GetAll(int page) {

            var parameters = new DynamicParameters(new { Page = page});
            return con.Query<Note>("ListNotes",parameters, commandType: CommandType.StoredProcedure).ToList();
        }

        /// <summary>
        /// 검색 카운트
        /// </summary>
        /// <param name="searchField"></param>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        internal int GetCountBySearch(string searchField, string searchQuery)
        {
            return con.Query<int>("SearchNoteCount", new { SearchField = searchField, searchQuery = searchQuery }, commandType: CommandType.StoredProcedure).SingleOrDefault();
        }

        /// <summary>
        /// Notes 테이블의 모든 레코드 수
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public int GetCount()
        {
            return con.Query<int>("Select Count(*) From Notes").SingleOrDefault();
        }



        public object GetSearchAll(int page, string searchField, string searchQuery)
        {
            var parameters = new DynamicParameters(new { Page = page, searchField = searchField, SearchQuery = searchQuery });
            return con.Query<Note>("SearchNotes", parameters, commandType: CommandType.StoredProcedure).ToList();
        }


        /// <summary>
        /// 상세 보기
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Note GetNoteById(int id)
        {
            var parameters = new DynamicParameters(new { Id = id });
            return con.Query<Note>("ViewNote", parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
        }

        public int DeleteNote(int id, string password)
        {
           return con.Execute("DeleteNote", new { Id = id, Password = password }, commandType: CommandType.StoredProcedure);
        }

        /// <summary>
        /// Id에 해당하는 파일명 반환
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetFileNameById(int id)
        {
            return con.Query<string>("Select FileName From Notes Where Id = @Id", new { Id = id }).SingleOrDefault();
        }

        /// <summary>
        /// 다운 카운트 1 증가
        /// </summary>
        /// <param name="fileName"></param>
        public void UpdateDownCount(string fileName)
        {
             con.Execute("Update Notes Set DownCount = DownCount +1 Where FileName = @FileName", new { FileName = fileName });
        }


        /// <summary>
        /// 데이터 수정
        /// </summary>
        /// <param name="model"></param>
        public int UpdateNote(Note model)
        {
            // 파라미터 추가
            var parameters = new DynamicParameters();
            parameters.Add("@Name", value: model.Name, dbType: DbType.String);
            parameters.Add("@Email", value: model.Email, dbType: DbType.String);
            parameters.Add("@Title", value: model.Title, dbType: DbType.String);
            parameters.Add("@ModifyIp", value: model.ModifyIp, dbType: DbType.String);
            parameters.Add("@Content", value: model.Content, dbType: DbType.String);
            parameters.Add("@Password", value: model.Password, dbType: DbType.String);
            parameters.Add("@Encoding", value: model.Encoding, dbType: DbType.String);
            parameters.Add("@Homepage", value: model.Homepage, dbType: DbType.String);
            parameters.Add("@FileName", value: model.FileName, dbType: DbType.String);
            parameters.Add("@FileSize", value: model.FileSize, dbType: DbType.Int32);
            parameters.Add("@Id", value: model.Id, dbType: DbType.Int32);

            return con.Execute("ModifyNote", parameters, commandType: CommandType.StoredProcedure);
        }


        public void ReplyNote(Note model)
        {
            // 파라미터 추가
            var parameters = new DynamicParameters();
            parameters.Add("@Name", value: model.Name, dbType: DbType.String);
            parameters.Add("@Email", value: model.Email, dbType: DbType.String);
            parameters.Add("@Title", value: model.Title, dbType: DbType.String);
            parameters.Add("@PostIp", value: model.PostIp, dbType: DbType.String);
            parameters.Add("@Content", value: model.Content, dbType: DbType.String);
            parameters.Add("@Password", value: model.Password, dbType: DbType.String);
            parameters.Add("@Encoding", value: model.Encoding, dbType: DbType.String);
            parameters.Add("@Homepage", value: model.Homepage, dbType: DbType.String);
            parameters.Add("@FileName", value: model.FileName, dbType: DbType.String);
            parameters.Add("@FileSize", value: model.FileSize, dbType: DbType.Int32);
            parameters.Add("@ParentNum", value: model.ParentNum, dbType: DbType.Int32);

            con.Execute("ReplyNote", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}