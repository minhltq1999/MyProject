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
    public partial class AdminSearchCategory : System.Web.UI.Page
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
            CoffeeTypeDAO dao = new CoffeeTypeDAO();
            DataTable data = dao.GetCoffeeTypeByName(search);
            gvType.DataSource = data;            
            gvType.DataBind();
        }

        protected void lbtDelete_Click(object sender, EventArgs e)
        {
            if (Session["admin"] != null)
            {            
                int id = Convert.ToInt16(((LinkButton)sender).CommandArgument);
                string search = txtSearch.Text;
                
                CoffeeTypeDAO dao = new CoffeeTypeDAO();
                bool result = dao.DeleteType(id);
                if (result)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Remove Coffee type Success');", true);
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