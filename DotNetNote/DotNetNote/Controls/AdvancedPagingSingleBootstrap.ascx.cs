using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNetNote.DotNetNote
{


    public partial class AdvancedPagingSingleBootstrap : System.Web.UI.UserControl
    {
        // 공통 속성 : 검색 모드이면 true
        public bool SearchMode { get; set; } = false; // 기본 Search 모드는 false
        public string SearchField { get; set; }
        public string SearchQuery { get; set; }


        // 몇번째 페이지를 보여줄 건지 : 웹 폼에서 전달됨
        private int _PageIndex;

        public int PageIndex
        {
            get { return _PageIndex; }
            set { _PageIndex = value; }
        }


        // 총 몇개의 페이지가 만들어지는지 : 총 레코드 수 /10 (한페이지에서 보여줄)
        private int _PageCount;

        public int PageCount
        {
            get { return _PageCount; }
            set { _PageCount = value; }
        }


        // 페이지 사이즈: 한 페이지에 몇개의 레코드를 보여줄 건지
        private int _PageSize;

        public int PageSize
        {
            get { return _PageSize; }
            set { _PageSize = value; }
        }


        // 레코드 카운트 : 현재 테이블에 몇개의 레코드가 있는지 지정
        private int _RecordCount;

        public int RecordCount
        {
            get { return _RecordCount; }
            set
            {
                _RecordCount = value;
                PageCount = ((_RecordCount - 1) / _PageSize) + 1; // 계산식
            }
        }

        public AdvancedPagingSingleBootstrap()
        {
            _PageSize = 10; // 페이지 사이즈는 기본값이 10
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            // 검색 모드 결정 
            SearchMode = (!string.IsNullOrEmpty(Request.QueryString["SearchField"]) && !string.IsNullOrEmpty(Request.QueryString["SearchQuery"]));
            if (SearchMode)
            {
                SearchField = Request.QueryString["SearchField"].Replace("--", "");  // SQL Injection 대비용
                SearchQuery = Request.QueryString["SearchQuery"].Replace("--", "");  // 꼭 보안 함수로 묵을 것
            }

            AdvancedPaging(PageIndex, PageCount);
        }

        private void AdvancedPaging(int PageNo, int NumPage)
        {
            ++PageNo;
            int i = 0;

            // 이전 10개, 다음 10개 페이징 처리시작
            string strPage = "<ul class='pagination pagination-sm'>";
            if (PageNo > 10)
            {
                if (!SearchMode)
                {
                    strPage += "<li><a href=\"" + Request.ServerVariables["SCRIPT_NAME"] + "?BoardName=" + Request["BoardName"] + "&Page=" + Convert.ToString(((PageNo - 1) / (int)10) * 10) + "\">◁</a></li>";
                }
                else
                {
                    strPage += "<li><a href=\"" + Request.ServerVariables["SCRIPT_NAME"] + "?BoardName=" + Request["BoardName"] + "&Page=" + Convert.ToString(((PageNo - 1) / (int)10) * 10) + "&SearchField=" + SearchField + "&SearchQuery=" + SearchQuery + "\">◁</a></li>";
                }
            }
            else
            {
                strPage += "<li class='disabled'><a>◁</a></li>";

            }

            for (i = (((PageNo - 1) / (int)10) * 10 + 1); i <= ((((PageNo - 1) / (int)10) + 1) * 10); i++)
            {
                if (i > NumPage)
                {

                    break;
                }
                if (i == PageNo)
                {

                    strPage += "<li class='active'><a href='#'>" + i.ToString() + "</a></li>";
                }
                else
                {
                    if (!SearchMode)
                    {
                        strPage += "<li><a href=\"" + Request.ServerVariables["SCRIPT_NAME"] + "?BoardName" + Request["BoardName"] + "&Page=" + i.ToString() + "\">" + i.ToString() + "</a></li>";
                    }
                    else
                    {
                        strPage += "<li><a href=\"" + Request.ServerVariables["SCRIPT_NAME"] + "?BoardName" + Request["BoardName"] + "&Page=" + i.ToString() + "&SearchField=" + SearchField + "&SearchQuery=" + SearchQuery + "\">" + i.ToString() + "</a></li>";
                    }
                }
            }

            if (i < NumPage)
            {
                if (!SearchMode)
                {
                    strPage += "<li><a href=\"" + Request.ServerVariables["SCRIPT_NAME"] + "?BoardName" + Request["BoardName"] + "&Page=" + Convert.ToString(((PageNo - 1) / (int)10) * 10 + 11) + "\">▷</a></li>";
                }
                else
                {
                    strPage += "<li><a href=\"" + Request.ServerVariables["SCRIPT_NAME"] + "?BoardName" + Request["BoardName"] + "&Page=" + Convert.ToString(((PageNo - 1) / (int)10) * 10 + 11) + "&SearchField=" + SearchField + "&SearchQuery=" + SearchQuery + "\">▷</a></li>";
                }
            }
            else
            {
                strPage += "<li class='disabled'><a>▷</a></li>";
            }

            // 이전 10개, 다음 10개 페이징 처리 종료
            strPage += "</ul>";

            ctlAdvancedPagingWithBootstrapList.Text = strPage;
        }
    }
}