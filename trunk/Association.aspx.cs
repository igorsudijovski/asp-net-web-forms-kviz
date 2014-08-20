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
            ViewState["game-time"] = DateTime.Now;
            string[] answersPermutation = { "first", "second", "third", "fourth" };
            string[] asocPolinja = { "A", "B", "C", "D" };
            lblObidi.Text = 10.ToString(); ;
            answersPermutation = Shuffle<string>(answersPermutation);
            SqlConnection connection = new SqlConnection();
            String connectionString = ConfigurationManager.ConnectionStrings["dataBaseConnection"].ConnectionString;
            connection.ConnectionString = connectionString;
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT TOP 1 * FROM asociation ORDER BY NEWID()";
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                ViewState["final"] = (String)reader["final"];
                ViewState["finalPoints"] = 50;
                ViewState["broj-obidi"] = 10;
                for (int i = 0; i < 4; i++)
                {
                    string asocString = (string)reader[answersPermutation[i]];
                    string[] stringSeparators = new string[] { ":??:" };
                    String[] asoc = asocString.Split(stringSeparators, StringSplitOptions.None);
                    string[] helpAsoc = new string[4];
                    for (int j = 0; j < 4; j++)
                    {
                        helpAsoc[j] = asoc[j];
                    }
                    helpAsoc = Shuffle<string>(helpAsoc);
                    ViewState[asocPolinja[i]] = helpAsoc;
                    ViewState[asocPolinja[i] + "answer"] = asoc[4];
                    ViewState[asocPolinja[i] + "points"] = 13;
                    
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
        DateTime date = (DateTime)ViewState["game-time"];
        DateTime now = DateTime.Now;
        TimeSpan pominatoVreme = now - date;
        int vreme = 450 - (int)pominatoVreme.TotalSeconds;
        if (vreme < 0)
        {
            vreme = 0;
        }
        lblExpiredTime.Text = vreme.ToString();
    }
    private T[] Shuffle<T>(T[] array)
    {
        TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
        int secondsSinceEpoch = (int)t.TotalSeconds;
        Random randomGenerator = new Random(secondsSinceEpoch);
        for (int i = array.Length; i > 1; i--)
        {
            // Pick random element to swap.
            int j = randomGenerator.Next(i); // 0 <= j <= i-1
            // Swap.
            T tmp = array[j];
            array[j] = array[i - 1];
            array[i - 1] = tmp;
        }
        return array;
    }
    protected void Otvori_pole_click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        btn.Enabled = false;
        string[] btnText = btn.Text.Split(' ');
        string[] helpAsoc = (string[])ViewState[btnText[0]];
        int currentPoints = (int)ViewState[btnText[0] + "points"];
        currentPoints -= 2;
        ViewState[btnText[0] + "points"] = currentPoints;
        int number = Convert.ToInt32(btnText[1], 10);
        btn.Text = helpAsoc[number - 1];
    }
    protected void Odgovor_pole_click(object sender, EventArgs e)
    {
        int fintalPoints = (int)Session["points"];
        Button btn = (Button)sender;
        string[] btnText = btn.Text.Split(' ');
        string answer = (string)ViewState[btnText[0] + "answer"];
        int currentPoints = (int)ViewState[btnText[0] + "points"];
        int currentFinalPoints = (int)ViewState["finalPoints"];
        currentFinalPoints -= 10;
        ViewState["finalPoints"] = currentFinalPoints;
        if (answer == txtOdgovor.Text)
        {
            btn.Text = answer;
            btn.Enabled = false;
            fintalPoints += currentPoints;
            Session["points"] = fintalPoints;
        }
        txtOdgovor.Text = "";
    }
    protected void Odgovor_pole_konecno_click(object sender, EventArgs e)
    {
        int obidi = (int)ViewState["broj-obidi"];
        if (obidi == 1)
        {
            Session["game-page"] = 5;
            Response.Redirect("~/Kraj.aspx");
        }
        int fintalPoints = (int)Session["points"];
        string answer = (string)ViewState["final"];
        int currentFinalPoints = (int)ViewState["finalPoints"];
        if (answer == txtOdgovor.Text)
        {
            btnOdgovorKonecen.Text = answer;
            btnOdgovorKonecen.Enabled = false;
            fintalPoints += currentFinalPoints;
            Session["points"] = fintalPoints;
        }
        txtOdgovor.Text = "";
        obidi--;
        lblObidi.Text = obidi.ToString();
        ViewState["broj-obidi"] = obidi;
    }
    protected void finish_game_click(object sender, EventArgs e)
    {
        Session.Remove("points");
        Session.Remove("start-time");
        Session.Remove("game-page");
        Response.Redirect("~/Pocetna.aspx");
    }
}