--aspnet_Membership_ResetPassword_TEST.sql
use aspnetdb
go


--exec aspnet_Membership_ResetPassword 
--	@ApplicationName=N'MyJUNK3',
--	@UserName=N'test123',
--	@NewPassword=N'AAA_12345',
--	@MaxInvalidPasswordAttempts=100,
--	@PasswordAttemptWindow=100,
--	@PasswordSalt=N'AAA_12345',
--	@CurrentTimeUtc ='2014-01-03 16:15:10.180',
--	@PasswordFormat=0,
--	@PasswordAnswer=N''			-- <This does not work
	
	
exec aspnet_Membership_ResetPassword 
	@ApplicationName=N'MyJUNK3',
	@UserName=N'test123',
	@NewPassword=N'BBB_12345',
	@MaxInvalidPasswordAttempts=100,
	@PasswordAttemptWindow=100,
	@PasswordSalt=N'AAA_12345',
	@CurrentTimeUtc ='2014-01-03 16:38:47.317',
	@PasswordFormat=0,
	@PasswordAnswer=NULL				-- <This DOES work