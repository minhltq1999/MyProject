using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Model;
namespace CoffeeShopManagement.View
{
    public partial class ViewCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!Page.IsPostBack)
            {
                string message = Request["message"];
                // If the cart does not exist yet
                if (Session["cart"] == null)
                {
                    if (message == null)
                    {
                        Literal1.Text = "Sorry, Your shopping cart is empty";
                        this.btnCheckout.Visible = false;
                    }
                    else
                    {
                        Literal1.Text = message;
                        this.btnCheckout.Visible = false;
                    }                               
                }
                // If the cart exists
                else
                {
                    this.btnCheckout.Visible = true;
                    UpdateGridView();
                }
                             
            }
        }

        private void UpdateGridView()
        {
            Cart cart = (Cart)Session["cart"];
            if(Session["cart"] == null)
            {
                Literal1.Text = "Sorry, Your shopping cart is empty";
                this.btnCheckout.Enabled = false;
            }
            else {
                if (cart != null)
                {
                    List<CoffeeDTO> detail = cart.GetCartDetail();
                    gvCart.DataSource = detail;
                    gvCart.DataBind();
                    Label label = (Label)gvCart.FooterRow.FindControl("lbTotal");
                    label.Text = cart.Total.ToString();
                }
            }           
        }

        protected void lbtRemove_Click(object sender, EventArgs e)
        {
            Cart cart = (Cart)Session["cart"];
            if (cart != null)
            {
                string id = ((LinkButton)sender).CommandArgument;
                cart.RemoveCart(id);
                Session.Add("cart", cart);
                List<CoffeeDTO> detail = cart.GetCartDetail();
                if(detail != null)
                {
                    gvCart.DataSource = detail;
                    gvCart.DataBind();
                    Literal1.Text = "" + detail.Count;
                }
                else
                {

                    Session.Add("cart", null);
                    this.btnCheckout.Enabled = false;
                    gvCart.DataSource = null;
                    gvCart.DataBind();
                    Literal1.Text = "Sorry, Your shopping cart is empty";
                }
                
            }
                      
            
        }

        protected void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            GridViewRow row = (GridViewRow)tb.NamingContainer;
            int i = row.RowIndex;
            string id = (string)gvCart.DataKeys[i].Value;
            Cart cart = (Cart)Session["cart"];

            if (tb.Text == "")
            {
                tb.Text = $"{cart.GetQuantity(id)}";
            }
            else if (tb.Text == "0")
            {
                tb.Text = $"{cart.GetQuantity(id)}";
            }
            else if (tb.Text.Contains("-")) { 
                tb.Text = $"{cart.GetQuantity(id)}";
            } else if (tb.Text == "0")
            {
                int quan = cart.GetQuantity(id);
                quan = 1;
                tb.Text = $"{quan}";
            }
            int quantity = Convert.ToInt16(tb.Text.ToString());

            
            if (cart != null)
            {
                cart.UpdateCart(id, quantity);
                UpdateGridView();
            }
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            UserDetailDTO user = (UserDetailDTO) Session["user"];
            
            if (user != null)
            {
                Cart cart = (Cart)Session["cart"];                
                List<CoffeeDTO> dto = cart.GetCartDetail();
                String now = DateTime.Now.ToString();
                float total = cart.Total;

                OrderDAO orderDAO = new OrderDAO();
                bool result1 = orderDAO.InsertToOrder(user.userID, total, now);

                if (result1)
                {
                    int orderID = orderDAO.GetOrderID(now, user.userID);
                    bool result2 = false;
                    int count = 0;
                    foreach (var item in dto)
                    {
                        OrderCoffeeDetailDAO orderDetailDAO = new OrderCoffeeDetailDAO();
                        result2 = orderDetailDAO.InsertToOrderDetail(item.QuantityCart, item.Total, item.coffeeID, orderID);
                        if (result2)
                            count++;
                    }
                    if (count == cart.Size)
                    {
                        Session.Remove("cart");
                        Response.Redirect(Page.Request.Path + "?message=Thank you for buying");                        
                    }
                }                
            }
            else
            {
                Response.Redirect(@"~\View\HomePage.aspx");
            }

        }
    }
}