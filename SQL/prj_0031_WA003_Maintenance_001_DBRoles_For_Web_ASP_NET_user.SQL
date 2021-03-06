--prj_0031_WA003_Maintenance_001_DBRoles_For_Web_ASP_NET_user.SQL


-- 
/*
	************************************************************************************
	Web_ASP_NET_user is an SQL Login 
		that is used in the connection string by the Web Application: WA003_CCWNC411_Security
	The purpose of this script is to give the user the permissions it needs to allow 
		web users to modify the database from the web pages
	
	
	NOTE: 
	Uses: 
	Created: 1/10/2014
	By: glenn garson
	************************************************************************************
*/



USE [aspnetdb]
GO
EXEC sp_addrolemember N'aspnet_Personalization_FullAccess', N'Web_ASP_NET_user'
GO
USE [aspnetdb]
GO
EXEC sp_addrolemember N'aspnet_WebEvent_FullAccess', N'Web_ASP_NET_user'
GO
USE [aspnetdb]
GO
EXEC sp_addrolemember N'aspnet_Profile_FullAccess', N'Web_ASP_NET_user'
GO
USE [aspnetdb]
GO
EXEC sp_addrolemember N'db_datawriter', N'Web_ASP_NET_user'
GO
USE [aspnetdb]
GO
EXEC sp_addrolemember N'aspnet_Membership_FullAccess', N'Web_ASP_NET_user'
GO
USE [aspnetdb]
GO
EXEC sp_addrolemember N'db_owner', N'Web_ASP_NET_user'
GO
USE [aspnetdb]
GO
EXEC sp_addrolemember N'aspnet_Roles_FullAccess', N'Web_ASP_NET_user'
GO
USE [aspnetdb]
GO
EXEC sp_addrolemember N'db_securityadmin', N'Web_ASP_NET_user'
GO
USE [aspnetdb]
GO
EXEC sp_addrolemember N'db_datareader', N'Web_ASP_NET_user'
GO
USE [aspnetdb]
GO
EXEC sp_addrolemember N'aspnet_Membership_ReportingAccess', N'Web_ASP_NET_user'
GO
USE [aspnetdb]
GO
EXEC sp_addrolemember N'db_accessadmin', N'Web_ASP_NET_user'
GO
