-- 회원에 대한 역할(Role)/ 그릅권한 처리
CREATE TABLE [dbo].[Membership] -- UserInRoles 테이블명 변경 가능
(
	UserUID Int Default(0), -- Domains의 레코드 중 Type = 'User'
	[GroupUID] Int Default(0), -- Domains의 레코드 주 Type = 'Group'
	Primary Key(UserUID,[GroupUID])
)
Go