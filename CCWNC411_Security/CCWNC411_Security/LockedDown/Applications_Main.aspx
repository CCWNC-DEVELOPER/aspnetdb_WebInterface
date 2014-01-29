<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Applications_Main.aspx.vb" Inherits="CCWNC411_Security.Applications_Main" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h1>
    Applications
</h1>

<h2>
    
    <asp:HyperLink ID="HyperLink1" runat="server" 
        NavigateUrl="~/LockedDown/Applications_Child.aspx">View List, Add, Delete - Applications</asp:HyperLink>
    
</h2>


</asp:Content>
