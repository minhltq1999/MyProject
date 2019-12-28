<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="CoffeeShopManagement.SignIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
    <style>
        @import url('https://fonts.googleapis.com/css?family=Titillium+Web&display=swap');
    </style>
    <style type="text/css">
        body {
            background-image: url('Image/background.jpg');
            background-size: cover;
            background-repeat: no-repeat;
            width: 100vw;
            height: 100vh;
            background-color: #e0e0e0;
            overflow: hidden;
            font-size: 16px;
            color: #1abc9c;
            font-family: 'Titillium Web', sans-serif;
            overflow:scroll;
        }
        
        .form-style-10{
            width:450px;
            padding:30px;
            margin:0px auto;
            background: #FFF;
            border-radius: 10px;
            -webkit-border-radius:10px;
            -moz-border-radius: 10px;
            box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.13);
            -moz-box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.13);
            -webkit-box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.13);
        }
        .form-style-10 .inner-wrap{
            padding: 30px;
            background: #F8F8F8;
            border-radius: 6px;
            margin-bottom: 15px;
        }
        .form-style-10 h1{
            background: #2A88AD;
            padding: 20px 30px 15px 30px;
            margin: -30px -30px 30px -30px;
            border-radius: 10px 10px 0 0;
            -webkit-border-radius: 10px 10px 0 0;
            -moz-border-radius: 10px 10px 0 0;
            color: #fff;
            text-shadow: 1px 1px 3px rgba(0, 0, 0, 0.12);
            font: normal 30px 'Bitter', serif;
            -moz-box-shadow: inset 0px 2px 2px 0px rgba(255, 255, 255, 0.17);
            -webkit-box-shadow: inset 0px 2px 2px 0px rgba(255, 255, 255, 0.17);
            box-shadow: inset 0px 2px 2px 0px rgba(255, 255, 255, 0.17);
            border: 1px solid #257C9E;
        }
        .form-style-10 h1 > span{
            display: block;
            margin-top: 2px;
            font: 13px Arial, Helvetica, sans-serif;
        }
        .form-style-10 label{
            display: block;
            font: 13px Arial, Helvetica, sans-serif;
            color: #888;
            margin-bottom: 15px;
        }
        .form-style-10 input[type="text"],.form-style-10 input[type="phone"],
        .form-style-10 input[type="date"],
        .form-style-10 input[type="datetime"],
        .form-style-10 input[type="email"],
        .form-style-10 input[type="number"],
        .form-style-10 input[type="search"],
        .form-style-10 input[type="time"],
        .form-style-10 input[type="url"],
        .form-style-10 input[type="password"],
        .form-style-10 textarea,
        .form-style-10 select {
            display: block;
            box-sizing: border-box;
            -webkit-box-sizing: border-box;
            -moz-box-sizing: border-box;
            width: 100%;
            padding: 8px;
            border-radius: 6px;
            -webkit-border-radius:6px;
            -moz-border-radius:6px;
            border: 2px solid #fff;
            box-shadow: inset 0px 1px 1px rgba(0, 0, 0, 0.33);
            -moz-box-shadow: inset 0px 1px 1px rgba(0, 0, 0, 0.33);
            -webkit-box-shadow: inset 0px 1px 1px rgba(0, 0, 0, 0.33);
        }

        .form-style-10 .section{
            font: normal 20px 'Bitter', serif;
            color: #2A88AD;
            margin-bottom: 5px;
        }
        .form-style-10 .section span {
            background: #2A88AD;
            padding: 5px 10px 5px 10px;
            position: absolute;
            border-radius: 50%;
            -webkit-border-radius: 50%;
            -moz-border-radius: 50%;
            border: 4px solid #fff;
            font-size: 14px;
            margin-left: -45px;
            color: #fff;
            margin-top: -3px;
        }
        .form-style-10 input[type="button"], 
        .form-style-10 input[type="submit"]{
            align-items:center;
            background: #2A88AD;
            padding: 8px 20px 8px 20px;
            border-radius: 5px;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            color: #fff;
            text-shadow: 1px 1px 3px rgba(0, 0, 0, 0.12);
            font: normal 30px 'Bitter', serif;
            -moz-box-shadow: inset 0px 2px 2px 0px rgba(255, 255, 255, 0.17);
            -webkit-box-shadow: inset 0px 2px 2px 0px rgba(255, 255, 255, 0.17);
            box-shadow: inset 0px 2px 2px 0px rgba(255, 255, 255, 0.17);
            border: 1px solid #257C9E;
            font-size: 15px;
        }
        .form-style-10 input[type="button"]:hover, 
        .form-style-10 input[type="submit"]:hover{
            background: #2A6881;
            -moz-box-shadow: inset 0px 2px 2px 0px rgba(255, 255, 255, 0.28);
            -webkit-box-shadow: inset 0px 2px 2px 0px rgba(255, 255, 255, 0.28);
            box-shadow: inset 0px 2px 2px 0px rgba(255, 255, 255, 0.28);
        }
        .form-style-10 .privacy-policy{
            float: right;
            width: 250px;
            font: 12px Arial, Helvetica, sans-serif;
            color: #4D4D4D;
            margin-top: 10px;
            text-align: right;
        }
    </style>
</head>
<body>
    <form runat="server">
        <div class="form-style-10">
            <div class="section"><b>REGISTER</b></div>
            <div class="inner-wrap">
                User Name
                <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                <asp:Label ID="usernameError" runat="server" Text="Label" Visible="False" ForeColor="#CC0000"></asp:Label><br />
                <asp:RequiredFieldValidator ID="UsernameValidate" runat="server" ErrorMessage="Username is required" ControlToValidate="txtUserName" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                <br />
                Password
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Password is required" ControlToValidate="txtPassword" ForeColor="Red"></asp:RequiredFieldValidator><br />
                <br />
                Confirm
                <asp:TextBox ID="txtConfirm" runat="server" TextMode="Password"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirm" ErrorMessage="Cofirm is not match" ForeColor="Red"></asp:CompareValidator>
                <br />
                <br />
                Full Name
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Full Name is required" ControlToValidate="txtName" ForeColor="Red"></asp:RequiredFieldValidator><br />
                <br />
                Address
                <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Address is required" ControlToValidate="txtAddress" ForeColor="Red"></asp:RequiredFieldValidator><br />
                <br />
                Email
                <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Email is required" ControlToValidate="txtEmail" ForeColor="Red"></asp:RequiredFieldValidator><br />
                <br />
                Phone
                <asp:TextBox ID="txtPhone" runat="server" ></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Phone is required" ControlToValidate="txtPhone" ForeColor="Red" ValidationExpression="^(0)\d{9,10}$"></asp:RegularExpressionValidator><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Phone empty" ControlToValidate="txtPhone" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>

            <div class="button-section">
                <asp:Button ID="btnAction" runat="server" Text="Register" OnClick="btnAction_Click" />
            </div>
            <div class="button-section">
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CausesValidation="false"/>
            </div>
        </div>
    </form>
</body>
</html>
