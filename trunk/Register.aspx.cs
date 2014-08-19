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

    }
    protected void registerClick(object sender, EventArgs e)
    {
        error.Visible = false;
        SqlConnection connection = new SqlConnection();
        String connectionString = ConfigurationManager.ConnectionStrings["dataBaseConnection"].ConnectionString;
        connection.ConnectionString = connectionString;
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "SELECT * FROM users WHERE username=@username";
        command.Parameters.AddWithValue("@username", username.Text);
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
                command.CommandText = "INSERT INTO users(username, password, role, points, time) VALUES (@username, @password, @role, @points, @time)";
                command.Parameters.AddWithValue("@username", username.Text);
                command.Parameters.AddWithValue("@password", password.Text);
                command.Parameters.AddWithValue("@role", 0);
                command.Parameters.AddWithValue("@points", 0);
                command.Parameters.AddWithValue("@time", 100.0);
                command.ExecuteNonQuery();
            }
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