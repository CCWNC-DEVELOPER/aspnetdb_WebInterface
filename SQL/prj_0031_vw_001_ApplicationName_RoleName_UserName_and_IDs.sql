
--prj_0031_vw_001_ApplicationName_RoleName_UserName_and_IDs.sql

/*
	************************************************************************************
	NOTE: 
	Uses: 
	Created: 1/5/2014
	By: glenn garson
	************************************************************************************
*/

use aspnetdb
go

alter VIEW prj_0031_vw_001_ApplicationName_RoleName_UserName_and_IDs AS


SELECT     
		aspnet_Applications.ApplicationName, 
		aspnet_Roles.RoleName, 
		aspnet_Users.UserName, 
		aspnet_Applications.ApplicationId, 
		aspnet_Roles.RoleId, 
        aspnet_Users.UserId
FROM         
		(
			(
				aspnet_Roles 
				INNER JOIN
				aspnet_Applications 
				ON aspnet_Roles.ApplicationId = aspnet_Applications.ApplicationId 
			)
			INNER JOIN
			aspnet_Users 
			ON aspnet_Applications.ApplicationId = aspnet_Users.ApplicationId 
        )
        INNER JOIN
        aspnet_UsersInRoles 
        ON
			(
				(aspnet_Roles.RoleId = aspnet_UsersInRoles.RoleId)
				 AND 
				(aspnet_Users.UserId = aspnet_UsersInRoles.UserId)
			)