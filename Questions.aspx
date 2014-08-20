<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Questions.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="navigationBar" ContentPlaceHolderID="mainLinks" Runat="Server">
    
            <div class="logedUser"> Ваши поени <asp:Label ID="points" 
                runat="server" Text="Label" Font-Bold="True"></asp:Label></div>
        <div class="logedUser"> Вие сте најавен како <asp:Label ID="lblLogedUser" 
                runat="server" Text="Label" Font-Bold="True"></asp:Label></div>
    <asp:LinkButton ID="logOutButton" runat="server" 
        CssClass="main-links log-out-button" onclick="finish_game_click">Прекини игра</asp:LinkButton>
        
</asp:Content>
<asp:Content ID="mainContent" ContentPlaceHolderID="mainContent" Runat="Server">
    <div style="margin-bottom: 15px; margin-left: 20px;">
        <asp:Label ID="error" runat="server" ForeColor="Red" Visible="False"></asp:Label>
    </div>
    <div class="main-content">
    <div style="margin-bottom: 10px">  
    <asp:Label ID="lblquestionNumber" runat="server"></asp:Label>
        <asp:Label ID="Question" runat="server"></asp:Label>
        </div>
    <div style="margin-bottom: 10px">  
        <asp:RadioButton ID="answer1" runat="server" AutoPostBack="True" 
            GroupName="answer" oncheckedchanged="change_radio_button" />
        </div>
    <div style="margin-bottom: 10px">  
        <asp:RadioButton ID="answer2" runat="server" AutoPostBack="True" 
            GroupName="answer" oncheckedchanged="change_radio_button" />
        </div>
    <div style="margin-bottom: 10px">  
        <asp:RadioButton ID="answer3" runat="server" AutoPostBack="True" 
            GroupName="answer" oncheckedchanged="change_radio_button" />
        </div>
    <div style="margin-bottom: 10px">  
        <asp:RadioButton ID="answer4" runat="server" AutoPostBack="True" 
            GroupName="answer" oncheckedchanged="change_radio_button" />
        </div>
    <div style="margin-bottom: 10px">  
        <asp:Label ID="lblOdgovor" runat="server" CssClass="margin-right" Text="Label"></asp:Label>
        <asp:Button ID="btnPotvrda" runat="server" CssClass="margin-right" 
            onclick="potvrdi_click" Text="Потврди" />
        <asp:Button ID="btnSledno" runat="server" onclick="sledno_click" 
            Text="Следно" />
        </div>
</div>
</asp:Content>

