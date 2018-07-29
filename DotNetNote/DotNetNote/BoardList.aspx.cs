using DotNetNote.DotNetNote.Models;
using System;
using System.Web.UI;

namespace DotNetNote.DotNetNote
{
    public partial class BoardList : System.Web.UI.Page
    {
        // 공통 속성 : 검색 모드이면 true
        public bool SearchMode { get; set; } = false; // 기본 Search 모드는 false
        public string SearchField { get; set; }
        public string SearchQuery { get; set; }

        public int intPage = 0; // 현재 보여줄 페이지
        public int intTotalCount = 0; // 전체 레코드 개수

        private NoteRepository _repository = new NoteRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            // 검색 모드 결정 
            SearchMode = (!string.IsNullOrEmpty(Request.QueryString["SearchField"]) && !string.IsNullOrEmpty(Request.QueryString["SearchQuery"]));
  
            if (SearchMode)
            {
                SearchField = Request.QueryString["SearchField"].Replace("--", "");  // SQL Injection 대비용
                SearchQuery = Request.QueryString["SearchQuery"].Replace("--", "");  // 꼭 보안 함수로 묵을 것
            }

            //[!] 쿼리스트링에 따른 페이지 보여주기
            if (Request.QueryString["Page"] != null)
            {
                intPage = Convert.ToInt32(Request["Page"]) - 1; // 페이지는 보여지는 쪽은 1, 2, 3 --- 코드 index는 0, 1, 2---
            }

            // 쿠키를 사용한 리스트 페이지 번호 유지 적용 : 100번째 페이지 보고 있다가 다시 리스트 왔을 때 100번째 페이지 표시
            if (Request.Cookies["DotNetNote"] != null)
            {
                if (!String.IsNullOrEmpty(Request.Cookies["DotNetNote"]["PageNum"]))
                {
                    intPage = Convert.ToInt32(Request.Cookies["DotNetNote"]["PageNum"]);
                }
                else
                {
                    intPage = 0;
                }
            }
            if (!SearchMode)
            {
                intTotalCount = _repository.GetCount();
            }
            else
            {
                intTotalCount = _repository.GetCountBySearch(SearchField,SearchQuery);
            }

            // 레코드 수 출력
            lblTotalRecord.Text = intTotalCount.ToString();
            
            //페이징 처리
            AdvancedPagingSingleBootstrap.PageIndex = intPage;
            AdvancedPagingSingleBootstrap.RecordCount = intTotalCount;

            // GriView 데이터 출력
            if (!Page.IsPostBack)
            {
                DisplayData();
            }
        }

        private void DisplayData()
        {
            if (!SearchMode) // 기본 전체 리스트
            {
                this.ctlBoardList.DataSource = _repository.GetAll(intPage);
            }
            else // 검색 결과 리스트
            {
                this.ctlBoardList.DataSource = _repository.GetSearchAll(intPage, SearchField, SearchQuery);
            }

            this.ctlBoardList.DataBind();
        }



    }
}