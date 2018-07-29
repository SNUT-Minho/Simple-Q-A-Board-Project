-- 회원 기타 정보, 회원 (Users) = Domains + UserProfiles
CREATE TABLE [dbo].[UserProfiles]
(
	Id	Int Identity(1,1) Primary Key Not Null,
	UID Int Not Null,                   -- Domains 테이블 UID값
	Password NVarChar(50) Null,         -- 암호
	Email NVarChar(100) Null,           -- 이메일
	LastLoginDate DateTime Null,        -- 마지막 로그인 시간
	LastLoginIP NVarChar(16) Null,      -- 마지막 로그인 IP
	VisitedCount Int Default(0),        -- 방문 횟수
	Blocked Bit Default(0),             -- 계정 사용 안함: 계정 사용(0), 게정 잠금(1)

	-- 기타 필요 정보 이쓰면 사용자가 더 추가
	-- ZipCode
	-- Address
	-- PhoneNumber

	PhoneNumber NVarChar(30) Null,
	Address NVarChar(140) Null,
	Gender NVarChar(5) Null,
	BirthDate NVarChar(12) Null,
	Country NVarChar(30) Null

	-- 추가..
)
Go