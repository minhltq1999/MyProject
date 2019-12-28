<%@ Page Title="" Language="C#" MasterPageFile="~/AdminView/AdminNavigate.Master" AutoEventWireup="true" CodeBehind="AdminViewOrderDetail.aspx.cs" Inherits="CoffeeShopManagement.AdminView.AdminViewOrderDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div style="margin-top: 100px"z>
    <asp:GridView ID="gvDetail" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" ShowFooter="True">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField HeaderText="Coffee" DataField="name"/>
            <asp:BoundField HeaderText="Quantity" DataField="QuantityCart"/>
             <asp:TemplateField HeaderText="Total" FooterStyle-HorizontalAlign="Center">
                    <FooterTemplate>
                        <asp:Label ID="lbTotal" runat="server" style="text-align: center" Text="0.0" ></asp:Label>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" style="text-align: center" Text='<%# Eval("Total") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
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
    <asp:Button ID="Button1" runat="server" Text="Back" OnClick="Button1_Click" />
        </div>
</asp:Content>
