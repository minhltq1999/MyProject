<%@ Page Title="" Language="C#" MasterPageFile="~/View/PageNavigation.Master" AutoEventWireup="true" CodeBehind="ViewBill.aspx.cs" Inherits="CoffeeShopManagement.View.ViewBill" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        @import url('https://fonts.googleapis.com/css?family=Titillium+Web&display=swap');
       
        .catStyle{
            background-color: burlywood;
            margin: 30px;
            width: fit-content;
        }
        .catStyle a {

            font-size: 18px;
            color: white;
            text-align: center;
            padding: 14px 16px;
            text-decoration: none;
        }

        .navbar {
            overflow: hidden;
            background-color: #9f6060;
        }

        .navbar .menu a {
            float: left;
            font-size: 18px;
            color: white;
            text-align: center;
            padding: 14px 16px;
            text-decoration: none;
        }

        .navbar .b {
            float: right;
            font-size: 18px;
            color: #f2dca6;
            text-align: center;
            text-decoration: none;
        }

        .navbar a:hover, .dropdown:hover .dropbtn {
            background-color: orangered;
        }

        a:link, a:visited {
            color: white;
            padding: 14px 25px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
        } 
    </style>
    <div style="margin-left:auto; margin-right:auto;width:200px;">    
    <table>
        <tr>
            <td>
                <asp:Label ID="lbUserName" runat="server" Text="User Name: "></asp:Label>
            </td>
            <td>
                <asp:Label ID="txtUserName" runat="server"></asp:Label><br />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbFullName" runat="server" Text="Full Name: "></asp:Label>
            </td>
            <td>
                <asp:Label ID="txtFullName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbPhone" runat="server" Text="Phone number: "></asp:Label>
            </td>
            <td>
                <asp:Label ID="txtPhone" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbEmail" runat="server" Text="Email: "></asp:Label>
            </td>
            <td>
                <asp:Label ID="txtEmail" runat="server"></asp:Label><br />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbAddress" runat="server" Text="Address: "></asp:Label>
            </td>
            <td>
                <asp:Label ID="txtAddress" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    </div>
    <br />
    <br />
  <div style="margin-left:auto; margin-right:auto;width:450px;">
    <asp:GridView ID="gvBill" runat="server" CellPadding="4" AutoGenerateColumns="False" ForeColor="Black" GridLines="None" >
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField HeaderText="OrderId" DataField="orderId"/>
            <asp:BoundField HeaderText="Time" DataField="time"/>
            <asp:BoundField HeaderText="Total" DataField="total"/>
            <asp:HyperLinkField ItemStyle-ForeColor="Black" DataNavigateUrlFields="orderId" DataNavigateUrlFormatString="ViewOrderDetail.aspx?orderId={0}" HeaderText="View Detail" Text="View Detail" ControlStyle-ForeColor="Black"/>
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
</asp:Content>
