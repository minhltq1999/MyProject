using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using System.Data;
namespace CoffeeShopManagement.View
{
    public partial class ShoppingOnline : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] != null)
            {
                Response.Redirect(@"~\AdminView\AdminSearchCoffee.aspx");
            }
            if (!Page.IsPostBack)
            {
                LoadCoffeeType();
                LoadCoffee(1);
            }
        }

        protected void dlCategory_ItemCommand(object source, DataListCommandEventArgs e)
        {
            int id = Convert.ToInt16(e.CommandArgument);
            LoadCoffee(id);
        }

        private void LoadCoffeeType()
        {
            CoffeeTypeDAO dao = new CoffeeTypeDAO();
            DataTable data = dao.GetAllCoffeeType();
            dlCategory.DataSource = data;
            dlCategory.DataBind();
        }

        private void LoadCoffee(int id)     
        {
            CoffeeDAO dao = new CoffeeDAO();
            DataTable da = dao.GetCoffeeByType(id);
            dlProducts.DataSource = da;
            dlProducts.DataBind();
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            string id = ((LinkButton)sender).CommandArgument;
            
            Cart cart = (Cart)Session["cart"];
            if (cart == null)
            {
                cart = new Cart();
            }
            cart.AddToCart(id);
            Session.Add("cart", cart);
        }        
    }
}