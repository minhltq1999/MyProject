<%@ Page Title="" Language="C#" MasterPageFile="~/View/PageNavigation.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="CoffeeShopManagement.View.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        @import url('https://fonts.googleapis.com/css?family=Titillium+Web&display=swap');       
        
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
    </style>
    <div class="scroll-down">
        SCROLL DOWN
            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 32 32">
                <path d="M16 3C8.832031 3 3 8.832031 3 16s5.832031 13 13 13 13-5.832031 13-13S23.167969 3 16 3zm0 2c6.085938 0 11 4.914063 11 11 0 6.085938-4.914062 11-11 11-6.085937 0-11-4.914062-11-11C5 9.914063 9.914063 5 16 5zm-1 4v10.28125l-4-4-1.40625 1.4375L16 23.125l6.40625-6.40625L21 15.28125l-4 4V9z" />
            </svg>
    </div>
    <div class="container"></div>

    <asp:Panel ID="Panel1" runat="server" Visible="true">
        <div class="modal">
            <div class="modal-container">
                <div class="modal-left">
                    <h1 class="modal-title">Welcome!</h1>
                    <p class="modal-desc">If we always try our best, we can gain such a incredible things in life.</p>

                    <div class="input-block">
                        <label for="text" class="input-label">Your ID</label>
                        <asp:TextBox ID="txtUserId" runat="server"></asp:TextBox>
                    </div>
                    <div class="input-block">
                        <label for="password" class="input-label">Password</label>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                    </div>
                    <div class="modal-buttons">
                        <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="input-button" OnClick="btnLogin_Click" />
                    </div>
                    <p class="sign-up">Don't have an account? <a href="SignIn.aspx" style="color: black">Sign up now</a></p>
                </div>
                <div class="modal-right">
                    <img src="../img/bgLogin.jpg" alt="">
                </div>
                <button class="icon-button close-button">
                    <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 50 50">
                        <path d="M 25 3 C 12.86158 3 3 12.86158 3 25 C 3 37.13842 12.86158 47 25 47 C 37.13842 47 47 37.13842 47 25 C 47 12.86158 37.13842 3 25 3 z M 25 5 C 36.05754 5 45 13.94246 45 25 C 45 36.05754 36.05754 45 25 45 C 13.94246 45 5 36.05754 5 25 C 5 13.94246 13.94246 5 25 5 z M 16.990234 15.990234 A 1.0001 1.0001 0 0 0 16.292969 17.707031 L 23.585938 25 L 16.292969 32.292969 A 1.0001 1.0001 0 1 0 17.707031 33.707031 L 25 26.414062 L 32.292969 33.707031 A 1.0001 1.0001 0 1 0 33.707031 32.292969 L 26.414062 25 L 33.707031 17.707031 A 1.0001 1.0001 0 0 0 32.980469 15.990234 A 1.0001 1.0001 0 0 0 32.292969 16.292969 L 25 23.585938 L 17.707031 16.292969 A 1.0001 1.0001 0 0 0 16.990234 15.990234 z"></path>
                    </svg>
                </button>
            </div>
            <input type="button" id="lbLogin" runat="server" class="modal-button" value="Click here to login" />
        </div>
    </asp:Panel>
    
    <script>
        var body = document.querySelector("body");
        var modal = document.querySelector(".modal");
        var modalButton = document.querySelector(".modal-button");
        var closeButton = document.querySelector(".close-button");
        var scrollDown = document.querySelector(".scroll-down");
        var isOpened = false;

        var openModal = function openModal() {
            modal.classList.add("is-open");
            body.style.overflow = "hidden";
        };

        var closeModal = function closeModal() {
            modal.classList.remove("is-open");
            body.style.overflow = "initial";
        };

        window.addEventListener("scroll", function () {
            if (window.scrollY > window.innerHeight / 3 && !isOpened) {
                isOpened = true;
                scrollDown.style.display = "none";
                openModal();
            }
        });
        modalButton.addEventListener("click", openModal);
        closeButton.addEventListener("click", closeModal);

        document.onkeydown = function (evt) {
            evt = evt || window.event;
            evt.keyCode === 27 ? closeModal() : false;
        };
    </script>
</asp:Content>
