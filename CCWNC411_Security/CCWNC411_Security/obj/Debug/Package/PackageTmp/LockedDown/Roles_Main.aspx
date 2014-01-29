<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Roles_Main.aspx.vb" Inherits="CCWNC411_Security.Roles_Main" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <h1>
        Main Roles Page
    </h1>

    <h2>

        <asp:HyperLink ID="HyperLink1" runat="server" 
            NavigateUrl="~/LockedDown/Roles_for_User_Applications.aspx">Add Users to Existing 'Roles-Application' Combinations </asp:HyperLink>
    </h2>

    <article>

        <h1>
            To add a User to an 'Application-Role' combination, the User Must already exist in that Application
        </h1>

        <h2>
            Go to the User's page to create the user if it is not already in the Application: <a href="Users_Main.aspx">Users_Main.aspx</a>
        </h2>


    </article>

    <h2> 
        <asp:HyperLink ID="HyperLink2" runat="server" 
            NavigateUrl="~/LockedDown/Roles_for_Application.aspx">List, Add and Delete Roles <span>(For an Application that exists)</span></asp:HyperLink>
    </h2>
</asp:Content>
