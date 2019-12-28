using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CoffeeShopManagement.AdminView
{
    public partial class EditType : System.Web.UI.Page
    {
        CoffeeTypeDAO dao = new CoffeeTypeDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect(@"~\View\HomePage.aspx");
            }
            string typeID = Request.QueryString["typeID"];
            try
            {
                CoffeeTypeDTO type = dao.GetCofffeeTypeByID(int.Parse(typeID));
                if (type != null)
                {
                    if (!Page.IsPostBack)
                    {
                        txtID.Text = type.typeID.ToString();
                        txtName.Text = type.typeName;
                    }
                }
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        protected void btnAction_Click(object sender, EventArgs e)
        {
            try
            {
                if (dao.CheckDupplicateForUpdate(txtName.Text, int.Parse(txtID.Text)))
                {
                    lbNameError.Text = $"{txtName.Text} is already existed";
                    lbNameError.Visible = true;
                }
                else
                {
                    CoffeeTypeDTO type = new CoffeeTypeDTO { typeID = int.Parse(txtID.Text), typeName = txtName.Text };
                    bool result = dao.UpdateType(type);
                    if (result)
                    {
                        Response.Redirect(@"~\AdminView\AdminSearchCategory.aspx");
                    }
                }
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (Session["admin"] != null)
            {
                Response.Redirect(@"~\AdminView\AdminSearchCategory.aspx");
            }
            else
            {
                Response.Redirect(@"~\View\HomePage.aspx");
            }
        }
    }
}