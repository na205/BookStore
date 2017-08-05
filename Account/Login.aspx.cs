using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Web;
using System.Web.UI;
using BookStore;
using System.Data.SqlClient;
using System.Data;

public partial class Account_Login : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        RegisterHyperLink.NavigateUrl = "Register";
        OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
        var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        if (!String.IsNullOrEmpty(returnUrl))
        {
            RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
        }
    }

    protected void LogIn(object sender, EventArgs e)
    {
        if (IsValid)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C: \\Users\\Naveev\\Documents\\Visual Studio 2017\\WebSites\\BookStore\\App_Data\\Database.mdf\";Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from LoginInfo where Username=@username and Password=@password", con);
            cmd.Parameters.AddWithValue("@username", Username.Text);
            cmd.Parameters.AddWithValue("@password", Password.Text);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (dt.Rows.Count > 0)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                Username.Text = "Your username and password is incorrect";
                Username.ForeColor = System.Drawing.Color.Red;

            }
            // Validate the user password
            //var manager = new UserManager();
            //ApplicationUser user = manager.Find(Username.Text, Password.Text);
            //if (user != null)
            //{
            //    IdentityHelper.SignIn(manager, user, RememberMe.Checked);
            //    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            //}
            //else
            //{
            //    FailureText.Text = "Invalid username or password.";
            //    ErrorMessage.Visible = true;
            //}
        }
    }
}