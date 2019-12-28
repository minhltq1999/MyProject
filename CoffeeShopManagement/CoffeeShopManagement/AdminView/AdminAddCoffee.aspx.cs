using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
namespace CoffeeShopManagement.AdminView
{
    public partial class AdminAddCoffee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect(@"~\View\HomePage.aspx");
            }
            if (!Page.IsPostBack)
            {
                CoffeeTypeDAO dao = new CoffeeTypeDAO();
                DataTable data = dao.GetAllCoffeeType();
                cbmSelectedTea.DataSource = data;
                cbmSelectedTea.DataBind();
            }
        }

        protected void btnAction_Click(object sender, EventArgs e)
        {
            if (Session["admin"] != null)
            {            
                CoffeeDAO dao = new CoffeeDAO();
            
                if (dao.CheckDuplicate(txtId.Text))
                {
                    lbIDError.Visible = true;
                    lbIDError.Text = $"{txtId.Text} is already existed";
                }
                else
                {
                    CoffeeDTO coffee = new CoffeeDTO 
                    { 
                        coffeeID=txtId.Text,
                        name=txtName.Text,
                        description=txtDescription.Text,
                        price=float.Parse(txtPrice.Text),
                        type=int.Parse(cbmSelectedTea.SelectedValue)
                    };
                    bool result = dao.AddNewCoffee(coffee);
                    if (result)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Add Coffee Success');", true);
                        txtId.Text = "";
                        txtName.Text = "";
                        txtPrice.Text = "";
                        txtDescription.Text = "";
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