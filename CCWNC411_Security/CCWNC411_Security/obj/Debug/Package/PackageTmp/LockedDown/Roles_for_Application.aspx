<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Roles_for_Application.aspx.vb" Inherits="CCWNC411_Security.Roles_for_Application" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h1>
    View or Add the Roles for a Web Application
</h1>

<p>
Pick an Application To see the list of Roles
</p>
<p>
<%--  DropDownList --%>
    <asp:DropDownList 
        ID="DropDownList_Application" 
        runat="server"
        AppendDataBoundItems="true"
        DataSourceID="SqlDataSource_DropDownList" 
        DataTextField="ApplicationName" 
        DataValueField="ApplicationName" 
        AutoPostBack="true">
    </asp:DropDownList>

    
<%--  ODS for the DropDownList --%>

        <asp:SqlDataSource ID="SqlDataSource_DropDownList" runat="server" 
            ConnectionString="<%$ ConnectionStrings:SHAREPOINT01_aspnetdb %>"        
            ProviderName="<%$ ConnectionStrings:SHAREPOINT01_aspnetdb.ProviderName %>" 
            SelectCommand="SELECT [ApplicationName], [ApplicationId] FROM [aspnet_Applications]" >
        </asp:SqlDataSource>



</p>

<p>

<%--  Controls ------------------------------------------------- --%>


        <asp:Label ID="lbl_Message" runat="server" Text="Label"></asp:Label>
        
</p>
<p>

    <asp:Button ID="btn_GetListOfRolesForTheApplication" 
        runat="server" 
        Text="Get List Of Roles For The Application" />
</p>


<p>

    <asp:Button ID="btn_AddNewRoleToApplication" runat="server" Text="Add New Role To Application" />
    &nbsp;<asp:TextBox ID="txt_NewRoleToAddToApplication" runat="server" Width="354px"></asp:TextBox>



</p>
<p>

    <asp:GridView 
        ID="GridView_RolesInTheApplication" 
        DataSourceID="ods_for_GridView" 
        AutoGenerateColumns="False"
        RunAt="server"  
        DataKeyNames="RoleName"
        OnRowCommand="GridView_RolesInTheApplication_RowCommand"
        Width="265px"
        HeaderStyle-BackColor="#4b6c9e"
        HeaderStyle-ForeColor="#f9f9f9">

        <Columns>
        <asp:buttonfield buttontype="Button" 
            commandname="DeleteRole"
            headertext="Delete Role" 
            text="Delete"
            ControlStyle-BackColor="LightGray"
            ControlStyle-ForeColor="Red"
            ControlStyle-Width="150px"/>


            <asp:BoundField 
                    DataField="RoleName" 
                    HeaderText="RoleName" 
                    SortExpression="RoleName" />

        </Columns>
    </asp:GridView>

    <asp:ObjectDataSource 
        ID="ods_for_GridView" 
            runat="server" 
            TypeName="CCWNC411_Security.ns_ROLE.c_ROLE_DL"   
            DataObjectTypeName="CCWNC411_Security.ns_ROLE.c_ROLE_Record" 
            SelectMethod="GetAllRoles_GivenApplicationName" >   

             <SelectParameters>
                <asp:QueryStringParameter Name="ApplicationName"/>
            </SelectParameters>



      </asp:ObjectDataSource>



</asp:Content>


<%--


 --%>
