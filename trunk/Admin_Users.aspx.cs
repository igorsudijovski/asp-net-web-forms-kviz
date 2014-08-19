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
        error.Visible = false;
        if (!this.IsPostBack)
        {
            String username = (String)Session["username"];
            if (username == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            int role = (int)Session["username_role"];
            if (role != 1) 
            {
                Response.Redirect("~/Login.aspx");
            }
            lblLogedUser.Text = username;
            loadUsers();
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
    protected void selectUserForEditing(object sender, EventArgs e)
    {
        String username = lstBoxUsers.SelectedValue;
        btnAdd.Enabled = false;
        btnCancel.Enabled = true;
        if (username != "admin")
        {
            btnDelete.Enabled = true;
        }
        btnSave.Enabled = true;
        SqlConnection connection = new SqlConnection();
        String connectionString = ConfigurationManager.ConnectionStrings["dataBaseConnection"].ConnectionString;
        connection.ConnectionString = connectionString;
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "SELECT * FROM users WHERE username=@username";
        command.Parameters.AddWithValue("@username", username);
        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            txtUsername.Text = (String)reader["username"];
            txtUsername.Enabled = false;
            int role = (int)reader["role"];
            chkAdmin.Checked = false;
            if (role == 1)
            {
                chkAdmin.Checked = true;
            }
            password.Text = (String)reader["password"];
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
    protected void addUserClick(object sender, EventArgs e)
    {
        error.Visible = false;
        SqlConnection connection = new SqlConnection();
        String connectionString = ConfigurationManager.ConnectionStrings["dataBaseConnection"].ConnectionString;
        connection.ConnectionString = connectionString;
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "SELECT * FROM users WHERE username=@username";
        command.Parameters.AddWithValue("@username", txtUsername.Text);
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
                command.Parameters.AddWithValue("@username", txtUsername.Text);
                command.Parameters.AddWithValue("@password", password.Text);
                int role = 0;
                if (chkAdmin.Checked)
                {
                    role = 1;
                }
                command.Parameters.AddWithValue("@role", role);
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
        txtUsername.Text = "";
        chkAdmin.Checked = false;
        password.Text = "";
        loadUsers();
    }

    protected void saveUserClick(object sender, EventArgs e)
    {
        btnAdd.Enabled = true;
        btnCancel.Enabled = false;
        btnDelete.Enabled = false;
        btnSave.Enabled = false;
        int role = 0;
        if (chkAdmin.Checked)
        {
            role = 1;
        }
        SqlConnection connection = new SqlConnection();
        String connectionString = ConfigurationManager.ConnectionStrings["dataBaseConnection"].ConnectionString;
        connection.ConnectionString = connectionString;
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "UPDATE users SET password=@password, role=@role WHERE username=@username";
        command.Parameters.AddWithValue("@username", txtUsername.Text);
        command.Parameters.AddWithValue("@password", password.Text);
        command.Parameters.AddWithValue("@role", role);
        try
        {
            connection.Open();
            command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            error.Text = ex.Message;
        }
        finally
        {
            connection.Close();
        }
        txtUsername.Text = "";
        chkAdmin.Checked = false;
        password.Text = "";
        txtUsername.Enabled = true;
        lstBoxUsers.SelectedIndex = -1;
    }
    protected void cancelClick(object sender, EventArgs e)
    {
        btnAdd.Enabled = true;
        btnCancel.Enabled = false;
        btnDelete.Enabled = false;
        btnSave.Enabled = false;
        txtUsername.Text = "";
        chkAdmin.Checked = false;
        password.Text = "";
        txtUsername.Enabled = true;
        lstBoxUsers.SelectedIndex = -1;
    }

    private void loadUsers()
    {
        lstBoxUsers.Items.Clear();
        SqlConnection connection = new SqlConnection();
        String connectionString = ConfigurationManager.ConnectionStrings["dataBaseConnection"].ConnectionString;
        connection.ConnectionString = connectionString;
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "SELECT username FROM users";
        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ListItem lstItem = new ListItem();
                lstItem.Text = (String)reader["username"];
                lstItem.Value = (String)reader["username"];
                lstBoxUsers.Items.Add(lstItem);
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
    protected void deleteClick(object sender, EventArgs e)
    {
        btnAdd.Enabled = true;
        btnCancel.Enabled = false;
        btnDelete.Enabled = false;
        btnSave.Enabled = false;
        SqlConnection connection = new SqlConnection();
        String connectionString = ConfigurationManager.ConnectionStrings["dataBaseConnection"].ConnectionString;
        connection.ConnectionString = connectionString;
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "DELETE FROM users WHERE username=@username";
        command.Parameters.AddWithValue("@username", txtUsername.Text);
        try
        {
            connection.Open();
            command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            error.Text = ex.Message;
        }
        finally
        {
            connection.Close();
        }
        txtUsername.Text = "";
        chkAdmin.Checked = false;
        password.Text = "";
        txtUsername.Enabled = true;
        lstBoxUsers.SelectedIndex = -1;
    }
}