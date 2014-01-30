aspnetdb_WebInterface
=====================

This project uses an ASP.net GUI to let the user do CRUD operations on the aspnetdb database (SQL Server version) for Members, Roles and Users.   There are two Main folders: [1] "CCWNC411_Security" is the Visual Basic (VB.NET) 2010 project. [2] The folder "SQL" has the Stored Procedures needed to add some functionality for the ASP.NET pages.  

This Web Application Project allows the user to do CRUD operations using the web interface on the Roles, UserNames, Passwords, and Applications.

see the following reference to set up the Authorization , and Authentication sections of web.config:
http://weblogs.asp.net/gurusarkar/archive/2008/09/29/setting-authorization-rules-for-a-particular-page-or-folder-in-web-config.aspx

See the root of the project for an example of a root web.config file, and the Account folder for an example of the web.config file where you want to control specific folder access 

The .sql scripts have names starting with "prj_0031_WA003_SP_00" refer to my project nomenclature and can be changed, but you would then also need to change them in the DataLayer methods of the Web Application, which are stored in the "BackEndCode" folder of the Web Application.

The .aspx files in the folder "LockedDown" are the pages that let you do the CRUD operations. The web.config file can be replaced with the code from either "Web_Debug_Version.config" when you want to debug, or "Web_Working_Version.config" when you want to publish it to the production site.

In this particular case, I think, I created the SQL database "aspnetdb" from an sql script I found on the web, but I may have uploaded it from an ACCESS db. I can't remember.

The word (.docx) file is just some notes and probably not of use to anyone, but it has my notes of issues as I figured out how to do this.

The excel file (.xlsx) was just my way of figuring out which fields I needed to do the CRUD operations.
