<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Kombinacii.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="navigationBar" ContentPlaceHolderID="mainLinks" Runat="Server">
    
                        <div class="logedUser"> Ваши поени <asp:Label ID="points" 
                runat="server" Text="Label" Font-Bold="True"></asp:Label>. Време: 
                <asp:Label ID="lblExpiredTime" 
                runat="server" Text="Label" Font-Bold="True"></asp:Label></div>
        <div class="logedUser"> Вие сте најавен како <asp:Label ID="lblLogedUser" 
                runat="server" Text="Label" Font-Bold="True"></asp:Label></div>
    <asp:LinkButton ID="logOutButton" runat="server" 
        CssClass="main-links log-out-button" onclick="finish_game_click">Прекини игра</asp:LinkButton>
        
</asp:Content>
<asp:Content ID="mainContent" ContentPlaceHolderID="mainContent" Runat="Server">
    <div class="main-content">
    <div style="margin-bottom: 2px">
        <asp:ImageButton ID="imageAnwer1" runat="server" CssClass="margin-right" 
            ImageUrl="~/img/herc.png" onclick="item_click" />
        <asp:ImageButton ID="imageAnwer2" runat="server" CssClass="margin-right" 
            ImageUrl="~/img/karo.png" onclick="item_click" />
        <asp:ImageButton ID="imageAnwer3" runat="server" CssClass="margin-right" 
            ImageUrl="~/img/pik.png" onclick="item_click" />
        <asp:ImageButton ID="imageAnwer4" runat="server" CssClass="margin-right" 
            ImageUrl="~/img/tref.png" onclick="item_click" />
        <asp:ImageButton ID="imageAnwer5" runat="server" CssClass="margin-right" 
            ImageUrl="~/img/cd.png" onclick="item_click" />
        <asp:ImageButton ID="imageAnwer6" runat="server" CssClass="margin-right" 
            ImageUrl="~/img/zvezda.png" onclick="item_click" />
        <asp:Button ID="btnPotvrdi" runat="server" CssClass="margin-right" 
            Text="Потврди" onclick="potvrdi_red" />
        <asp:Button ID="btnIzbrisi" runat="server" Text="Избриши" 
            onclick="izbrisi_click" CssClass="margin-right" />
        <asp:Button ID="btnSledno" runat="server" Text="Следно" 
            onclick="sledno_click" CssClass="margin-right" Enabled="False" />
        </div>
    <div style="margin-bottom: 2px">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/img/pitanje.png" 
            CssClass="margin-right" />
        <asp:Image ID="Image2" runat="server" ImageUrl="~/img/pitanje.png" 
            CssClass="margin-right" />
        <asp:Image ID="Image3" runat="server" ImageUrl="~/img/pitanje.png" 
            CssClass="margin-right" />
        <asp:Image ID="Image4" runat="server" ImageUrl="~/img/pitanje.png" 
            CssClass="margin-right" />
        <asp:Image ID="Image5" runat="server" CssClass="margin-left margin-right" 
            Visible="False" />
        <asp:Image ID="Image6" runat="server" CssClass="margin-right" Visible="False" />
        <asp:Image ID="Image7" runat="server" CssClass="margin-right" Visible="False" />
        <asp:Image ID="Image8" runat="server" CssClass="margin-right" Visible="False" />
        </div>
        <div style="margin-bottom: 2px">
        <asp:Image ID="Image9" runat="server" ImageUrl="~/img/pitanje.png" 
            CssClass="margin-right" />
        <asp:Image ID="Image10" runat="server" ImageUrl="~/img/pitanje.png" 
            CssClass="margin-right" />
        <asp:Image ID="Image11" runat="server" ImageUrl="~/img/pitanje.png" 
            CssClass="margin-right" />
        <asp:Image ID="Image12" runat="server" ImageUrl="~/img/pitanje.png" 
            CssClass="margin-right" />
        <asp:Image ID="Image13" runat="server" CssClass="margin-left margin-right" 
            Visible="False" />
        <asp:Image ID="Image14" runat="server" CssClass="margin-right" Visible="False" />
        <asp:Image ID="Image15" runat="server" CssClass="margin-right" Visible="False" />
        <asp:Image ID="Image16" runat="server" CssClass="margin-right" Visible="False" />
        </div>
        <div style="margin-bottom: 2px">
        <asp:Image ID="Image17" runat="server" ImageUrl="~/img/pitanje.png" 
            CssClass="margin-right" />
        <asp:Image ID="Image18" runat="server" ImageUrl="~/img/pitanje.png" 
            CssClass="margin-right" />
        <asp:Image ID="Image19" runat="server" ImageUrl="~/img/pitanje.png" 
            CssClass="margin-right" />
        <asp:Image ID="Image20" runat="server" ImageUrl="~/img/pitanje.png" 
            CssClass="margin-right" />
        <asp:Image ID="Image21" runat="server" CssClass="margin-left margin-right" 
            Visible="False" />
        <asp:Image ID="Image22" runat="server" CssClass="margin-right" Visible="False" />
        <asp:Image ID="Image23" runat="server" CssClass="margin-right" Visible="False" />
        <asp:Image ID="Image24" runat="server" CssClass="margin-right" Visible="False" />
        </div>
        <div style="margin-bottom: 2px">
        <asp:Image ID="Image25" runat="server" ImageUrl="~/img/pitanje.png" 
            CssClass="margin-right" />
        <asp:Image ID="Image26" runat="server" ImageUrl="~/img/pitanje.png" 
            CssClass="margin-right" />
        <asp:Image ID="Image27" runat="server" ImageUrl="~/img/pitanje.png" 
            CssClass="margin-right" />
        <asp:Image ID="Image28" runat="server" ImageUrl="~/img/pitanje.png" 
            CssClass="margin-right" />
        <asp:Image ID="Image29" runat="server" CssClass="margin-left margin-right" 
            Visible="False" />
        <asp:Image ID="Image30" runat="server" CssClass="margin-right" Visible="False" />
        <asp:Image ID="Image31" runat="server" CssClass="margin-right" Visible="False" />
        <asp:Image ID="Image32" runat="server" CssClass="margin-right" Visible="False" />
        </div>
        <div style="margin-bottom: 2px">
        <asp:Image ID="Image33" runat="server" ImageUrl="~/img/pitanje.png" 
            CssClass="margin-right" />
        <asp:Image ID="Image34" runat="server" ImageUrl="~/img/pitanje.png" 
            CssClass="margin-right" />
        <asp:Image ID="Image35" runat="server" ImageUrl="~/img/pitanje.png" 
            CssClass="margin-right" />
        <asp:Image ID="Image36" runat="server" ImageUrl="~/img/pitanje.png" 
            CssClass="margin-right" />
        <asp:Image ID="Image37" runat="server" CssClass="margin-left margin-right" 
            Visible="False" />
        <asp:Image ID="Image38" runat="server" CssClass="margin-right" Visible="False" />
        <asp:Image ID="Image39" runat="server" CssClass="margin-right" Visible="False" />
        <asp:Image ID="Image40" runat="server" CssClass="margin-right" Visible="False" />
        </div>
        <div style="margin-bottom: 2px">
        <asp:Image ID="Image41" runat="server" ImageUrl="~/img/pitanje.png" 
            CssClass="margin-right" />
        <asp:Image ID="Image42" runat="server" ImageUrl="~/img/pitanje.png" 
            CssClass="margin-right" />
        <asp:Image ID="Image43" runat="server" ImageUrl="~/img/pitanje.png" 
            CssClass="margin-right" />
        <asp:Image ID="Image44" runat="server" ImageUrl="~/img/pitanje.png" 
            CssClass="margin-right" />
        <asp:Image ID="Image45" runat="server" CssClass="margin-left margin-right" 
            Visible="False" />
        <asp:Image ID="Image46" runat="server" CssClass="margin-right" Visible="False" />
        <asp:Image ID="Image47" runat="server" CssClass="margin-right" Visible="False" />
        <asp:Image ID="Image48" runat="server" CssClass="margin-right" Visible="False" />
        </div>
        <div style="margin-bottom: 2px">
        <asp:Image ID="Image49" runat="server" ImageUrl="~/img/pitanje.png" 
            CssClass="margin-right" />
        <asp:Image ID="Image50" runat="server" ImageUrl="~/img/pitanje.png" 
            CssClass="margin-right" />
        <asp:Image ID="Image51" runat="server" ImageUrl="~/img/pitanje.png" 
            CssClass="margin-right" />
        <asp:Image ID="Image52" runat="server" ImageUrl="~/img/pitanje.png" 
            CssClass="margin-right" />
        <asp:Image ID="Image53" runat="server" CssClass="margin-left margin-right" 
            Visible="False" />
        <asp:Image ID="Image54" runat="server" CssClass="margin-right" Visible="False" />
        <asp:Image ID="Image55" runat="server" CssClass="margin-right" Visible="False" />
        <asp:Image ID="Image56" runat="server" CssClass="margin-right" Visible="False" />
        </div>
        <div style="margin-bottom: 2px">
        <asp:Image ID="Image57" runat="server" ImageUrl="~/img/pitanje.png" 
            CssClass="margin-right" />
        <asp:Image ID="Image58" runat="server" ImageUrl="~/img/pitanje.png" 
            CssClass="margin-right" />
        <asp:Image ID="Image59" runat="server" ImageUrl="~/img/pitanje.png" 
            CssClass="margin-right" />
        <asp:Image ID="Image60" runat="server" ImageUrl="~/img/pitanje.png" 
            CssClass="margin-right" />
        <asp:Image ID="Image61" runat="server" CssClass="margin-left margin-right" 
            Visible="False" />
        <asp:Image ID="Image62" runat="server" CssClass="margin-right" Visible="False" />
        <asp:Image ID="Image63" runat="server" CssClass="margin-right" Visible="False" />
        <asp:Image ID="Image64" runat="server" CssClass="margin-right" Visible="False" />
        </div>

    <div style="margin-bottom: 10px"></div>

</div>
</asp:Content>

