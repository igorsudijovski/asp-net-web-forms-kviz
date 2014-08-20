<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Podesuvanja.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="navigationBar" ContentPlaceHolderID="mainLinks" Runat="Server">
    
    
    <asp:HyperLink ID="preferences" runat="server" CssClass="main-links text-bold" 
        NavigateUrl="~/Podesuvanja.aspx">Подесувања</asp:HyperLink>
        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="main-links text-bold" 
        NavigateUrl="~/Admin_Users.aspx">Почетна</asp:HyperLink>
        <div class="logedUser"> Вие сте најавен како <asp:Label ID="lblLogedUser" 
                runat="server" Text="Label" Font-Bold="True"></asp:Label></div>
    <asp:LinkButton ID="logOutButton" runat="server" 
        CssClass="main-links log-out-button" onclick="logOut_click">Одлогирај се</asp:LinkButton>
        
</asp:Content>
<asp:Content ID="mainContent" ContentPlaceHolderID="mainContent" Runat="Server">
    <div class="main-content">
    <div>
        <asp:Label ID="error" runat="server" ForeColor="Red" Visible="False"></asp:Label>
    </div>
    <div>
        <asp:Label ID="lblUserName" runat="server" Text="Стара лозинка" Width="200px"></asp:Label>
        <asp:TextBox ID="txtOldPassword" runat="server" CssClass="margin-right" 
            TextMode="Password"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="lblPassword" runat="server" Text="Лозинка" Width="200px"></asp:Label>
        <asp:TextBox ID="password" runat="server" CssClass="margin-right" 
            TextMode="Password"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
            ControlToValidate="password" CssClass="margin-right" 
            ErrorMessage="Минимум: 1 голема буква, 1 мала буква , 1 бројка" ForeColor="Red" 
            ValidationExpression="^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])[0-9a-zA-Z]*$"></asp:RegularExpressionValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
            ControlToValidate="password" ErrorMessage="Минмална големина од 6 карактери" 
            ForeColor="Red" ValidationExpression=".{6,}" CssClass="margin-right"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="password" ForeColor="Red">Задолжително поле</asp:RequiredFieldValidator>
    </div>
    <div>
        <asp:Label ID="lblPasswordRepeat" runat="server" Text="Повтори лозинка" 
            Width="200px"></asp:Label>
        <asp:TextBox ID="passwordrepeat" runat="server" CssClass="margin-right" 
            TextMode="Password"></asp:TextBox>
        <asp:CompareValidator ID="CompareValidator1" runat="server" 
            ControlToCompare="password" ControlToValidate="passwordrepeat" 
            ErrorMessage="Лозинката не е иста како претходната" ForeColor="Red"></asp:CompareValidator>
    </div>
<div>
    <asp:Button ID="btnPromeni" runat="server" CssClass="login-button" Text="Промени" 
        onclick="promeni_click" />
</div>
</div>
</asp:Content>

