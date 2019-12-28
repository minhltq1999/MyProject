<%@ Page Title="" Language="C#" MasterPageFile="~/View/PageNavigation.Master" AutoEventWireup="true" CodeBehind="ShoppingOnline.aspx.cs" Inherits="CoffeeShopManagement.View.ShoppingOnline" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        @import url('https://fonts.googleapis.com/css?family=Titillium+Web&display=swap');
        
        body {
            background-image: url(~\img\background.jpg);
        }
        .thar-three {
            color: white;
	        width: 265px;
	        background: black;
	        content: "\f10e";
            cursor: pointer;
            display: block;
            position: relative;
            
            transition: all 0.5s;
	    }
	    .thar-three:hover {
		    color: black !important;
		    background-color: transparent;
		   
	    }

	    .thar-three:hover a{
			    color:pink;	
		    }
	
	    .thar-three:hover:before {
		    left: 0%;
		    right: auto;
		    width: 100%;
	    }
	    .thar-three:before {
		    display: block;
		    position: absolute;
		    top: 0px;
		    right: 0px;
		    height: 100%;
		    width: 0px;
		    z-index: -1;
		    content: '';
		    
		    background: #3366FF;
		    transition: all 0.5s;
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

        .navbar a:hover, .dropdown:hover .dropbtn 
        {
            background-color: orangered;
        }

        a:link, a:visited {
            color: white;
            padding: 14px 25px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
        } 
        .style1 {
            width: 900px;
        }

        .style2 {
            text-align:left;
            width:623;
        }

        .style3 {
            width: 267px;
            text-align:center;
        }

        .style4 {
            width: 185px;
            text-align: center;
        }

        .style6 {
            width:260px;
            text-align: left;
        }
    </style>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="style1">
                <%--CHOOSE YOUR COFFEE --%>
                <tr>
                    <td>
                        <table class="style1" style="border: thin ridge">
                            <tr>
                                <td class="style2">
                                    <asp:Label ID="lblCategoryName" runat="server" Font-Size="15pt" ForeColor="#ff6600">Choose your coffee</asp:Label>
                                </td>
                                <td class="style3" style="border-left-style: ridge; border-width: medium; border-color: deeppink">
                                    <asp:Label ID="lblProducts" runat="server" Text="Products" Font-Size="15pt" ForeColor="Black">
                                    </asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <%--COFFEE --%>
                <tr>
                    <td>
                        <table class="style1">
                            <tr>
                                <td class="style2">
                                    <asp:Panel ID="pnlProducts" runat="server" ScrollBars="Auto" Height="500px" BorderColor="Black" BorderStyle="Inset" BorderWidth="1px">
                                        <asp:DataList ID="dlProducts" runat="server" RepeatColumns="1" Width="600px"
                                            DataKeyField="coffeeId" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black">
                                            <AlternatingItemStyle BackColor="PaleGoldenrod" />
                                            <FooterStyle BackColor="Tan" />
                                            <HeaderStyle BackColor="Tan" Font-Bold="True" />
                                            <ItemTemplate >
                                                <div style="text-align: center">
                                                    name: <asp:Label ID="nameLabel" runat="server" Text='<%# Bind("name") %>'/> 
                                                </div>
                                                <br />
                                                <div style="text-align: center">
                                                    price: <asp:Label ID="priceLabel" runat="server" Text='<%# Bind("price") %>' />
                                                </div>
                                                <br />
                                                <div style="text-align: center">
                                                    <asp:LinkButton ID="btnAddToCart" runat="server" ForeColor="White" CssClass="thar-three" OnClick="btnAddToCart_Click" Text="Add to cart" CommandArgument='<%#Bind("coffeeID") %>' />
                                                </div>
                                                <br />
                                            </ItemTemplate>
                                            <SelectedItemStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                        </asp:DataList>
                                    </asp:Panel>
                                </td>
                                <%--CATEGORY --%>
                                <td class="style3">
                                    <asp:Panel ID="pnlCategory" runat="server" BackColor="White" Height="500px" BorderColor="Black" BorderStyle="Inset" BorderWidth="1px" ScrollBars="Auto">
                                        <asp:DataList ID="dlCategory" runat="server" BorderStyle="Ridge" CellPadding="3" Width="252px" 
                                            DataKeyField="typeId" BackColor="White" BorderColor="White" BorderWidth="2px" CellSpacing="1" OnItemCommand="dlCategory_ItemCommand">
                                            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                                            <ItemStyle BackColor="#DEDFDE" ForeColor="Black" />
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkCate" runat="server" CommandArgument='<%# Eval("typeId") %>'
                                                    Text='<%# Eval("name") %>' ForeColor="White" CssClass="thar-three"></asp:LinkButton>
                                                <br />
                                            </ItemTemplate>
                                            <SelectedItemStyle BackColor="#9471DE" Font-Bold="true" ForeColor="White" />
                                        </asp:DataList>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <%--TYPE COFFEE--%>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
