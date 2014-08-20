using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            if (gameState != 2)
            {
                Session.Remove("igra-zapocnata");
                Response.Redirect("~/Pocetna.aspx");
            }
            points.Text = Session["points"].ToString();
            ViewState["game-time"] = DateTime.Now;
            string[] images = {imageAnwer1.ImageUrl,
                              imageAnwer2.ImageUrl,
                              imageAnwer3.ImageUrl,
                              imageAnwer4.ImageUrl,
                              imageAnwer5.ImageUrl,
                              imageAnwer6.ImageUrl};
            TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
            int secondsSinceEpoch = (int)t.TotalSeconds;
            Random randomGenerator = new Random(secondsSinceEpoch);
            string[] theAnswer = new string[4];
            for (int i = 0; i < 4; i++)
            {
                theAnswer[i] = images[randomGenerator.Next(0, 6)];
            }
            ViewState["answer"] = theAnswer;
            ViewState["rowNumber"] = 0;
            ViewState["columnNumber"] = 0;
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
    protected void item_click(object sender, ImageClickEventArgs e)
    {
        int row = (int)ViewState["rowNumber"];
        int column = (int)ViewState["columnNumber"];
        if (column < 4)
        {
            Image[,] images = putInMatrix();
            ImageButton btn = (ImageButton)sender;
            images[row, column].ImageUrl = btn.ImageUrl;
            column++;
            ViewState["columnNumber"] = column;
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
    protected void potvrdi_red(object sender, EventArgs e)
    {
        int rowNumber = (int)ViewState["rowNumber"];
        if (rowNumber == 6)
        {
            Image[,] images = putInMatrix();
            string[] originalAnswer = (string[])ViewState["answer"];
            for (int i = 0; i < 4; i++)
            {
                images[rowNumber + 1, i].ImageUrl = originalAnswer[i];
            }
            imageAnwer1.Enabled = false;
            imageAnwer2.Enabled = false;
            imageAnwer3.Enabled = false;
            imageAnwer4.Enabled = false;
            imageAnwer5.Enabled = false;
            imageAnwer6.Enabled = false;
            btnIzbrisi.Enabled = false;
            btnPotvrdi.Enabled = false;
            btnSledno.Enabled = true;
        }
        else
        {
                string[] originalAnswer = (string[])ViewState["answer"];
            string[] theAnswer = new string[4];
            for (int i = 0; i < 4; i++)
            {
                theAnswer[i] = originalAnswer[i];
            }
            Image[,] images = putInMatrix();
            int row = (int)ViewState["rowNumber"];
            string[] answered = new string[4];
            for (int i = 0; i < 4; i++)
            {
                answered[i] = images[row, i].ImageUrl;
            }
            bool tocenOdgovor = true;
            for (int i = 0; i < 4; i++)
            {
                if (answered[i] != theAnswer[i])
                {
                    tocenOdgovor = false;
                    break;
                }
            };
            if (tocenOdgovor)
            {
                int points = (int)Session["points"];
                imageAnwer1.Enabled = false;
                imageAnwer2.Enabled = false;
                imageAnwer3.Enabled = false;
                imageAnwer4.Enabled = false;
                imageAnwer5.Enabled = false;
                imageAnwer6.Enabled = false;
                btnIzbrisi.Enabled = false;
                btnPotvrdi.Enabled = false;
                btnSledno.Enabled = true;
                for (int i = 4; i < 8; i++)
                {
                    images[row, i].Visible = true;
                    images[row, i].ImageUrl = "~/img/tacno.png";
                }
                DateTime date = (DateTime)ViewState["game-time"];
                DateTime now = DateTime.Now;
                TimeSpan pominatoVreme = now - date;
                int vreme = 180 - (int)pominatoVreme.TotalSeconds;
                if (vreme < 0)
                {
                    vreme = 0;
                }
                if (vreme > 90)
                {
                    points += 20;
                }
                else if (vreme > 0)
                {
                    points += 10;
                }
                Session["points"] = points;
            }
            else
            {
                int k = 4;
                for (int i = 0; i < 4; i++)
                {
                    if (answered[i] == theAnswer[i])
                    {
                        images[row, k].Visible = true;
                        images[row, k].ImageUrl = "~/img/tacno.png";
                        theAnswer[i] = "";
                        answered[i] = " ";
                        k++;
                    }
                };
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (i != j)
                        {
                            if (answered[i] == theAnswer[j])
                            {
                                images[row, k].Visible = true;
                                images[row, k].ImageUrl = "~/img/netacno.png";
                                theAnswer[j] = "";
                                k++;
                                break;
                            }
                        }
                    }
                }
                row++;
                ViewState["rowNumber"] = row;
                ViewState["columnNumber"] = 0;
            }
        }
        
    }

    private Image[,] putInMatrix()
    {
        Image[,] matrix = new Image[8, 8];
        matrix[0, 0] = Image1;
        matrix[0, 1] = Image2;
        matrix[0, 2] = Image3;
        matrix[0, 3] = Image4;
        matrix[0, 4] = Image5;
        matrix[0, 5] = Image6;
        matrix[0, 6] = Image7;
        matrix[0, 7] = Image8;
        matrix[1, 0] = Image9;
        matrix[1, 1] = Image10;
        matrix[1, 2] = Image11;
        matrix[1, 3] = Image12;
        matrix[1, 4] = Image13;
        matrix[1, 5] = Image14;
        matrix[1, 6] = Image15;
        matrix[1, 7] = Image16;
        matrix[2, 0] = Image17;
        matrix[2, 1] = Image18;
        matrix[2, 2] = Image19;
        matrix[2, 3] = Image20;
        matrix[2, 4] = Image21;
        matrix[2, 5] = Image22;
        matrix[2, 6] = Image23;
        matrix[2, 7] = Image24;
        matrix[3, 0] = Image25;
        matrix[3, 1] = Image26;
        matrix[3, 2] = Image27;
        matrix[3, 3] = Image28;
        matrix[3, 4] = Image29;
        matrix[3, 5] = Image30;
        matrix[3, 6] = Image31;
        matrix[3, 7] = Image32;
        matrix[4, 0] = Image33;
        matrix[4, 1] = Image34;
        matrix[4, 2] = Image35;
        matrix[4, 3] = Image36;
        matrix[4, 4] = Image37;
        matrix[4, 5] = Image38;
        matrix[4, 6] = Image39;
        matrix[4, 7] = Image40;
        matrix[5, 0] = Image41;
        matrix[5, 1] = Image42;
        matrix[5, 2] = Image43;
        matrix[5, 3] = Image44;
        matrix[5, 4] = Image45;
        matrix[5, 5] = Image46;
        matrix[5, 6] = Image47;
        matrix[5, 7] = Image48;
        matrix[6, 0] = Image49;
        matrix[6, 1] = Image50;
        matrix[6, 2] = Image51;
        matrix[6, 3] = Image52;
        matrix[6, 4] = Image53;
        matrix[6, 5] = Image54;
        matrix[6, 6] = Image55;
        matrix[6, 7] = Image56;
        matrix[7, 0] = Image57;
        matrix[7, 1] = Image58;
        matrix[7, 2] = Image59;
        matrix[7, 3] = Image60;
        matrix[7, 4] = Image61;
        matrix[7, 5] = Image62;
        matrix[7, 6] = Image63;
        matrix[7, 7] = Image64;
        return matrix;
    }
    protected void izbrisi_click(object sender, EventArgs e)
    {
        Image[,] images = putInMatrix();
        int row = (int)ViewState["rowNumber"];
        for (int i = 0; i < 4; i++)
        {
            images[row, i].ImageUrl = "~/img/pitanje.png";
        }
        ViewState["columnNumber"] = 0;
    }
    protected void sledno_click(object sender, EventArgs e)
    {
        Session["game-page"] = 3;
        Session.Remove("igra-zapocnata");
        Response.Redirect("~/Questions.aspx");
    }
}