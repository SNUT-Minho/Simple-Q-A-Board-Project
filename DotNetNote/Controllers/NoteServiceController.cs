using DotNetNote.DotNetNote.Models;
using DotNetNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DotNetNote.Controllers
{
    public class NoteServiceController : ApiController
    {
        NoteRepository _repository = new NoteRepository();


        // 최근 글 10개 출력 API  
        // localhost/api/NoteService?page=1 이런식으로 사용하면 해당 데이터가 출력됨
        // 데이터 출력 API, JSON 데이터로 전송됨
        // GET: api/NoteService
        public IEnumerable<Note> Get()
        {
            return _repository.GetAll(0).AsEnumerable();
        }



        // localhost/api/NoteService?page=1 이런식으로 사용하면 해당 데이터가 출력됨
        // 데이터 출력 API, JSON 데이터로 전송됨
        // GET: api/NoteService
        public IEnumerable<Note> Get(int page)
        {
            return _repository.GetAll(page).AsEnumerable();
        }  

        // POST: api/NoteService
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/NoteService/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/NoteService/5
        public void Delete(int id)
        {
        }
    }
}
