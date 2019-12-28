using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;

namespace CoffeeShopManagement.AdminView
{
    public partial class AdminViewOrderDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int orderId = int.Parse(Request["orderID"]);
            OrderCoffeeDetailDAO dao = new OrderCoffeeDetailDAO();
            Cart cart = dao.GetOrderDetail(orderId);
            gvDetail.DataSource = cart.GetCartDetail();
            gvDetail.DataBind();
            Label label = (Label)gvDetail.FooterRow.FindControl("lbTotal");
            label.Text = cart.Total.ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["admin"] != null)
            {
                Response.Redirect(@"~\AdminView\ViewHistory.aspx");
            }
            else
            {
                Response.Redirect(@"~\View\HomePage.aspx");
            }
        }
    }
}