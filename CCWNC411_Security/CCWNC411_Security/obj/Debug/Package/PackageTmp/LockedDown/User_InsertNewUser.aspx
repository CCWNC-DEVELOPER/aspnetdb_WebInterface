<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="User_InsertNewUser.aspx.vb" Inherits="CCWNC411_Security.User_InsertNewUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <p>

<%--  DetailsView: uses ODS --%>

        <asp:DetailsView 
                ID="dv_User" 
                runat="server" 
                DataSourceID="ods_dv_User" 
                DefaultMode="Insert"
                AutoGenerateInsertButton="True" 
                AutoGenerateRows="False">
            <fieldheaderstyle backcolor="#4b6c9e" font-bold="True" forecolor="#f9f9f9" />
            <commandrowstyle backcolor="lightblue" font-bold="True" forecolor="black" />
              <Fields>      
                    <asp:TemplateField HeaderText="ApplicationName">
                        <EditItemTemplate>
                             <asp:TextBox 
                                ID="TextBox1" 
                                runat="server" 
                                Text='<%# Bind("ApplicationName") %>'>
                             </asp:TextBox>
                        </EditItemTemplate>
                        <InsertItemTemplate>

							    <asp:DropDownList 
							    	ID="ddl_ApplicationName" 
							    	runat="server" 
							    	AppendDataBoundItems="True"
							        Height="23px" 
							        Width="255px" 
							        AutoPostBack="True"
							        DataSourceID="SqlDataSource_DropDownList" 
							        DataTextField="ApplicationName"
							        DataValueField="ApplicationName" 
							        SelectedValue='<%# Bind("ApplicationName") %>' > 
							        
							     	<asp:ListItem 
							     		Value="" 
							     		Text="blank">
							     	</asp:ListItem>
							     
							     </asp:DropDownList>
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <asp:Label 
                                ID="Label1" 
                                runat="server" 
                                Text='<%# Bind("ApplicationName") %>'>
                             </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="UserName"  HeaderText="UserName"  ControlStyle-Width="255px" />      
                   
                    
                    <asp:BoundField DataField="Password"   HeaderText="Password"   ControlStyle-Width="255px" /> 
                    <asp:BoundField DataField="PasswordSalt" HeaderText="PasswordSalt" InsertVisible="false"/>                  
                    <asp:BoundField DataField="Email" HeaderText="Email"  InsertVisible="false"/>                   
                    <asp:BoundField DataField="PasswordQuestion" HeaderText="PasswordQuestion"  InsertVisible="false"/>                  
                    <asp:BoundField DataField="PasswordAnswer" HeaderText="PasswordAnswer"  InsertVisible="false"/>  
                    <asp:BoundField DataField="IsApproved"       HeaderText="IsApproved"  InsertVisible="false"/>                    
                    <asp:BoundField DataField="CurrentTimeUtc" HeaderText="CurrentTimeUtc"  InsertVisible="false"/>   
                    <asp:BoundField DataField="CreateDate" HeaderText="CreateDate"  InsertVisible="false"/>                                    
                    <asp:BoundField DataField="UniqueEmail" HeaderText="UniqueEmail"  InsertVisible="false"/>      
                    <asp:BoundField DataField="PasswordFormat" HeaderText="PasswordFormat"  InsertVisible="false"/>                 
                    <asp:BoundField DataField="UserID" HeaderText="UserID" InsertVisible="False" ReadOnly="true"/>     
                    
                    <asp:BoundField DataField="IsLockedOut"     HeaderText="IsLockedOut"  InsertVisible="False"/>
                    <asp:BoundField DataField="LastLoginDate" HeaderText="LastLoginDate"  InsertVisible="False"/> 
                    <asp:BoundField DataField="LastActivityDate" HeaderText="LastActivityDate"  InsertVisible="False"/> 
                    <asp:BoundField DataField="ApplicationId" HeaderText="ApplicationId"  InsertVisible="False"/>  
      
               </Fields> 

               
        </asp:DetailsView>



    </p>



    <p>
<%--  ODS for DetailsView --%>

        <asp:ObjectDataSource 
                ID="ods_dv_User" 
                runat="server" 
                DataObjectTypeName="CCWNC411_Security.ns_USER.c_USER_Record"
                OnInserting="ods_dv_User_Inserting"
                InsertMethod="InsertUser" 
                TypeName="CCWNC411_Security.ns_USER.c_USER_DL">

        </asp:ObjectDataSource>

    </p>

    <p>
            <asp:Label ID="lblConfirmation" Font-Names="Verdana" Font-Size="Small" runat="server" EnableViewState="false"></asp:Label>
    </p>
   <p>
<%--  ODS for DropDownList --%>

        <asp:SqlDataSource ID="SqlDataSource_DropDownList" runat="server" 
            ConnectionString="<%$ ConnectionStrings:SHAREPOINT01_aspnetdb %>"        
            ProviderName="<%$ ConnectionStrings:SHAREPOINT01_aspnetdb.ProviderName %>" 
            SelectCommand="SELECT [ApplicationName], [ApplicationId] FROM [aspnet_Applications]" >
        </asp:SqlDataSource>

    </p>    

</asp:Content>
