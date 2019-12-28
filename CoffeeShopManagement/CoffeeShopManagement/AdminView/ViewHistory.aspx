<%@ Page Title="" Language="C#" MasterPageFile="~/AdminView/AdminNavigate.Master" AutoEventWireup="true" CodeBehind="ViewHistory.aspx.cs" Inherits="CoffeeShopManagement.AdminView.ViewHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div style="margin-top: 100px">
        <asp:Label ID="Label1" runat="server" Text="Select Date to view" ForeColor="Black"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" TextMode="Date" Style="margin-bottom: 6px" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
    </div> 
        <asp:GridView ID="gvHistory" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="575px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField HeaderText="Order ID" DataField="OrderID" />
                <asp:BoundField HeaderText="User Full Name" DataField="User.fullName" />
                <asp:BoundField HeaderText="Time" DataField="Time" />
                <asp:BoundField HeaderText="Total" DataField="Total" />
                <asp:HyperLinkField DataNavigateUrlFields="orderId" DataNavigateUrlFormatString="AdminViewOrderDetail.aspx?orderId={0}" HeaderText="View Detail" Text="View Detail" ControlStyle-ForeColor="Black"/>
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
 
</asp:Content>
