--JUNK3.SQL


-- Left: All possible combinations of UserId and RoleId
-- Left outer Join
-- Right: the existing set of UserID and RoleId


--||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

---- Left: All possible combinations of UserId and RoleId
--SELECT L1_L.RoleName, L1_L.RoleId, L1_L.ApplicationId AS ApplicationId_L1_L, L1_R.UserName, L1_R.UserId, L1_R.ApplicationId AS ApplicationId_L1_R
--FROM (
--		aspnet_Roles AS L1_L
--		CROSS JOIN 
--		aspnet_Users AS L1_R
--	)


--||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

---- Right: the existing set of UserID and RoleId
--SELECT R1_L.RoleId as Role_Id, R1_L.UserId AS UserId, R1_R.ApplicationId AS ApplicationId_R1_R, R1_R.UserName AS UserName_R1_R
--FROM
--	(
--		aspnet_UsersInRoles AS R1_L
--		INNER JOIN
--		aspnet_Users AS R1_R
--		ON R1_L.UserId=R1_R.UserId
	
	
--	)

--||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||


SELECT DISTINCT
		--RoleName
		--RoleId
		--ApplicationId_L1_L
		UserName
		--UserId
		--ApplicationId_L1_R
		--,Role_Id
		--,UserId_L1_R
		--,ApplicationId_R1_R
		,UserName_R1_R,
		RIGHT1.ApplicationName,
		RIGHT1.RoleName

FROM
	(
		(

			SELECT L1_L.RoleName, L1_L.RoleId, L1_L.ApplicationId AS ApplicationId_L1_L, L1_R.UserName, L1_R.UserId as UserId_L1_R , L1_R.ApplicationId AS ApplicationId_L1_R
			FROM (
					aspnet_Roles AS L1_L
					CROSS JOIN 
					aspnet_Users AS L1_R
				)

		
		) AS LEFT1
		
		LEFT OUTER JOIN
		
		(
		
			SELECT 
					R1_L.RoleId as Role_Id, 
					R1_L.UserId AS UserId, 
					R1_R.ApplicationId AS ApplicationId_R1_R, 
					R1_R.UserName AS UserName_R1_R, 
					aspnet_Applications.ApplicationName,
					aspnet_Roles.RoleName
			FROM
				(
					(
						(
							aspnet_UsersInRoles AS R1_L
							INNER JOIN
							aspnet_Users AS R1_R
							ON R1_L.UserId=R1_R.UserId	
						)
						LEFT OUTER JOIN
						aspnet_Applications
						on (
								R1_R.ApplicationId = aspnet_Applications.ApplicationId
							)
					)
					LEFT OUTER JOIN
					aspnet_Roles
					ON
						(R1_L.RoleId=aspnet_Roles.RoleId)
						
				)
		
		) AS RIGHT1
	
		ON (
				(LEFT1.UserId_L1_R = RIGHT1.UserId)
				AND
				(LEFT1.RoleId = RIGHT1.Role_Id)
			)
			
			
			
			
	)
WHERE
--	(
--			(
				(
					(ltrim(rtrim(ApplicationName))  <> 'CCWNC411_Security') 
					or 
					(ApplicationName is null)
				)
				and
				(
					(ltrim(rtrim(RIGHT1.RoleName)) <> 'dg_SchoolNurses')
					or 
					(RIGHT1.RoleName is null)
				)
--			)
			and
			(
			(ltrim(rtrim(username)) <> 'ggarson')
			)
--	)
