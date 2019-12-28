using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
namespace CoffeeShopManagement.AdminView
{
    public partial class EditCoffee : System.Web.UI.Page
    {
        CoffeeDAO dao = new CoffeeDAO();       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect(@"~\View\HomePage.aspx");
            }

            var id = Request.QueryString["coffeeID"];
            if (!Page.IsPostBack) { 
                try {                    
                    CoffeeDTO coffee = dao.GetCoffeeByID(id);
                    txtId.Text = coffee.coffeeID;
                    txtName.Text = coffee.name;
                    txtDescription.Text = coffee.description;
                    txtPrice.Text = coffee.price.ToString();

                    CoffeeTypeDAO typeDAO = new CoffeeTypeDAO();
                    DataTable data = typeDAO.GetAllCoffeeType();
                    cbmSelectedTea.DataSource = data;
                    cbmSelectedTea.DataBind();
                    cbmSelectedTea.SelectedValue = coffee.type.ToString();
                }catch(SqlException ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Session["admin"] != null)
            {            
                if (dao.CheckDuplicateForUpdate(txtId.Text, txtName.Text))
                {
                    lbNameError.Visible = true;
                    lbNameError.Text = $"{txtName.Text} is already existed";
                }
                else
                {
                    CoffeeDTO coffee = new CoffeeDTO 
                    {
                        coffeeID = txtId.Text, 
                        name=txtName.Text,
                        description = txtDescription.Text, 
                        price=float.Parse(txtPrice.Text),
                        type=int.Parse(cbmSelectedTea.SelectedValue)
                    };
                    bool result = dao.UpdateCoffee(coffee);
                    if (result)
                    {
                        Response.Redirect(@"~\AdminView\AdminSearchCoffee.aspx");
                    }
                }
            }
            else
            {
                Response.Redirect(@"~\View\HomePage.aspx");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (Session["admin"] != null)
            {
                Response.Redirect(@"~\AdminView\AdminSearchCoffee.aspx");
            }
            else
            {
                Response.Redirect(@"~\View\HomePage.aspx");
            }
        }
    }
}