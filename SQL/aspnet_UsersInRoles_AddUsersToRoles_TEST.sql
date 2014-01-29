-- aspnet_UsersInRoles_AddUsersToRoles_TEST.sql

use aspnetdb
go

exec aspnet_UsersInRoles_AddUsersToRoles 
	@ApplicationName=N'CCWNC411_Security',
	@UserNames=N'TEST',
	@RoleNames=N'dg_SchoolNurses',	
	@CurrentTimeUtc='2011-12-22 19:29:17.000'
	
	
	
