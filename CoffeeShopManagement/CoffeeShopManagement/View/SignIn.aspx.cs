using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CoffeeShopManagement
{
    public partial class SignIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAction_Click(object sender, EventArgs e)
        {
            try
            {
                UserDetailDAO dao = new UserDetailDAO();
                if (dao.CheckDuplicate(txtUserName.Text))
                {
                    //usernameError.Text = txtUserName.Text + " is already existed";
                    //usernameError.Visible = true;
                }
                else { 
                UserDetailDTO user = new UserDetailDTO { username = txtUserName.Text,
                                                            password=txtPassword.Text,
                                                            fullName=txtName.Text,
                                                            address=txtAddress.Text,
                                                            email=txtEmail.Text,
                                                            phone=txtPhone.Text};
                bool result = dao.AddNewUser(user);
                if (result)
                {
                    Response.Redirect(@"~\View\HomePage.aspx");
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
            Response.Redirect(@"~\View\HomePage.aspx");
        }
    }
}