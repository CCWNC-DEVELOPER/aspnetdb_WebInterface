<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Applications_Child.aspx.vb" Inherits="CCWNC411_Security.Applications_Child" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<p>

    <asp:HyperLink ID="HyperLink1" runat="server" 
        NavigateUrl="~/LockedDown/Applications_subChild_NewRecord.aspx">Add New Application</asp:HyperLink>

</p>

<p> <b>Note:</b> The <span style="color:#FF0000;" >Delete</span> link will delete without giving you a second chance</p>
<p>


    <asp:GridView ID="GridView1" runat="server" AllowSorting="True" 
        AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ApplicationId" 
        DataSourceID="SqlDataSource1" 
        EmptyDataText="There are no data records to display." ForeColor="#f9f9f9" 
        GridLines="None" Width="694px">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>


            <asp:CommandField ShowDeleteButton="True" ControlStyle-ForeColor="Red" HeaderStyle-BackColor="Black" />


            <asp:BoundField DataField="ApplicationName" HeaderText="ApplicationName" 
                SortExpression="ApplicationName" >

                    <HeaderStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="Black" BorderStyle="Dotted" BorderWidth="1px" />
                    <ItemStyle Wrap="False" />
                </asp:BoundField>


            <asp:BoundField DataField="LoweredApplicationName" 
                HeaderText="LoweredApplicationName" SortExpression="LoweredApplicationName" >

                    <HeaderStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="Black" BorderStyle="Dotted" BorderWidth="1px" />
                    <ItemStyle Wrap="False" />
                </asp:BoundField>


            <asp:BoundField DataField="ApplicationId" HeaderText="ApplicationId" 
                ReadOnly="True" SortExpression="ApplicationId" >

                    <HeaderStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="Black" BorderStyle="Dotted" BorderWidth="1px" />
                    <ItemStyle Wrap="False" />
                </asp:BoundField>


            <asp:BoundField DataField="Description" HeaderText="Description" 
                SortExpression="Description" >

                    <HeaderStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="Black" BorderStyle="Dotted" BorderWidth="1px" />
                    <ItemStyle Wrap="False" />
                </asp:BoundField>

	       <asp:HyperLinkField DataNavigateUrlFields="ApplicationId" 
                    DataNavigateUrlFormatString="~/LockedDown/Applications_subChild_UpdateRecord.aspx?ApplicationId={0}" 
                    Text="Edit" 
                    HeaderStyle-BorderColor="Black" 
                    HeaderStyle-BackColor="Black">
					<HeaderStyle BackColor="Black" BorderColor="Black" BorderStyle="Solid"></HeaderStyle>
                </asp:HyperLinkField>


        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#4b6c9e" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>

</p>
    <p>

        <asp:HyperLink ID="HyperLink2" runat="server" 
            NavigateUrl="~/LockedDown/Applications_subChild_NewRecord.aspx">Add New Application</asp:HyperLink>

    </p>

    <p>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:SHAREPOINT01_aspnetdb %>" 
        DeleteCommand="DELETE FROM [aspnet_Applications] WHERE [ApplicationId] = @ApplicationId" 
        InsertCommand="INSERT INTO [aspnet_Applications] ([ApplicationName], [LoweredApplicationName], [ApplicationId], [Description]) VALUES (@ApplicationName, @LoweredApplicationName, @ApplicationId, @Description)" 
        ProviderName="<%$ ConnectionStrings:SHAREPOINT01_aspnetdb.ProviderName %>" 
        SelectCommand="SELECT [ApplicationName], [LoweredApplicationName], [ApplicationId], [Description] FROM [aspnet_Applications]" 
        UpdateCommand="UPDATE [aspnet_Applications] SET [ApplicationName] = @ApplicationName, [LoweredApplicationName] = @LoweredApplicationName, [Description] = @Description WHERE [ApplicationId] = @ApplicationId">
        <DeleteParameters>
            <asp:Parameter Name="ApplicationId" Type="Object" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="ApplicationName" Type="String" />
            <asp:Parameter Name="LoweredApplicationName" Type="String" />
            <asp:Parameter Name="ApplicationId" Type="Object" />
            <asp:Parameter Name="Description" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="ApplicationName" Type="String" />
            <asp:Parameter Name="LoweredApplicationName" Type="String" />
            <asp:Parameter Name="Description" Type="String" />
            <asp:Parameter Name="ApplicationId" Type="Object" />
        </UpdateParameters>
    </asp:SqlDataSource>


</p>


</asp:Content>
