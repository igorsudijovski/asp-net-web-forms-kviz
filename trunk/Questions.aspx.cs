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
            ViewState["question-number"] = 1;
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
            if (gameState != 3)
            {
                Response.Redirect("~/Pocetna.aspx");
            }
            points.Text = Session["points"].ToString();
            btnPotvrda.Enabled = false;
            setQuestion();
            lblOdgovor.Visible = false;
        }
    }
    protected void finish_game_click(object sender, EventArgs e)
    {
        Session.Remove("points");
        Session.Remove("start-time");
        Session.Remove("game-page");
        Session.Remove("igra-zapocnata");
        Response.Redirect("~/Pocetna.aspx");
    }
    private void setQuestion()
    {
        int questionNumber = (int)ViewState["question-number"];
        if (questionNumber < 11)
        {
            lblquestionNumber.Text = questionNumber.ToString();
            string[] answersPermutation = { "answer1", "answer2", "answer3", "answer4" };
            answersPermutation = Shuffle<string>(answersPermutation);
            SqlConnection connection = new SqlConnection();
            String connectionString = ConfigurationManager.ConnectionStrings["dataBaseConnection"].ConnectionString;
            connection.ConnectionString = connectionString;
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT TOP 1 * FROM questions ORDER BY NEWID()";
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                Question.Text = (String)reader["question"];
                answer1.Text = (String)reader[answersPermutation[0]];
                answer2.Text = (String)reader[answersPermutation[1]];
                answer3.Text = (String)reader[answersPermutation[2]];
                answer4.Text = (String)reader[answersPermutation[3]];
                ViewState["answer"] = (String)reader["realanswer"];
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
        else
        {
            Session["game-page"] = 4;
            Session.Remove("igra-zapocnata");
            Response.Redirect("~/Association.aspx");
        }
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
    protected void potvrdi_click(object sender, EventArgs e)
    {
        int pointsInt = (int)Session["points"];
        String answer = (String)ViewState["answer"];
        String odgovor = (String)ViewState["odgovor"];
        btnPotvrda.Enabled = false;
        if (answer.Equals(odgovor))
        {
            lblOdgovor.Text = "Точен одговор";
            lblOdgovor.Visible = true;
            pointsInt += 5;
            Session["points"] = pointsInt;
        }
        else
        {
            lblOdgovor.Text = "Неточен одговор";
            lblOdgovor.Visible = true;
            pointsInt -= 2;
            if (pointsInt < 0)
            {
                pointsInt = 0;
            }
            Session["points"] = pointsInt;
        }
        points.Text = pointsInt.ToString();
        
    }
    protected void change_radio_button(object sender, EventArgs e)
    {
        RadioButton btn = (RadioButton)sender;
        ViewState["odgovor"] = btn.Text;
        btnPotvrda.Enabled = true;
    }
    protected void sledno_click(object sender, EventArgs e)
    {
        answer1.Checked = false;
        answer2.Checked = false;
        answer3.Checked = false;
        answer4.Checked = false;
        btnPotvrda.Enabled = false;
        int questionNumber = (int)ViewState["question-number"];
        questionNumber++;
        ViewState["question-number"] = questionNumber;
        setQuestion();
        lblOdgovor.Visible = false;
    }
}