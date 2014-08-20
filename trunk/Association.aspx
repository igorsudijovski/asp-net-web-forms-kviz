<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Association.aspx.cs" Inherits="_Default" %>

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
        CssClass="main-links log-out-button" onclick="finish_game_click">Прекини игра</asp:LinkButton>n>
        
</asp:Content>
<asp:Content ID="mainContent" ContentPlaceHolderID="mainContent" Runat="Server">
    <div class="main-content">
    <div style="margin-bottom: 15px">
        <asp:Label ID="error" runat="server" ForeColor="Red" Visible="False"></asp:Label>
    </div>
    <div>
        
        <asp:Label ID="Label1" runat="server" Text="Ваш одговор: "></asp:Label>
        <asp:TextBox ID="txtOdgovor" runat="server"></asp:TextBox>
&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" 
            Text="Број на обиди за главното решение: "></asp:Label>
        <asp:Label ID="lblObidi" runat="server" Text="Label"></asp:Label>
        
    </div>
    <div style="float:left; clear:both; width:100%">
        <div class="txt-a1">
            <asp:Button ID="Button1" runat="server" Text="A 1" Width="100px" 
                onclick="Otvori_pole_click" />
        </div>
        <div class="txt-b1">
        <asp:Button ID="Button2" runat="server" Text="B 1" Width="100px" 
         onclick="Otvori_pole_click"/>
        </div>
    </div>
    <div style="float:left; clear:both; width:100%">
        <div class="txt-a2">
            <asp:Button ID="Button3" runat="server" Text="A 2" Width="100px" 
                onclick="Otvori_pole_click" />
        </div>
        <div class="txt-b2">
        <asp:Button ID="Button4" runat="server" Text="B 2" Width="100px" 
         onclick="Otvori_pole_click"/>
        </div>
    </div>
    <div style="float:left; clear:both; width:100%">
        <div class="txt-a3">
            <asp:Button ID="Button5" runat="server" Text="A 3" Width="100px" 
                onclick="Otvori_pole_click" />
        </div>
        <div class="txt-b3">
        <asp:Button ID="Button6" runat="server" Text="B 3" Width="100px" 
         onclick="Otvori_pole_click"/>
        </div>
    </div>
    <div style="float:left; clear:both; width:100%">
        <div class="txt-a4">
            <asp:Button ID="Button7" runat="server" Text="A 4" Width="100px" 
                onclick="Otvori_pole_click" />
        </div>
        <div class="txt-b4">
        <asp:Button ID="Button8" runat="server" Text="B 4" Width="100px" 
         onclick="Otvori_pole_click"/>
        </div>
    </div>
    <div style="float:left; clear:both; width:100%">
        <div class="txt-a5">
            <asp:Button ID="btnOdgovor1" runat="server" Text="A Одговор" Width="100px" 
                onclick="Odgovor_pole_click" />
        </div>
        <div class="txt-b5">
        <asp:Button ID="btnOdgovor2" runat="server" Text="B Одговор" Width="100px" 
         onclick="Odgovor_pole_click"/>
        </div>
    </div>
    <div style="float:left; clear:both; width:100%">
        <asp:Button CssClass="txt-final" ID="btnOdgovorKonecen" runat="server" 
            Text="Конечен одговор" Width="150px" 
         onclick="Odgovor_pole_konecno_click"/>
    </div>
    <div style="float:left; clear:both; width:100%">
        <div class="txt-a5">
            <asp:Button ID="btnOdgovor3" runat="server" Text="C Одговор" Width="100px" 
                onclick="Odgovor_pole_click" />
        </div>
        <div class="txt-b5">
        <asp:Button ID="btnOdgovor4" runat="server" Text="D Одговор" Width="100px" 
         onclick="Odgovor_pole_click"/>
        </div>
    </div>
        <div style="float:left; clear:both; width:100%">
        <div class="txt-a4">
            <asp:Button ID="Button14" runat="server" Text="C 4" Width="100px" 
                onclick="Otvori_pole_click" />
        </div>
        <div class="txt-b4">
        <asp:Button ID="Button15" runat="server" Text="D 4" Width="100px" 
         onclick="Otvori_pole_click"/>
        </div>
    </div>
    <div style="float:left; clear:both; width:100%">
        <div class="txt-a3">
            <asp:Button ID="Button16" runat="server" Text="C 3" Width="100px" 
                onclick="Otvori_pole_click" />
        </div>
        <div class="txt-b3">
        <asp:Button ID="Button17" runat="server" Text="D 3" Width="100px" 
         onclick="Otvori_pole_click"/>
        </div>
    </div>
    <div style="float:left; clear:both; width:100%">
        <div class="txt-a2">
            <asp:Button ID="Button18" runat="server" Text="C 2" Width="100px" 
                onclick="Otvori_pole_click" />
        </div>
        <div class="txt-b2">
        <asp:Button ID="Button19" runat="server" Text="D 2" Width="100px" 
         onclick="Otvori_pole_click"/>
        </div>
    </div>
    <div style="float:left; clear:both; width:100%">
        <div class="txt-a1">
            <asp:Button ID="Button20" runat="server" Text="C 1" Width="100px" 
                onclick="Otvori_pole_click" />
        </div>
        <div class="txt-b1">
        <asp:Button ID="Button21" runat="server" Text="D 1" Width="100px" 
         onclick="Otvori_pole_click"/>
        </div>
    </div>
</div>
</asp:Content>

