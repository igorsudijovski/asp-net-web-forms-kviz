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
        String username = (String)Session["username"];
        if (username == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        lblLogedUser.Text = username;
    }
    protected void promeni_click(object sender, EventArgs e)
    {
        String username = (String)Session["username"];
        error.Visible = false;
        SqlConnection connection = new SqlConnection();
        String connectionString = ConfigurationManager.ConnectionStrings["dataBaseConnection"].ConnectionString;
        connection.ConnectionString = connectionString;
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "SELECT username FROM users WHERE username=@username AND password=@password";
        command.Parameters.AddWithValue("@username", username);
        command.Parameters.AddWithValue("@username", txtOldPassword.Text);
        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                error.Text = "Веќе постои такво корисничко име";
                error.Visible = true;
                reader.Close();
            }
            else
            {
                reader.Close();
                command.Parameters.Clear();
                command.CommandText = "UPDATE users SET password=@password WHERE username=@username";
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password.Text);
                command.ExecuteNonQuery();
                Session.Remove("username");
                Session.Remove("username_role");
                HttpCookie keepMeLoginCookie = Request.Cookies["username"];
                if (keepMeLoginCookie != null)
                {
                    keepMeLoginCookie.Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies.Add(keepMeLoginCookie);
                }
                Response.Redirect("~/Login.aspx");
            }
        }
        catch (Exception ex)
        {
            error.Text = ex.Message;
            error.Visible = true;
        }
        finally
        {
            connection.Close();
        }
    }
    protected void logOut_click(object sender, EventArgs e)
    {
        Session.Remove("username");
        Session.Remove("username_role");
        HttpCookie keepMeLoginCookie = Request.Cookies["username"];
        if (keepMeLoginCookie != null)
        {
            keepMeLoginCookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(keepMeLoginCookie);
        }
        Response.Redirect("~/Login.aspx");
    }
}