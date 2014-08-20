using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
                Session.Remove("igra-zapocnata");
                Response.Redirect("~/Pocetna.aspx");
            }
            int gameState = (int)Session["game-page"];
            if (gameState != 1)
            {
                Session.Remove("igra-zapocnata");
                Response.Redirect("~/Pocetna.aspx");
            }
            points.Text = Session["points"].ToString();
            ViewState["game-time"] = DateTime.Now;
            ViewState["previousIsNumber"] = false;
            TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
            int secondsSinceEpoch = (int)t.TotalSeconds;
            Random randomGenerator = new Random(secondsSinceEpoch);
            number1.Text = randomGenerator.Next(1, 10).ToString();
            number2.Text = randomGenerator.Next(1, 10).ToString();
            number3.Text = randomGenerator.Next(1, 10).ToString();
            number4.Text = randomGenerator.Next(1, 10).ToString();
            middleNumber.Text = (randomGenerator.Next(2, 6) * 5).ToString();
            bigNumber.Text = (randomGenerator.Next(2, 5) * 25).ToString();
            txtFinal.Text = randomGenerator.Next(100, 1000).ToString();
        }
        DateTime date = (DateTime)ViewState["game-time"];
        DateTime now = DateTime.Now;
        TimeSpan pominatoVreme = now - date;
        int vreme = 180 - (int)pominatoVreme.TotalSeconds;
        if (vreme < 0)
        {
            vreme = 0;
        }
        lblExpiredTime.Text = vreme.ToString();
    }
    protected void finish_game_click(object sender, EventArgs e)
    {
        Session.Remove("points");
        Session.Remove("start-time");
        Session.Remove("game-page");
        Session.Remove("igra-zapocnata");
        Response.Redirect("~/Pocetna.aspx");
    }

    protected void button_click(object sender, EventArgs e)
    {
        int number;
        Button btn = (Button)sender;
        bool previousIsNumber = (bool)ViewState["previousIsNumber"];
        if (txtExpression.Text == "")
        {
            txtExpression.Text += ((Button)sender).Text;
            previousIsNumber = int.TryParse(btn.Text, out number);
            if (previousIsNumber)
            {
                btn.Enabled = false;
            }
        }
        else
        {
            bool isNumber = int.TryParse(btn.Text, out number);
            if (!(isNumber && previousIsNumber))
            {
                txtExpression.Text += ((Button)sender).Text;
                previousIsNumber = isNumber;
                if (isNumber)
                {
                    btn.Enabled = false;
                }
            }
        }
        ViewState["previousIsNumber"] = previousIsNumber;
    }
    protected void calculate_click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        var v = dt.Compute(txtExpression.Text, "");
        txtCalculated.Text = v.ToString(); ;
    }
    protected void erase_Click(object sender, EventArgs e)
    {
        txtCalculated.Text = "";
        txtExpression.Text = "";
        number1.Enabled = true;
        number2.Enabled = true;
        number3.Enabled = true;
        number4.Enabled = true;
        middleNumber.Enabled = true;
        bigNumber.Enabled = true;
    }
    protected void potvrdi_click(object sender, EventArgs e)
    {
        Session["game-page"] = 2;
        if (txtCalculated.Text == "")
        {
            Session.Remove("igra-zapocnata");
            Response.Redirect("~/Kombinacii.aspx");
        }
        DateTime date = (DateTime)ViewState["game-time"];
        DateTime now = DateTime.Now;
        TimeSpan pominatoVreme = now - date;
        int vreme = 180 - (int)pominatoVreme.TotalSeconds;
        if (vreme < 0)
        {
            vreme = 0;
        }
        if (vreme == 0)
        {
            Session.Remove("igra-zapocnata");
            Response.Redirect("~/Kombinacii.aspx");
        }
        else
        {
            int totalPoints = 20;
            if (vreme < 90)
            {
                totalPoints = 10;
            }
            int points = (int)Session["points"];
            int final = Convert.ToInt32(txtFinal.Text, 10);
            int calculated = Convert.ToInt32(txtCalculated.Text, 10);
            int delta = Math.Abs(final - calculated);
            delta = delta / 2;
            if (delta < 10)
            {
                int factor = 10 - delta;
                points += (totalPoints * factor) / 10;
                Session["points"] = points;
            }
            Session.Remove("igra-zapocnata");
            Response.Redirect("~/Kombinacii.aspx");
        }
        
    }
}