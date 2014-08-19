using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie keepMeLoginCookie = Request.Cookies["username"];
        if (keepMeLoginCookie != null)
        {
            String usernameFromCookie = (String)keepMeLoginCookie["username"];
            String passwordFromCookie = (String)keepMeLoginCookie["password"];
            loginToSite(usernameFromCookie, passwordFromCookie, true);
        }

    }
    protected void logInClick(object sender, EventArgs e)
    {
        error.Visible = false;
        loginToSite(username.Text, password.Text, keepMeLogin.Checked);
    }

    private void loginToSite(String usernameParam, String passwordParam, bool keepMeLoginParam)
    {
        SqlConnection connection = new SqlConnection();
        String connectionString = ConfigurationManager.ConnectionStrings["dataBaseConnection"].ConnectionString;
        connection.ConnectionString = connectionString;
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "SELECT * FROM users WHERE username=@username AND password=@password";
        command.Parameters.AddWithValue("@username", usernameParam);
        command.Parameters.AddWithValue("@password", passwordParam);
        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                String usernameFromDB = (String)reader["username"];
                int role = (int)reader["role"];
                Session["username"] = usernameFromDB;
                Session["username_role"] = role;
                if (keepMeLoginParam)
                {
                    HttpCookie keepLogin = new HttpCookie("username");
                    keepLogin["username"] = usernameFromDB;
                    keepLogin["password"] = (String)reader["password"];
                    keepLogin.Expires = DateTime.Now.AddDays(150);
                    Response.Cookies.Add(keepLogin);
                }
                if (role == 1)
                {
                    Response.Redirect("~/Admin_Users.aspx");
                }
                else
                {
                    Response.Redirect("~/test");
                }
            }
            else
            {
                error.Text = "Погрешно корисничко име или лозинка";
                error.Visible = true;
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            error.Text = ex.Message;
        }
        finally
        {
            connection.Close();
        }
    }
}