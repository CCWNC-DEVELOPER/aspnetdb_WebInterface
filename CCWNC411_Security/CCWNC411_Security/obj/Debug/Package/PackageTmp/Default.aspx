<%@ Page Title="Home Page" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeBehind="Default.aspx.vb" Inherits="CCWNC411_Security._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">

</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <h1>
         CCWNC411 Web Application Security
    </h1>

    <h2>
            &nbsp;<asp:HyperLink ID="HyperLink1" runat="server" 
                NavigateUrl="~/LockedDown/Applications_Main.aspx">Applications</asp:HyperLink>
    </h2>


    <article>

        <h1>
            An 'Application' is the same as a web site
        </h1>
        <h1>
            Each Application can have folders in it
        </h1>
        <h2>
            The way access is controlled to a folder, or the entire website, is with Roles
        </h2>
       
   </article>


    <h2>
            <asp:HyperLink ID="HyperLink3" runat="server" 
                NavigateUrl="~/LockedDown/Roles_Main.aspx">Roles</asp:HyperLink>
    </h2>

    <article>

        <h1>
            Each Application can have 'Roles' that are associated with it
        </h1>
        <h2>
            The Application has to exist to create the Roles for it.
        </h2>
        <h1>
            Roles can be used to control access to Folders in the Application, and the web-pages in those folders
        </h1>

   </article>

    <h2>
            <asp:HyperLink ID="HyperLink2" runat="server" 
                NavigateUrl="~/LockedDown/Users_Main.aspx"> Users</asp:HyperLink>
    </h2>



    <article>

        <h1>
            A 'User' is created for a specific Application
        </h1>

        <h2>
            Unfortunately, if you want the same user to exist in multiple Applications, you have to recreate the User for each one. 
        </h2>
        <h1>
            User Names should be their Windows User ID (e.g. ggarson for glenn garson)
        </h1>
        <h2>
            You can edit/update the User's password.
        </h2>


   </article>
   





</asp:Content>
