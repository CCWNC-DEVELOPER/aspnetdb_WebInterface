-- prj_0031_WA003_SP_001_SELECT_User_Given_ApplicationName_and_UserName.sql

/*
	************************************************************************************
	NOTE: 
	Uses: 
	Created: 12/30/2013
	By: glenn garson
	************************************************************************************
*/
set NOCOUNT ON
use aspnetdb
go


create PROCEDURE prj_0031_WA003_SP_001_SELECT_User_Given_ApplicationName_and_UserName(
	@ApplicationName AS nvarchar(256),
	@UserName AS NVARCHAR(256)
	)
	AS
	
--DECLARE @ApplicationID_guid uniqueidentifier 
--DECLARE @UserID_guid uniqueidentifier 
--SET @ApplicationID_guid = CONVERT(uniqueidentifier, @ApplicationID )
--SET @UserID_guid = CONVERT(uniqueidentifier, @UserID )

	
SELECT 

		aspnet_Applications.ApplicationName, 
		aspnet_Users.UserName, 
		aspnet_Membership.Password,	
		aspnet_Membership.PasswordSalt,
		aspnet_Membership.Email,
		aspnet_Membership.PasswordQuestion,
		aspnet_Membership.PasswordAnswer,		
		aspnet_Membership.IsApproved, 
		aspnet_Membership.CreateDate,
		aspnet_Membership.PasswordFormat,
		aspnet_Users.UserId,
		--The ones below here are not in the Create SP
		aspnet_Membership.IsLockedOut, 	 
		aspnet_Membership.LastLoginDate, 
		aspnet_Membership.FailedPasswordAttemptCount, 
		aspnet_Users.LastActivityDate, 		 
		aspnet_Applications.ApplicationId
FROM  
	(
		aspnet_Membership 
		INNER JOIN
		aspnet_Users 
		ON aspnet_Membership.UserId = aspnet_Users.UserId 
    )
                                INNER JOIN
                                aspnet_Applications 
                                ON 
		                            (
			                            (aspnet_Membership.ApplicationId = aspnet_Applications.ApplicationId) 
			                            AND 
                                        (aspnet_Users.ApplicationId = aspnet_Applications.ApplicationId)
                                    )
                                    
WHERE	(
			(aspnet_Applications.ApplicationName = @ApplicationName)
			and
			 (aspnet_Users.UserName = @UserName)
		)     