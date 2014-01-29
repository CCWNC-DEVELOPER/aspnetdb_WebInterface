--JUNK4.SQL


-- Left: All UserId linked to the particular Application
-- Left outer Join
-- Right: the existing set of UserID and RoleId linked to the particular Application
-- ON UserID


--||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

---- Left: All UserId linked to the particular Application
--SELECT L1_L.RoleName, L1_L.RoleId, L1_L.ApplicationId AS ApplicationId_L1_L, L1_R.UserName, L1_R.UserId, L1_R.ApplicationId AS ApplicationId_L1_R

--select L1_L.ApplicationName, L1_R.UserId, L1_R.UserName

--FROM (
--		aspnet_Applications AS L1_L
--		inner join
--		aspnet_Users AS L1_R
--		on (
--				(L1_L.ApplicationId = L1_R.ApplicationId)
--			)
--	)
--WHERE  (ltrim(rtrim(L1_L.ApplicationName))  = 'CCWNC411_Security') 

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

----||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||


SELECT DISTINCT
		--RoleName
		--RoleId
		--ApplicationId_L1_L
		UserName_L1_R
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
		(--Left: All UserId linked to the particular Application

			select L1_L.ApplicationName as ApplicationName_L1_R, L1_L.ApplicationId as ApplicationId_L1_R, L1_R.UserId as UserId_L1_R, L1_R.UserName as UserName_L1_R

			FROM (
					aspnet_Applications AS L1_L
					inner join
					aspnet_Users AS L1_R
					on (
							(L1_L.ApplicationId = L1_R.ApplicationId)
						)
				)
			WHERE  (ltrim(rtrim(L1_L.ApplicationName))  = 'CCWNC411_Security') 

		
		) AS LEFT1
		
		LEFT OUTER JOIN
		
		(-- Right: the existing set of UserID and RoleId linked to the particular Application
		
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
				--AND
				--(LEFT1.RoleId = RIGHT1.Role_Id)
			)
			
			
			
			
	)
WHERE
	(
			(
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
			)
			--and
			--(
			--(ltrim(rtrim(username)) <> 'ggarson')
			--)
	)


----||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
