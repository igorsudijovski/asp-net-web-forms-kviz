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
        if (!this.IsPostBack)
        {
            String username = (String)Session["username"];
            if (username == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            lblLogedUser.Text = username;
            if (Session["igra-zapocnata"] == null)
            {
                Session["igra-zapocnata"] = true;
            }
            else
            {
                Session.Remove("points");
                Session.Remove("start-time");
                Session.Remove("game-page");
                Session.Remove("igra-zapocnata");
                Response.Redirect("~/Pocetna.aspx");
            }
            if (Session["game-page"] == null)
            {
                Response.Redirect("~/Pocetna.aspx");
            }
            int gameState = (int)Session["game-page"];
            if (gameState != 4)
            {
                Response.Redirect("~/Pocetna.aspx");
            }
            SqlConnection connection = new SqlConnection();
            String connectionString = ConfigurationManager.ConnectionStrings["dataBaseConnection"].ConnectionString;
            connection.ConnectionString = connectionString;
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            int points = (int)Session["points"];
            DateTime pocetok = (DateTime)Session["start-time"];
            DateTime now = DateTime.Now;
            TimeSpan timeInseconds = now - pocetok;
            double seconds = timeInseconds.TotalSeconds;
            lblPoints.Text = points.ToString();
            lblTime.Text = seconds.ToString();
            command.CommandText = "UPDATE users SET points=@points, time=@time WHERE username=@username";
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@points", points);
            command.Parameters.AddWithValue("@time", seconds);
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
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Session.Remove("points");
        Session.Remove("start-time");
        Session.Remove("game-page");
        Session.Remove("igra-zapocnata");
        Response.Redirect("~/Pocetna.aspx");
    }
}