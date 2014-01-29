<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Applications_subChild_UpdateRecord.aspx.vb" Inherits="CCWNC411_Security.Applications_subChild_UpdateRecord" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">



    <p>

        <asp:DetailsView 
                ID="DetailsView1" 
                runat="server" 
                AutoGenerateRows="False" 
                DataKeyNames="ApplicationId" 
                DataSourceID="SqlDataSource1" 
                Height="63px" 


            Width="475px" 

            OnItemUpdated="DetailsView_ItemUpdate" 
            OnItemCommand="DetailsView_ItemCommand"  
                     
            DefaultMode="Edit">


            <Fields>

               <asp:BoundField 
                        DataField="ApplicationName" 
                        HeaderText="ApplicationName" 
                        SortExpression="ApplicationName"   
                        ControlStyle-Width="500px">
                        <HeaderStyle BackColor="#4b6c9e" ForeColor="#f9f9f9" />
                </asp:BoundField>

                <asp:BoundField 
                        DataField="LoweredApplicationName" 
                        HeaderText="LoweredApplicationName" 
                        SortExpression="LoweredApplicationName"    
                        ControlStyle-Width="500px" >
                        <HeaderStyle BackColor="#4b6c9e" ForeColor="#f9f9f9" />
                </asp:BoundField>

                <asp:BoundField 
                    DataField="ApplicationId" 
                    HeaderText="ApplicationId" 
                	InsertVisible="False" 
                    ReadOnly="True" 
                    SortExpression="ApplicationId"     
                    ControlStyle-Width="500px">
                    <HeaderStyle BackColor="#4b6c9e" ForeColor="#f9f9f9" />
                </asp:BoundField>

                <asp:BoundField 
                    DataField="Description" 
                    HeaderText="Description" 
                    SortExpression="Description"     
                    ControlStyle-Width="500px">
                    <HeaderStyle BackColor="#4b6c9e" ForeColor="#f9f9f9" />
                </asp:BoundField>



                <asp:CommandField ShowEditButton="True" />

            </Fields>
        </asp:DetailsView>

   </p>

    <p>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:SHAREPOINT01_aspnetdb %>" 
            DeleteCommand="DELETE FROM [aspnet_Applications] WHERE [ApplicationId] = @ApplicationId" 
            InsertCommand="INSERT INTO [aspnet_Applications] ([ApplicationName], [LoweredApplicationName], [ApplicationId], [Description]) VALUES (@ApplicationName, LOWER(@LoweredApplicationName), @ApplicationId, @Description)" 
            ProviderName="<%$ ConnectionStrings:SHAREPOINT01_aspnetdb.ProviderName %>" 
            SelectCommand="SELECT [ApplicationName], [LoweredApplicationName], [ApplicationId], [Description] FROM [aspnet_Applications] WHERE [ApplicationId] = @ApplicationId" 
            UpdateCommand="UPDATE [aspnet_Applications] SET [ApplicationName] = @ApplicationName, [LoweredApplicationName] = LOWER(@LoweredApplicationName), [Description] = @Description WHERE [ApplicationId] = @ApplicationId">
 	       <SelectParameters>
                <asp:QueryStringParameter Name="ApplicationId"
                    QueryStringField="ApplicationId" 
                     />

            </SelectParameters>           
             <UpdateParameters>
                <asp:Parameter Name="ApplicationName" Type="String" />
                <asp:Parameter Name="LoweredApplicationName" Type="String" />
                <asp:Parameter Name="Description" Type="String" />
                <asp:Parameter Name="ApplicationId" Type="Object" />
            </UpdateParameters>
        </asp:SqlDataSource>


        <br />





    </p>
</asp:Content>
