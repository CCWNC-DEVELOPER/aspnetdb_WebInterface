use aspnetdb
go



---- All the users in the application
--SELECT aspnet_Users.UserName
--FROM  aspnet_Applications INNER JOIN
--               aspnet_Users ON aspnet_Applications.ApplicationId = aspnet_Users.ApplicationId


-- All the users in a role in an application
--SELECT aspnet_Users.UserName
--FROM  aspnet_Roles INNER JOIN
--               aspnet_UsersInRoles ON aspnet_Roles.RoleId = aspnet_UsersInRoles.RoleId INNER JOIN
--               aspnet_Applications ON aspnet_Roles.ApplicationId = aspnet_Applications.ApplicationId INNER JOIN
--               aspnet_Users ON aspnet_UsersInRoles.UserId = aspnet_Users.UserId AND aspnet_Applications.ApplicationId = aspnet_Users.ApplicationId


--SELECT left1.UserName, left1.UserId
select left1.UserName,left1.UserId, left1.ApplicationName,  left1.ApplicationId, right1.RoleName, right1.RoleId
From
	(	-- All users in an  applications
		select aspnet_Users.UserName,aspnet_Users.UserId, aspnet_Applications.ApplicationName,  aspnet_Applications.ApplicationId
		from
		(
		aspnet_Applications 
		INNER JOIN
		aspnet_Users 
		ON aspnet_Applications.ApplicationId = aspnet_Users.ApplicationId
		) 
		WHERE   --<===============
	) AS left1

	full outer Join

	(	-- All users in a given role in the application
		select aspnet_Users.UserName,aspnet_Users.UserId, aspnet_Applications.ApplicationName,  aspnet_Applications.ApplicationId,
			aspnet_Roles.RoleName, aspnet_Roles.RoleId
		from
		(
		aspnet_Roles INNER JOIN
					   aspnet_UsersInRoles ON aspnet_Roles.RoleId = aspnet_UsersInRoles.RoleId INNER JOIN
					   aspnet_Applications ON aspnet_Roles.ApplicationId = aspnet_Applications.ApplicationId INNER JOIN
					   aspnet_Users ON aspnet_UsersInRoles.UserId = aspnet_Users.UserId AND aspnet_Applications.ApplicationId = aspnet_Users.ApplicationId
		)
		WHERE   --	<==============
	)  AS right1
	on left1.UserId = right1.UserId
	
	