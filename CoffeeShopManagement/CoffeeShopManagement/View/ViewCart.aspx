<%@ Page Title="" Language="C#" MasterPageFile="~/View/PageNavigation.Master" AutoEventWireup="true" CodeBehind="ViewCart.aspx.cs" Inherits="CoffeeShopManagement.View.ViewCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >   
    <style>
        @import url('https://fonts.googleapis.com/css?family=Titillium+Web&display=swap');
        body {
            background-image: url('~\img\background.jpg');
            background-size: cover;
            background-repeat: no-repeat;
            width: 100vw;
            height: 100vh;
            background-color: #e0e0e0;
            overflow: hidden;
            font-size: 18px;
            color: cornsilk;
            font-family: 'Titillium Web', sans-serif;
        }

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

        .dropdown {
            float: left;
            overflow: hidden;
        }

        .dropdown .dropbtn {
            font-size: 18px;  
            border: none;
            outline: none;
            color: #1abc9c;
            padding: 14px 16px;

            font-family: inherit;
            margin: 0;
        }

        .navbar a:hover, .dropdown:hover .dropbtn {
            background-color: orangered;
        }

        .dropdown-content {
            display: none;
            position: absolute;
            background-color: #ffd7dd;
            min-width: 160px;
            box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
            z-index: 1;
        }

        .dropdown-content a {
            float: none;
            color: black;
            padding: 12px 16px;
            text-decoration: none;
            display: block;
            text-align: left;
        }

        .dropdown-content a:hover {
            background-color: activeborder;
        }

        .dropdown:hover .dropdown-content {
            display: block;
        }

        a:link, a:visited {
            color: white;
            padding: 14px 25px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
        }

        a:hover, a:active {
            background-color: pink;}

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
        }

        .btn span {
            position: relative; 
            z-index: 1;
        }

       
        
    </style>
    <div style="margin-left:auto; margin-right:auto;width:600px;">
    <asp:GridView ID="gvCart" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" ShowFooter="True" DataKeyNames="coffeeID">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField HeaderText="Coffee" DataField="name"/>
                <asp:BoundField HeaderText="Price" DataField="price"/>
                
                <asp:TemplateField HeaderText="Quantity">
                    <ItemTemplate>
                        <asp:TextBox ID="txtQuantity" TextMode="Number" Text='<%#Eval("QuantityCart") %>' runat="server" AutoPostBack="true" OnTextChanged="txtQuantity_TextChanged" onKeyUp="CalculateTotal();" onClick="CalculateTotal();" ></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Total" FooterStyle-HorizontalAlign="Center">
                    <FooterTemplate>
                        <asp:Label ID="lbTotal" runat="server" style="text-align: center" Text="0.0" ></asp:Label>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" style="text-align: center" Text='<%# Eval("Total") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Remove">
                    <ItemTemplate>  
                        <asp:LinkButton ID="lbtRemove" runat="server" ForeColor="Black" CommandArgument='<%#Bind("coffeeID") %>' Text="Remove" OnClick="lbtRemove_Click"></asp:LinkButton>
                    </ItemTemplate>
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
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    <div class="btn">
        <span>
            <asp:Button ID="btnCheckout" runat="server" Text="Check Out" OnClick="btnCheckout_Click" />
        </span>
    </div>  
 
</asp:Content>
