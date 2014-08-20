<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Moj_Broj.aspx.cs" Inherits="_Default" %>

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
    <div style="margin-bottom: 15px; margin-left: 20px;">
        <asp:Label ID="error" runat="server" ForeColor="Red" Visible="False"></asp:Label>
    </div>
    <div class="main-content">
    <div style="margin-bottom: 10px">
        <asp:Button ID="number1" runat="server" CssClass="margin-right" Text="Button" 
            onclick="button_click" />
        <asp:Button ID="number2" runat="server" CssClass="margin-right" Text="Button" 
            onclick="button_click" />
        <asp:Button ID="number3" runat="server" CssClass="margin-right" Text="Button" 
            onclick="button_click" />
        <asp:Button ID="number4" runat="server" CssClass="margin-right" Text="Button" 
            onclick="button_click" />
        <asp:Button ID="middleNumber" runat="server" CssClass="margin-right" 
            Text="Button" onclick="button_click" />
        <asp:Button ID="bigNumber" runat="server" CssClass="margin-right" Text="Button" 
            onclick="button_click" />
        </div>
    <div style="margin-bottom: 10px">
    <asp:Button ID="plus" runat="server" CssClass="margin-right" Text="+" 
            onclick="button_click" />
        <asp:Button ID="minus" runat="server" CssClass="margin-right" Text="-" 
            onclick="button_click" />
        <asp:Button ID="multiple" runat="server" CssClass="margin-right" Text="*" 
            onclick="button_click" />
        <asp:Button ID="divided" runat="server" CssClass="margin-right" Text="/" 
            onclick="button_click" />
        <asp:Button ID="zagrada1" runat="server" CssClass="margin-right" Text="(" 
            onclick="button_click" />
        <asp:Button ID="zagrada2" runat="server" CssClass="margin-right" Text=")" 
            onclick="button_click" /></div>
            <div style="margin-bottom: 10px">
                <asp:Label ID="Label1" runat="server" Text="Треба да се добие бројот: "></asp:Label>
                <asp:TextBox ID="txtFinal" runat="server" Enabled="False"></asp:TextBox>
        </div>
    <div style="margin-bottom: 10px">
        <asp:TextBox ID="txtExpression" runat="server" CssClass="margin-right" 
            Width="250px" Enabled="False"></asp:TextBox>
        =&nbsp;
        <asp:TextBox ID="txtCalculated" runat="server" CssClass="margin-right" 
            Enabled="False" Width="90px"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" CssClass="margin-right" 
            Text="Пресметај" onclick="calculate_click" />
        <asp:Button ID="Button2" runat="server" Text="Избриши" CssClass="margin-right" 
            onclick="erase_Click" />
        <asp:Button ID="Button3" runat="server" Text="Потврди" 
            CssClass="margin-right" onclick="potvrdi_click" />
    </div>
</div>
</asp:Content>

