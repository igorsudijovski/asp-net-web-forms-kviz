using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            String username = (String)Session["username"];
            if (username == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            lblLogedUser.Text = username;
            SqlConnection connection = new SqlConnection();
            String connectionString = ConfigurationManager.ConnectionStrings["dataBaseConnection"].ConnectionString;
            connection.ConnectionString = connectionString;
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT TOP 10 username, points, time FROM quiz.dbo.users ORDER BY points DESC";
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet ds = new DataSet();     
            try
            {
                connection.Open();
                adapter.Fill(ds, "users");
                gridTop10Score.DataSource = ds;
                gridTop10Score.DataBind();
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
    protected void start_game(object sender, EventArgs e)
    {
        Session["points"] = 0;
        Session["start-time"] = DateTime.Now;
        Session["game-page"] = 1;
        Response.Redirect("~/Moj_Broj.aspx");
    }
}