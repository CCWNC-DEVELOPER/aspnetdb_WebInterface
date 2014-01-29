<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Users_Main.aspx.vb" Inherits="CCWNC411_Security.Users_Main" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h1>
        Main Users Page
    </h1>

    <h2>

        <asp:HyperLink ID="HyperLink1" runat="server" 
            NavigateUrl="~/LockedDown/User_CRUD.aspx">Select, Update and Delete Existing Users</asp:HyperLink>
    </h2>
    <h2> 
        <asp:HyperLink ID="HyperLink2" runat="server" 
            NavigateUrl="~/LockedDown/User_InsertNewUser.aspx">Insert New Users <span>(Given the Application Exists)</span></asp:HyperLink>
    </h2>

</asp:Content>