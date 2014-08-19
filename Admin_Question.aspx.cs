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
            loadQuestions();
        }
    }
    protected void selectQuestionForEditing(object sender, EventArgs e)
    {
        String name = lstBoxQuestions.SelectedValue;
        btnAdd.Enabled = false;
        btnCancel.Enabled = true;
        btnDelete.Enabled = true;
        btnSave.Enabled = true;
        txtOpis.Enabled = false;
        SqlConnection connection = new SqlConnection();
        String connectionString = ConfigurationManager.ConnectionStrings["dataBaseConnection"].ConnectionString;
        connection.ConnectionString = connectionString;
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "SELECT * FROM questions WHERE name=@name";
        command.Parameters.AddWithValue("@name", name);
        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            txtOpis.Text = (String)reader["name"];
            txtQuestion.Text = (String)reader["question"];
            txtAnswer1.Text = (String)reader["answer1"];
            txtAnswer2.Text = (String)reader["answer2"];
            txtAnswer3.Text = (String)reader["answer3"];
            txtAnswer4.Text = (String)reader["answer4"];
            selectRadioButton((String)reader["realanswer"]);
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
    protected void addQuestionClick(object sender, EventArgs e)
    {
        error.Visible = false;
        SqlConnection connection = new SqlConnection();
        String connectionString = ConfigurationManager.ConnectionStrings["dataBaseConnection"].ConnectionString;
        connection.ConnectionString = connectionString;
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "SELECT name FROM questions WHERE name=@name";
        command.Parameters.AddWithValue("@name", txtOpis.Text);
        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                error.Text = "Веќе постои таков опис на прашање";
                error.Visible = true;
                reader.Close();
            }
            else
            {
                reader.Close();
                command.Parameters.Clear();
                command.CommandText = "INSERT INTO questions(name, question, answer1, answer2, answer3, answer4, realanswer) VALUES (@name, @question, @answer1, @answer2, @answer3, @answer4, @realanswer)";
                command.Parameters.AddWithValue("@name", txtOpis.Text);
                command.Parameters.AddWithValue("@question", txtQuestion.Text);
                command.Parameters.AddWithValue("@answer1", txtAnswer1.Text);
                command.Parameters.AddWithValue("@answer2", txtAnswer2.Text);
                command.Parameters.AddWithValue("@answer3", txtAnswer3.Text);
                command.Parameters.AddWithValue("@answer4", txtAnswer4.Text);
                command.Parameters.AddWithValue("@realanswer", getRealAnswer());
                command.ExecuteNonQuery();
                initAllRadioButtons();
                txtOpis.Text = "";
                txtQuestion.Text = "";
                txtAnswer1.Text = "";
                txtAnswer2.Text = "";
                txtAnswer3.Text = "";
                txtAnswer4.Text = "";
                txtOpis.Enabled = true;
                lstBoxQuestions.SelectedIndex = -1;
                loadQuestions();
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
    protected void saveQuestionClick(object sender, EventArgs e)
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
        command.CommandText = "UPDATE questions SET question=@question, answer1=@answer1, answer2=@answer2, answer3=@answer3, answer4=@answer4, realanswer=@realanswer WHERE name=@name";
        command.Parameters.AddWithValue("@name", txtOpis.Text);
        command.Parameters.AddWithValue("@question", txtQuestion.Text);
        command.Parameters.AddWithValue("@answer1", txtAnswer1.Text);
        command.Parameters.AddWithValue("@answer2", txtAnswer2.Text);
        command.Parameters.AddWithValue("@answer3", txtAnswer3.Text);
        command.Parameters.AddWithValue("@answer4", txtAnswer4.Text);
        command.Parameters.AddWithValue("@realanswer", getRealAnswer());
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
        initAllRadioButtons();
        txtOpis.Text = "";
        txtQuestion.Text = "";
        txtAnswer1.Text = "";
        txtAnswer2.Text = "";
        txtAnswer3.Text = "";
        txtAnswer4.Text = "";
        txtOpis.Enabled = true;
        lstBoxQuestions.SelectedIndex = -1;
    }
    protected void cancelClick(object sender, EventArgs e)
    {
        btnAdd.Enabled = true;
        btnCancel.Enabled = false;
        btnDelete.Enabled = false;
        btnSave.Enabled = false;
        initAllRadioButtons();
        txtOpis.Text = "";
        txtQuestion.Text = "";
        txtAnswer1.Text = "";
        txtAnswer2.Text = "";
        txtAnswer3.Text = "";
        txtAnswer4.Text = "";
        txtOpis.Enabled = true;
        lstBoxQuestions.SelectedIndex = -1;
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
        command.CommandText = "DELETE FROM questions WHERE name=@name";
        command.Parameters.AddWithValue("@name", txtOpis.Text);
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
        initAllRadioButtons();
        txtOpis.Text = "";
        txtQuestion.Text = "";
        txtAnswer1.Text = "";
        txtAnswer2.Text = "";
        txtAnswer3.Text = "";
        txtAnswer4.Text = "";
        txtOpis.Enabled = true;
        lstBoxQuestions.SelectedIndex = -1;
        loadQuestions();
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

    private void loadQuestions()
    {
        lstBoxQuestions.Items.Clear();
        SqlConnection connection = new SqlConnection();
        String connectionString = ConfigurationManager.ConnectionStrings["dataBaseConnection"].ConnectionString;
        connection.ConnectionString = connectionString;
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "SELECT name FROM questions";
        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ListItem lstItem = new ListItem();
                lstItem.Text = (String)reader["name"];
                lstItem.Value = (String)reader["name"];
                lstBoxQuestions.Items.Add(lstItem);
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

    private void selectRadioButton(String answer)
    {
        resetAllRadioButtons();
        if (answer == txtAnswer1.Text)
        {
            RadioButtonAnswer1.Checked = true;
        }
        if (answer == txtAnswer2.Text)
        {
            RadioButtonAnswer2.Checked = true;
        }
        if (answer == txtAnswer3.Text)
        {
            RadioButtonAnswer3.Checked = true;
        }
        if (answer == txtAnswer4.Text)
        {
            RadioButtonAnswer4.Checked = true;
        }
    }

    private String getRealAnswer()
    {
        if (RadioButtonAnswer1.Checked)
        {
            return txtAnswer1.Text;
        }
        if (RadioButtonAnswer2.Checked)
        {
            return txtAnswer2.Text;
        }
        if (RadioButtonAnswer3.Checked)
        {
            return txtAnswer3.Text;
        }
        return txtAnswer4.Text;
    }

    private void resetAllRadioButtons()
    {
        RadioButtonAnswer1.Checked = false;
        RadioButtonAnswer2.Checked = false;
        RadioButtonAnswer3.Checked = false;
        RadioButtonAnswer4.Checked = false;
    }

    private void initAllRadioButtons()
    {
        RadioButtonAnswer1.Checked = true;
        RadioButtonAnswer2.Checked = false;
        RadioButtonAnswer3.Checked = false;
        RadioButtonAnswer4.Checked = false;
    }
}