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
            loadAsociations();
        }
    }
    private void loadAsociations()
    {
        lstBoxAsociation.Items.Clear();
        SqlConnection connection = new SqlConnection();
        String connectionString = ConfigurationManager.ConnectionStrings["dataBaseConnection"].ConnectionString;
        connection.ConnectionString = connectionString;
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "SELECT name FROM asociation";
        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ListItem lstItem = new ListItem();
                lstItem.Text = (String)reader["name"];
                lstItem.Value = (String)reader["name"];
                lstBoxAsociation.Items.Add(lstItem);
            }
            reader.Close();
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
        command.CommandText = "DELETE FROM asociation WHERE name=@name";
        command.Parameters.AddWithValue("@name", txtAsocName.Text);
        try
        {
            connection.Open();
            command.ExecuteNonQuery();
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
        txtAsocName.Text = "";
        clearAllAsoc();
        txtAsocName.Enabled = true;
        lstBoxAsociation.SelectedIndex = -1;
        loadAsociations();
    }
    protected void cancelClick(object sender, EventArgs e)
    {
        btnAdd.Enabled = true;
        btnCancel.Enabled = false;
        btnDelete.Enabled = false;
        btnSave.Enabled = false;
        txtAsocName.Text = "";
        clearAllAsoc();
        txtAsocName.Enabled = true;
        lstBoxAsociation.SelectedIndex = -1;
    }
    protected void saveClick(object sender, EventArgs e)
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
        command.CommandText = "UPDATE asociation SET first=@first, second=@second, third=@third, fourth=@fourth, final=@final WHERE name=@name";
        command.Parameters.AddWithValue("@first", getAllA());
        command.Parameters.AddWithValue("@second", getAllB());
        command.Parameters.AddWithValue("@third", getAllC());
        command.Parameters.AddWithValue("@fourth", getAllD());
        command.Parameters.AddWithValue("@final", txtFinal.Text);
        command.Parameters.AddWithValue("@name", txtAsocName.Text);
        try
        {
            connection.Open();
            command.ExecuteNonQuery();
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
        txtAsocName.Text = "";
        clearAllAsoc();
        txtAsocName.Enabled = true;
        lstBoxAsociation.SelectedIndex = -1;
    }
    protected void addClick(object sender, EventArgs e)
    {
        error.Visible = false;
        SqlConnection connection = new SqlConnection();
        String connectionString = ConfigurationManager.ConnectionStrings["dataBaseConnection"].ConnectionString;
        connection.ConnectionString = connectionString;
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "SELECT name FROM asociation WHERE name=@name";
        command.Parameters.AddWithValue("@name", txtAsocName.Text);
        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                error.Text = "Веќе постои такво име на асоцијациа";
                error.Visible = true;
                reader.Close();
            }
            else
            {
                reader.Close();
                command.Parameters.Clear();
                command.CommandText = "INSERT INTO asociation(name, first, second, third, fourth, final) VALUES (@name, @first, @second, @third, @fourth, @final)";
                command.Parameters.AddWithValue("@name", txtAsocName.Text);
                command.Parameters.AddWithValue("@first", getAllA());
                command.Parameters.AddWithValue("@second", getAllB());
                command.Parameters.AddWithValue("@third", getAllC());
                command.Parameters.AddWithValue("@fourth", getAllD());
                command.Parameters.AddWithValue("@final", txtFinal.Text);
                command.ExecuteNonQuery();
                clearAllAsoc();
                txtAsocName.Text = "";
                txtAsocName.Enabled = true;
                loadAsociations();
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
    protected void selectAsocForEditing(object sender, EventArgs e)
    {
        String name = lstBoxAsociation.SelectedValue;
        btnAdd.Enabled = false;
        btnCancel.Enabled = true;
        btnDelete.Enabled = true;
        btnSave.Enabled = true;
        txtAsocName.Enabled = false;
        SqlConnection connection = new SqlConnection();
        String connectionString = ConfigurationManager.ConnectionStrings["dataBaseConnection"].ConnectionString;
        connection.ConnectionString = connectionString;
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "SELECT * FROM asociation WHERE name=@name";
        command.Parameters.AddWithValue("@name", name);
        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            txtAsocName.Text = (String)reader["name"];
            setAllA((String)reader["first"]);
            setAllB((String)reader["second"]);
            setAllC((String)reader["third"]);
            setAllD((String)reader["fourth"]);
            txtFinal.Text = (String)reader["final"];
            reader.Close();
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

    private String getAllA()
    {
        return txtA1.Text + ":??:" + txtA2.Text + ":??:" + txtA3.Text + ":??:" + txtA4.Text + ":??:" + txtA5.Text;
    }

    private String getAllB()
    {
        return txtB1.Text + ":??:" + txtB2.Text + ":??:" + txtB3.Text + ":??:" + txtB4.Text + ":??:" + txtB5.Text;
    }

    private String getAllC()
    {
        return txtC1.Text + ":??:" + txtC2.Text + ":??:" + txtC3.Text + ":??:" + txtC4.Text + ":??:" + txtC5.Text;
    }

    private String getAllD()
    {
        return txtD1.Text + ":??:" + txtD2.Text + ":??:" + txtD3.Text + ":??:" + txtD4.Text + ":??:" + txtD5.Text;
    }

    private void setAllA(String asocString)
    {
        string[] stringSeparators = new string[] {":??:"};
        String[] asoc = asocString.Split(stringSeparators, StringSplitOptions.None);
        txtA1.Text = asoc[0];
        txtA2.Text = asoc[1];
        txtA3.Text = asoc[2];
        txtA4.Text = asoc[3];
        txtA5.Text = asoc[4];
    }

    private void setAllB(String asocString)
    {
        string[] stringSeparators = new string[] { ":??:" };
        String[] asoc = asocString.Split(stringSeparators, StringSplitOptions.None);
        txtB1.Text = asoc[0];
        txtB2.Text = asoc[1];
        txtB3.Text = asoc[2];
        txtB4.Text = asoc[3];
        txtB5.Text = asoc[4];
    }

    private void setAllC(String asocString)
    {
        string[] stringSeparators = new string[] { ":??:" };
        String[] asoc = asocString.Split(stringSeparators, StringSplitOptions.None);
        txtC1.Text = asoc[0];
        txtC2.Text = asoc[1];
        txtC3.Text = asoc[2];
        txtC4.Text = asoc[3];
        txtC5.Text = asoc[4];
    }

    private void setAllD(String asocString)
    {
        string[] stringSeparators = new string[] { ":??:" };
        String[] asoc = asocString.Split(stringSeparators, StringSplitOptions.None);
        txtD1.Text = asoc[0];
        txtD2.Text = asoc[1];
        txtD3.Text = asoc[2];
        txtD4.Text = asoc[3];
        txtD5.Text = asoc[4];
    }

    private void clearAllAsoc()
    {
        txtA1.Text = "";
        txtA2.Text = "";
        txtA3.Text = "";
        txtA4.Text = "";
        txtA5.Text = "";
        txtB1.Text = "";
        txtB2.Text = "";
        txtB3.Text = "";
        txtB4.Text = "";
        txtB5.Text = "";
        txtC1.Text = "";
        txtC2.Text = "";
        txtC3.Text = "";
        txtC4.Text = "";
        txtC5.Text = "";
        txtD1.Text = "";
        txtD2.Text = "";
        txtD3.Text = "";
        txtD4.Text = "";
        txtD5.Text = "";
        txtFinal.Text = "";
    }
}