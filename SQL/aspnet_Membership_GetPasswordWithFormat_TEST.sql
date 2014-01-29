--aspnet_Membership_GetPasswordWithFormat_TEST.sql
/*
Just returns the stuff from the last select statement
*/

use aspnetdb
go

DECLARE @return_status int
DECLARE @CurrentTimeUtc datetime
SET @CurrentTimeUtc = GetDate()

exec @return_status = aspnet_Membership_GetPasswordWithFormat
    @ApplicationName='CCWNC411_Security',
    @UserName='ggarson',
    @UpdateLastLoginActivityDate=1,
    @CurrentTimeUtc= @CurrentTimeUtc