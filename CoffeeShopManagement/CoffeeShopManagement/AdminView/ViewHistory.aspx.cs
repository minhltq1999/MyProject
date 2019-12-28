using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
namespace CoffeeShopManagement.AdminView
{
    public partial class ViewHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect(@"~\View\HomePage.aspx");
            }
            if (!Page.IsPostBack)
            {
            loadData();
            }
        }
        private void loadData()
        {
            OrderDAO dao = new OrderDAO();
            List<OrderDTO> result = dao.GetAllOrder();
            gvHistory.DataSource = result;
            gvHistory.DataBind();
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (Session["admin"] != null)
            {
                TextBox textbox = (TextBox)sender;
                DateTime time1 = DateTime.Parse(textbox.Text);
                DateTime time2 = time1.AddHours(23).AddMinutes(59).AddSeconds(59);
                OrderDAO dao = new OrderDAO();
                List<OrderDTO> result = dao.GetAllOrderByDate(time1, time2);
                gvHistory.DataSource = result;
                gvHistory.DataBind();
            }
            else
            {
                Response.Redirect(@"~\View\HomePage.aspx");
            }
        }
    }
}