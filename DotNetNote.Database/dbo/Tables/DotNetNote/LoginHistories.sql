CREATE TABLE [dbo].[LoginHistories]
(
	[Num] INT NOT NULL IdentitY(1,1) PRIMARY KEY,      
	UID Int Null,                                 -- 로그인 사용자의 UID 저장 : UserId로 저장해 놓으면 탈퇴한 아이디로 가입하면 이전 정보 연결
	UserID NVarChar(30) Null,
	UserName NVarChar(50) Null,
	LoginIP NVarChar(15) Null,
	LoginDate DateTime Null
)
