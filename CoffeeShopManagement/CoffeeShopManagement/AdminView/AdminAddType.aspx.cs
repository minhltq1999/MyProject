       using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
namespace CoffeeShopManagement.AdminView
{
    public partial class AdminAddType : System.Web.UI.Page
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
                CoffeeTypeDAO dao = new CoffeeTypeDAO();
                if (dao.CheckDupplicate(txtName.Text)) { 
                    lbNameError.Text = $"{txtName.Text} is already existed";
                    lbNameError.Visible = true;
                }
                else
                {
                    CoffeeTypeDTO dto = new CoffeeTypeDTO { typeName = txtName.Text };
                    bool result = dao.AddNewType(dto);
                    if (result)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Add Type Success');", true);
                        txtName.Text = "";
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