using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;

namespace CoffeeShopManagement.View
{
    public partial class ViewOrderDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {            
                int orderId = int.Parse(Request["orderId"]);
                OrderCoffeeDetailDAO dao = new OrderCoffeeDetailDAO();
                Cart cart = dao.GetOrderDetail(orderId);
                gvDetail.DataSource = cart.GetCartDetail();
                gvDetail.DataBind();

                var label = (Label)gvDetail.FooterRow.FindControl("lbTotal");
                label.Text = cart.Total.ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                Response.Redirect(@"~\View\ViewBill.aspx");
            }
            else
            {
                Response.Redirect(@"~\View\HomePage.aspx");
            }
        }

    }
}