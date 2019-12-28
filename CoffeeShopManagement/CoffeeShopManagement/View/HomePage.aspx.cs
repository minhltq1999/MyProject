using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
namespace CoffeeShopManagement.View
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                Panel1.Visible = false;
            }
            if (Session["admin"] != null)
            {
                Response.Redirect(@"~\AdminView\AdminSearchCoffee.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            UserDetailDAO userDetailDAO = new UserDetailDAO();
            UserDetailDTO user = userDetailDAO.CheckLogin(txtUserId.Text, txtPassword.Text);
            if (user != null)
            {
                switch (user.role)
                {
                    case 2:
                        Session["admin"] = user;
                        Response.Redirect(@"~\AdminView\AdminSearchCoffee.aspx");
                        if (Session["cart"] != null)
                        {
                            Session.Remove("cart");
                        }
                        break;
                    case 3:
                        Session["user"] = user;
                        Response.Redirect(@"~\View\HomePage.aspx");
                        break;                    
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Incorrect username or password');", true);
            }
        }
    }
}