프로젝트명
---------
    Q&A 게시판 만들기 프로젝트 with APS.NET Web Form  
    

프로젝트 목적 & 동기
------------
    - 질의응답형 게시판을 만들어보자
    - Pagenation을 적용해보자
    - DB를 활용해보자
    - Utility class를 만들어 활용하자

실행
--------
    - DotNetNote > DeotNetNote > BoardList.aspx
    - DB 변경시 : Web.config -> connectionstring
    
화면 구성 & 사용방법
--------  
    - 게시글 목록 : 전체 게시글 목록, Pagenation 및 검색 기능 사용 가능.
<img src="https://user-images.githubusercontent.com/35621861/43362833-fc8fc3ae-932e-11e8-9c21-1ac7e1bf3cf7.PNG">    
    
    - 게시글 내용 : 작성자, 작성일자, ViewCount 등을 확인 가능. 작성자가 이미지를 첨부했다면 글 내용 상단에 노출
<img src="https://user-images.githubusercontent.com/35621861/43362841-234c8f22-932f-11e8-9519-5c36fd54443e.PNG">  
  
    - 글쓰기 : 작성 시 *Validation을 충족한 글만 작성이 허용된다.  
<img src="https://user-images.githubusercontent.com/35621861/43362851-59dcb260-932f-11e8-8575-430f99773229.PNG">  
  
    - 삭제 : 글 작성 시 입력했던 비밀번호가 일치하면 해당 글이 삭제된다.
<img src="https://user-images.githubusercontent.com/35621861/43362843-2b1dab46-932f-11e8-8c0f-366f8e96aae8.PNG">  

    - 수정 : 글 작성 시 입력했던 비밀번호를 입력 후 수정 가능
<img src="https://user-images.githubusercontent.com/35621861/43362844-310b950e-932f-11e8-81df-d3d9a3b37bb8.PNG">  
 
    - 답변 : 답변 글 작성 시 해당 글의 하단 부분에 목록 생성
<img src="https://user-images.githubusercontent.com/35621861/43362845-37567230-932f-11e8-8906-42c75cd57ac9.PNG">  
<img src="https://user-images.githubusercontent.com/35621861/43362846-3d035324-932f-11e8-9a23-9f66f44a1fb7.PNG">

    - 의견 남기기 : 자유롭게 의견을 달 수 있다.
<img src="https://user-images.githubusercontent.com/35621861/43362848-481a29ae-932f-11e8-91b5-453206c0d6be.PNG">  
<img src="https://user-images.githubusercontent.com/35621861/43362849-50aec778-932f-11e8-9ca7-68be8533b108.PNG">



개발 환경
--------
    - Visual Studio Community 2017
    - MS-SQL (local)
    - Back-end: ASP.NET WebForm, MS-SQL
    - Front-end: Html, Css, Javascript

주의사항 및 한계점
--------
    - 보안 및 인증 관련 모듈은 구현되어 있지 않습니다.
    - 아이디 생성 및 인증 절차 없이 누구나 글 작성 및 답변 가능
    - Web Form 기반이기 때문에 Post Back 발생
    
작성자 정보
----------
    - alsgkgk777@gmail.com

