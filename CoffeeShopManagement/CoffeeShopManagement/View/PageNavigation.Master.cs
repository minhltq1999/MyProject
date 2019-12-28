using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Model;
namespace CoffeeShopManagement
{
    public partial class PageNavigation : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                UserDetailDTO user = (UserDetailDTO)Session["user"];
                username.Text = $"Welcome {user.fullName}";
                username.Visible = true;
                logout.Visible = true;
                viewbill.Visible = true;
            }
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Session.Remove("user");
            if (Session["cart"] != null)
            {
                Session.Remove("cart");
            }
            Response.Redirect(@"~\View\HomePage.aspx");
        }

    }
}