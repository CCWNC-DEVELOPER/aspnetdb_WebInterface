<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Roles_for_User_Applications.aspx.vb" Inherits="CCWNC411_Security.Roles_for_User_Applications" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


<h1>
    Add or Delete Users from Application-Role combinations
</h1>

<p>
<%--  DropDownList : Application --%>

    <h2> 1] Pick the Web Application</h2>
    <asp:DropDownList 
        ID="DropDownList_Application" 
        runat="server"
        AppendDataBoundItems="true"
        DataSourceID="SqlDataSource_DropDownList_Application" 
        DataTextField="ApplicationName" 
        DataValueField="ApplicationName" 
        AutoPostBack="true">
    </asp:DropDownList>


<%--  ODS for the DropDownList : Application --%>

        <asp:SqlDataSource ID="SqlDataSource_DropDownList_Application" 
            runat="server" 
            ConnectionString="<%$ ConnectionStrings:SHAREPOINT01_aspnetdb %>"        
            ProviderName="<%$ ConnectionStrings:SHAREPOINT01_aspnetdb.ProviderName %>" 
            SelectCommand="SELECT [ApplicationName], [ApplicationId] FROM [aspnet_Applications]" >
        </asp:SqlDataSource>


</p>

<p>
    <h2> 2] Pick a Role that is already in the Web Application</h2>
<%--  DropDownList : Role  --%> 
    <asp:DropDownList 
        ID="DropDownList_Role" 
        runat="server"
        AppendDataBoundItems="true"
        DataSourceID="SqlDataSource_DropDownList_Role" 
        DataTextField="RoleName" 
        DataValueField="RoleName" 
        AutoPostBack="true">
    </asp:DropDownList>

  
<%--  ODS for the DropDownList : Role  --%>

        <asp:SqlDataSource ID="SqlDataSource_DropDownList_Role" 
            runat="server" 
            ConnectionString="<%$ ConnectionStrings:SHAREPOINT01_aspnetdb %>"        
            ProviderName="<%$ ConnectionStrings:SHAREPOINT01_aspnetdb.ProviderName %>" 
            SelectCommand="  SELECT RoleName = ' ' "
             >
        </asp:SqlDataSource>


</p>




<%--  Controls ------------------------------------------------- --%>

<p>


    <asp:Button ID="btn_View_Users_in_RoleApplication" runat="server" Text="View Users in Role - Application" 
        Width="341px" />


</p>

<p>
        <asp:Label ID="lbl_Message" runat="server" Text="Label"></asp:Label>
        



<%--  GridView ------------------------------------------------- --%>


    <h2> List of Roles that are in the Role-Application Combination</h2>

    <asp:GridView 
        ID="GridView_UsersInApplicationRole" 
        DataSourceID="ods_GridView_UsersInApplicationRole" 
        AutoGenerateColumns="False"
        RunAt="server"
        OnRowCommand="GridView_UsersInApplicationRole_RowCommand"
        Width="265px"
        HeaderStyle-BackColor="#4b6c9e"
        HeaderStyle-ForeColor="#f9f9f9">

        <Columns>

        <asp:buttonfield         
            buttontype="Button" 
            commandname="DeleteUser_FromApplicationRole"
            headertext="Delete User from Web-Role" 
            text="Delete"
            ControlStyle-BackColor="LightGray"
            ControlStyle-ForeColor="Red"
            ControlStyle-Width="150px"/>



            <asp:BoundField DataField="UserName" HeaderText="UserName" 
                SortExpression="UserName" />


        </Columns>

<HeaderStyle BackColor="#4B6C9E" ForeColor="#F9F9F9"></HeaderStyle>
    </asp:GridView>



        <asp:ObjectDataSource 
            ID="ods_GridView_UsersInApplicationRole" 
            runat="server"            
            TypeName="CCWNC411_Security.ns_USER_APPLICATION_ROLE.c_USER_APPLICATION_ROLE_DL"   
            DataObjectTypeName="CCWNC411_Security.ns_USER_APPLICATION_ROLE.c_USER_APPLICATION_ROLE_Record" 
            SelectMethod="GetAllUsers_Given_ApplicationAndRole_Name" >   

             <SelectParameters>
                <asp:QueryStringParameter Name="ApplicationName"/>
            </SelectParameters>

             <SelectParameters>
                <asp:QueryStringParameter Name="RoleName"/>
            </SelectParameters>


      </asp:ObjectDataSource>

</p>

<p>
    <div class="clear BreakBar"></div>
</p>



<h2> 3] To add a user, First Pick a User from the drop-down below</h2>
<h3> If you don't see the user in the list, go back and add the user to the Application</h3>

<p>
<%--  DropDownList : User --%>


    <asp:DropDownList 
        ID="DropDownList_User" 
        runat="server"
        AppendDataBoundItems="true"
        DataSourceID="ods_DropDownList_User" 
        DataTextField="UserName" 
        DataValueField="UserName" 
        AutoPostBack="true">
    </asp:DropDownList>

    
<%--  ODS for the DropDownList : User  --%>

     <asp:ObjectDataSource 
        ID="ods_DropDownList_User" 
        runat="server" 
        TypeName="CCWNC411_Security.ns_USER_APPLICATION_ROLE.c_USER_APPLICATION_ROLE_DL"
        DataObjectTypeName="CCWNC411_Security.ns_USER_APPLICATION_ROLE.c_USER_APPLICATION_ROLE_Record"
        SelectMethod="GetAllUsers_Not_in_Application_Role_combination"
        OnSelecting="ods_DropDownList_User_Selecting"
        >
        <SelectParameters>
 
          <asp:Parameter Name="ApplicationName" Type="String" />  
          <asp:Parameter Name="RoleName" Type="String" /> 

        </SelectParameters>
      </asp:ObjectDataSource>


</p>



<p>


    <asp:Button ID="btn_AddUser_to_RoleApplication" runat="server" Text="Add User to Role - Application" 
        Width="341px" />&nbsp;<asp:TextBox ID="txt_NewUserToAddToRoleApplication" runat="server" Width="354px"></asp:TextBox>


</p>

<p>

</p>

</asp:Content>
