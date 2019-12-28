using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Model;

namespace CoffeeShopManagement.View
{
    public partial class ViewBill : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //UserDetailDAO dao = new UserDetailDAO();
            UserDetailDTO user = (UserDetailDTO)Session["user"];
            OrderDAO order = new OrderDAO();
            if (user != null)
            {
                txtUserName.Text = user.username;
                txtFullName.Text = user.fullName;
                txtPhone.Text = user.phone;
                txtEmail.Text = user.email;
                txtAddress.Text = user.address;

                List<OrderDTO> orderId = order.GetOrderByUserID(user.userID);
                gvBill.DataSource = orderId;
                gvBill.DataBind();
            }

        }


    }
}