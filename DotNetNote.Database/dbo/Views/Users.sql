﻿
--[2] 사용자 리스트: Users 뷰
-- /Models/User.cs
-- /ViewModels/UserViewModel.cs

Create View dbo.Users
AS
	Select
		Domains.UID As UID,
		Domains.DomainID As DomainID,
		Domains.Name As Name,
		Domains.CreatedDate As CreatedDate,
		UserProfiles.Password As Password,
		UserProfiles.Email As Email,
		UserProfiles.LastLoginDate As LastLoginDate,
		UserProfiles.LastLoginIP As LastLoginIP,
		UserProfiles.VisitedCount As VisitedCount,
		Domains.Description As Description,
		UserProfiles.Blocked As Blocked,
		Domains.Type As Type,

		UserProfiles.PhoneNumber	As PhoneNumber,
		UserProfiles.Address		As Address,
		UserProfiles.Gender			As Gender,
		UserProfiles.BirthDate		As BirthDate,
		UserProfiles.Country		As Country

	From
		Domains Join UserProfiles
		On Domains.UID = UserProfiles.UID
	Where
		Domains.Type = 'User'
	
	With Check Option
Go