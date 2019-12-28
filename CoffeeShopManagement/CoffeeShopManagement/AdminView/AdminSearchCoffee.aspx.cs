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
    public partial class AdminSearchCoffee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect(@"~\View\HomePage.aspx");
            } 
        }

        protected void btnAction_Click(object sender, EventArgs e)
        {
            if (Session["admin"] != null)
            {
                string search = txtSearch.Text;
                UpdateGridView(search);
            }
            else
            {
                Response.Redirect(@"~\View\HomePage.aspx");
            }            
        }

        private void UpdateGridView(string search)
        {
            CoffeeDAO dao = new CoffeeDAO();
            List<CoffeeDTO> result = dao.GetCoffeeByName(search);
            gvCoffee.DataSource = result;
            gvCoffee.DataBind();
        }

        protected void lbtDelete_Click(object sender, EventArgs e)
        {
            if (Session["admin"] != null)
            {             
                string id = ((LinkButton)sender).CommandArgument;
                string search = txtSearch.Text;
    
                CoffeeDAO dao = new CoffeeDAO();
                bool result = dao.DeleteCoffee(id);
                if (result)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Remove Coffee Success');", true);
                    UpdateGridView(search);
                }            
            }
            else
            {
                Response.Redirect(@"~\View\HomePage.aspx");
            }
        }       
    }
}