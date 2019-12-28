<%@ Page Title="" Language="C#" MasterPageFile="~/View/PageNavigation.Master" AutoEventWireup="true" CodeBehind="ViewOrderDetail.aspx.cs" Inherits="CoffeeShopManagement.View.ViewOrderDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .btn {
            border: none;
            display: block;
            text-align: center;
            cursor: pointer;
            text-transform: uppercase;
            outline: none;
            overflow: hidden;
            position: relative;
            color: #fff;
            font-weight: 700;
            font-size: 15px;
            padding: 17px 60px;
            margin: 0 auto;
        }a:link, a:visited {
            color: white;
            padding: 14px 25px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
        }
    </style>
    <div style="margin-left:auto; margin-right:auto;width:310px;">        
    <asp:GridView ID="gvDetail" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" ShowFooter="True">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField HeaderText="Coffee" DataField="name"/>
            <asp:BoundField HeaderText="Coffee ID" DataField="coffeeId" />
            <asp:BoundField HeaderText="Quantity" DataField="QuantityCart"/>
             <asp:TemplateField HeaderText="Total" FooterStyle-HorizontalAlign="Center">
                   
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" style="text-align: center" Text='<%# Eval("Total") %>'></asp:Label>
                    </ItemTemplate>
                  <FooterTemplate>
                        <asp:Label ID="lbTotal" runat="server" style="text-align: center" Text="0.0" ></asp:Label>
                    </FooterTemplate>
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
        </div>
    <div class="btn">
        <span>
            <asp:Button ID="Button1" runat="server" Text="Back" OnClick="Button1_Click" />
        </span>
    </div>
</asp:Content>
