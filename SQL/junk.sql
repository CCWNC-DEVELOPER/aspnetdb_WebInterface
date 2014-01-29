use aspnetdb
go

SELECT aspnet_Users.UserName, aspnet_Applications.ApplicationName, aspnet_Roles.RoleName
FROM  

aspnet_UsersInRoles FULL OUTER JOIN
aspnet_Roles ON aspnet_UsersInRoles.RoleId = aspnet_Roles.RoleId FULL OUTER JOIN
aspnet_Applications ON aspnet_Roles.ApplicationId = aspnet_Applications.ApplicationId FULL OUTER JOIN
aspnet_Users ON aspnet_UsersInRoles.UserId = aspnet_Users.UserId

Where		
		
--		aspnet_Applications.ApplicationName <> 'CCWNC411_Security'
--		and
--		aspnet_Roles.RoleName <> 'dg_SchoolNurses'