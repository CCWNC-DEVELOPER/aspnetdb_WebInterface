-- aspnet_Membership_CreateUser_TEST.sql


use aspnetdb
go


--declare @p1 int
--set @p1=NULL
--exec aspnet_Membership_CreateUser @RETURN=@p1 output,@ApplicationName=N'MyJUNK3',@UserName=N'junk123',@Password=N'JUNK_1234',@PasswordSalt=NULL,@Email =NULL,@PasswordQuestion =NULL,@PasswordAnswer=NULL,@IsApproved=0,@CurrentTimeUtc=NULL,@CreateDate =NULL,@UniqueEmail=NULL,@PasswordFormat =NULL,@OUTPUT=default
exec aspnet_Membership_CreateUser 
	@ApplicationName=N'MyJUNK3',
	@UserName=N'junk123',
	@Password=N'JUNK_1234',
	@PasswordSalt='junk',
	@Email =NULL,
	@PasswordQuestion =NULL,
	@PasswordAnswer=NULL,
	@IsApproved=0,
	@CurrentTimeUtc='2013-12-22 19:29:17.000',
	@CreateDate ='2013-12-22 19:29:17.000',
	@UniqueEmail=NULL,
	@PasswordFormat =0,
	@UserId =NULL