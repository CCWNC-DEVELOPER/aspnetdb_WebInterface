-- prj_0031_WA003_SELECT001_Users_Membership_Application.sql

use aspnetdb
go

SELECT 
		aspnet_Users.UserName, 
		aspnet_Applications.ApplicationName, 
		aspnet_Membership.IsApproved, 
		aspnet_Membership.IsLockedOut, 
		aspnet_Membership.Password, 
		aspnet_Membership.PasswordFormat, 
		aspnet_Membership.PasswordSalt, 
		aspnet_Membership.CreateDate, 
		aspnet_Membership.LastLoginDate, 
		aspnet_Membership.FailedPasswordAttemptCount, 
		aspnet_Users.LastActivityDate, 
		aspnet_Users.UserId, 
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
                                    
                             --WHERE aspnet_Users.ApplicationId = @ApplicationId      