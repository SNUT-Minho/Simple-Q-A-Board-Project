--[!] 예시문 :  필수 데이터 입력

Set Identity_Insert Domains On
Go

--[1] 빌트인(BuiltIn) 그룹 권한(역할(Role)) 부여 : Administrators, Everyone, Users, Guests
Insert Domains (UID, DomainID, Name, Type, Description) Select 1, 'Administrators', N'관리자 그룹', 'Group', N'응용 프로그램을 총 관리하는 관리 그룹 계정'
Where Not Exists (Select * from dbo.Domains Where UID = 1)
GO


Insert Domains (UID, DomainID, Name, Type, Description)
Select 2, 'Everyone', N'전체 사용자 그룹', 'Group', N'응용 프로그램을 사용하는 모든 사용자 그룹 계정'
Where Not Exists (Select * from dbo.Domains Where UID = 2)
Go

Insert Domains (UID, DomainID, Name, Type, Description)
Select 3, 'Users', N'일반 사용자 그룹', 'Group', N'일반 사용자 그룹 계정'
Where Not Exists (Select * from dbo.Domains Where UID = 3)
Go

Insert Domains (UID, DomainID, Name, Type, Description)
Select 4,'Guests', N'관리자  그룹', 'Group', N'게스트 사용자 그룹 계정'
Where Not Exists (Select * from dbo.Domains Where UID = 4)
Go

--[2] 빌트인(BuiltIn) 관리용 사용자 입력 : Administrators, Guests, Anonymous
Insert Domains (UID, DomainID, Name, Type, Description)
Select 5,'Administrators', N'관리자', 'User', N'응용 프로그램을 총 관리하는 사용자 계정'
Where Not Exists (Select * from dbo.Domains Where UID = 5)
Go

Insert Domains (UID, DomainID, Name, Type, Description)
Select 6,'Guest', N'게스트 사용자', 'User', N'게스트 사용자 계정'
Where Not Exists (Select * from dbo.Domains Where UID = 6)
Go

Insert Domains (UID, DomainID, Name, Type, Description)
Select 7,N'Anonymous', N'익명 사용자', 'User', N'익명 사용자 계정'
Where Not Exists (Select * from dbo.Domains Where UID = 7)
Go

Set Identity_Insert Domains Off
Go