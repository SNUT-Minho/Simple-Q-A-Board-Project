--[4] 관리용 사용자에 대한 권한(역할: role) 부여




Insert Membership (UserUID, GroupUID) Select 5, 1 Where Not Exists (Select * From dbo.Membership Where UserUID =5 And GroupUID =1)      
	-- Administartor -> Administratos(1)
Go


Insert Membership (UserUID, GroupUID) Select 5, 3 Where Not Exists (Select * From dbo.Membership Where UserUID =5 And GroupUID =3) 
      -- Administartor -> Users(3)
Go


Insert Membership (UserUID, GroupUID) Select 6, 4 Where Not Exists (Select * From dbo.Membership Where UserUID =6 And GroupUID =4) 
       -- Guest -> Geusts(4)
Go


Insert Membership (UserUID, GroupUID) Select 7, 4 Where Not Exists (Select * From dbo.Membership Where UserUID =7 And GroupUID =4) 
       -- Anonymous -> Guests(4)
Go

