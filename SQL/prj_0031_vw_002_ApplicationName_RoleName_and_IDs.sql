--prj_0031_vw_002_ApplicationName_RoleName_and_IDs.sql

/*
	************************************************************************************
	NOTE: 
	Uses: 
	Created: 1/10/2014
	By: glenn garson
	************************************************************************************
*/

use aspnetdb
go

create VIEW prj_0031_vw_002_ApplicationName_RoleName_and_IDs AS




SELECT     
		aspnet_Applications.ApplicationName, 
		aspnet_Roles.RoleName, 
		aspnet_Applications.ApplicationId, 
		aspnet_Roles.RoleId	
		
FROM         
		(

				aspnet_Roles 
				INNER JOIN
				aspnet_Applications 
				ON aspnet_Roles.ApplicationId = aspnet_Applications.ApplicationId 
		)
