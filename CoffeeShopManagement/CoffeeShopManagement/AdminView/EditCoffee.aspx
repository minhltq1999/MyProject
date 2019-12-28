<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditCoffee.aspx.cs" Inherits="CoffeeShopManagement.AdminView.EditCoffee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            zz
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
        a {
            font-size: 16px;
            color: white;
        }
        .tableStyle {
           border-width: thin;
           border-color: #9f6060;            
        }
        .inputColor {
            color: grey;
            opacity: 0.8;
        }
        .form-style-5{
            max-width: 500px;
            padding: 10px 20px;
            background: #f4f7f8;
            margin: 10px auto;
            padding: 20px;
            background: #f4f7f8;
            border-radius: 8px;
            font-family: Georgia, "Times New Roman", Times, serif;
            color:black;
        }
        .form-style-5 fieldset{
            border: none;
        }
        .form-style-5 legend {
            font-size: 1.4em;
            margin-bottom: 10px;
            color: black;
        }
        .form-style-5 label {
            display: block;
            margin-bottom: 8px;
        }
        .form-style-5 input[type="text"],
        .form-style-5 input[type="date"],
        .form-style-5 input[type="datetime"],
        .form-style-5 input[type="email"],
        .form-style-5 input[type="number"],
        .form-style-5 input[type="search"],
        .form-style-5 input[type="time"],
        .form-style-5 input[type="url"],
        .form-style-5 textarea,
        .form-style-5 select {
            font-family: Georgia, "Times New Roman", Times, serif;
            background: rgba(255,255,255,.1);
            border: none;
            border-radius: 4px;
            font-size: 15px;
            margin: 0;
            outline: 0;
            padding: 10px;
            width: 100%;
            box-sizing: border-box; 
            -webkit-box-sizing: border-box;
            -moz-box-sizing: border-box; 
            background-color: #e8eeef;
            color:#8a97a0;
            -webkit-box-shadow: 0 1px 0 rgba(0,0,0,0.03) inset;
            box-shadow: 0 1px 0 rgba(0,0,0,0.03) inset;
            margin-bottom: 30px;
        }
        .form-style-5 input[type="text"]:focus,
        .form-style-5 input[type="date"]:focus,
        .form-style-5 input[type="datetime"]:focus,
        .form-style-5 input[type="email"]:focus,
        .form-style-5 input[type="number"]:focus,
        .form-style-5 input[type="search"]:focus,
        .form-style-5 input[type="time"]:focus,
        .form-style-5 input[type="url"]:focus,
        .form-style-5 textarea:focus,
        .form-style-5 select:focus{
            background: #d2d9dd;
        }
        .form-style-5 select{
            -webkit-appearance: menulist-button;
            height:35px;
        }
        .form-style-5 .number {
            background: #1abc9c;
            color: #fff;
            height: 30px;
            width: 30px;
            display: inline-block;
            font-size: 0.8em;
            margin-right: 4px;
            line-height: 30px;
            text-align: center;
            text-shadow: 0 1px 0 rgba(255,255,255,0.2);
            border-radius: 15px 15px 15px 0px;
        }

        .form-style-5 input[type="submit"],
        .form-style-5 input[type="button"]
        {
            position: relative;
            display: block;
            padding: 19px 39px 18px 39px;
            color: #FFF;
            margin: 0 auto;
            background: #1abc9c;
            font-size: 18px;
            text-align: center;
            font-style: normal;
            width: 100%;
            border: 1px solid #16a085;
            border-width: 1px 1px 3px;
            margin-bottom: 10px;
        }
        .form-style-5 input[type="submit"]:hover,
        .form-style-5 input[type="button"]:hover
        {
            background: #109177;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-style-5">
            <legend><span class="number">1</span> Coffee Info</legend>
            Coffee ID                 
                <asp:TextBox ID="txtId" runat="server" ReadOnly="true"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Tea ID is required" ControlToValidate="txtId" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />

            Coffee Name 
               
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Tea Name is required" ControlToValidate="txtName" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="lbNameError" runat="server" ForeColor="Red" Visible="False"></asp:Label>
            
            <br />
            Description                
        <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Description is required" ControlToValidate="txtDescription" ForeColor="Red"></asp:RequiredFieldValidator>
            
            <br />
            Price                
        <asp:TextBox ID="txtPrice" runat="server" TextMode="Number" Text="0"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Price is required" ControlToValidate="txtPrice" ForeColor="Red" ValidationExpression="(\d+[\.\d+])"></asp:RegularExpressionValidator>
            <br />
            Category
               
        <asp:DropDownList ID="cbmSelectedTea" runat="server" DataTextField="name" DataValueField="typeId"></asp:DropDownList>

            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="false" OnClick="btnCancel_Click" />
        </div>
    </form>
</body>
</html>
