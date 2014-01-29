--prj_0031_WA003_SP_002_SELECT_User_Not_in_Application_Role_combination_v2.SQL


-- Left: All UserId linked to the particular Application
-- Left outer Join
-- Right: the existing set of UserID and RoleId linked to the particular Application
-- ON UserID

/*
	************************************************************************************
	NOTE: 
	Uses: 
	Created: 1/9/2014
	By: glenn garson
	************************************************************************************
*/

SET NOCOUNT ON
Use aspnetdb
go

alter PROCEDURE prj_0031_WA003_SP_002_SELECT_User_Not_in_Application_Role_combination(
	@ApplicationName AS NVARCHAR(256),
	@RoleName as NVARCHAR(256)
	)
	AS

SELECT DISTINCT
		UserName_L1_R AS UserName
		--,UserName_R1_R,
		,RIGHT1.ApplicationName as ApplicationName
		,RIGHT1.RoleName As RoleName

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
			)
			
			
			
			
	)
WHERE

			(
				(
					(ltrim(rtrim(ApplicationName))  <> @ApplicationName) 
					or 
					(ApplicationName is null)
				)
				and
				(
					(ltrim(rtrim(RIGHT1.RoleName)) <> @RoleName)
					or 
					(RIGHT1.RoleName is null)
				)

			)
