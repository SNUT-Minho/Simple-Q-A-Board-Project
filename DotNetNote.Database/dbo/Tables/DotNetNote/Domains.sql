CREATE TABLE [dbo].[Domains]
(
	[UID] INT NOT NULL Identity(1,1) PRIMARY KEY,            -- 일련번호
	DomainID NVarChar(30) NOT Null,                              -- 아이디/그룹아이디(UserId)
	Name NVarChar(50) NOT Null,                                  -- 이름/그룹명/닉네임
	Type NVarChar(10) NOT Null,                                  -- User/Group, 나중에 Type을 DomainType으로 바꿀것
	Description NVarChar(255) Null,                          -- 설명(소개)

	CreatedDate DateTime Default(GetDate())                  -- 가입일(계정 등록일)
)
