<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="navigationBar" ContentPlaceHolderID="mainLinks" Runat="Server">
    <asp:HyperLink ID="register" runat="server" CssClass="main-links" 
        NavigateUrl="~/Register.aspx">Регистрирај се</asp:HyperLink>
    <asp:HyperLink ID="logIn" runat="server" CssClass="text-bold main-links" 
        NavigateUrl="~/Login.aspx">Најави се</asp:HyperLink>
</asp:Content>
<asp:Content ID="mainContent" ContentPlaceHolderID="mainContent" Runat="Server">
    <div class="margin-left">
    <div>
        <asp:Label ID="error" runat="server" ForeColor="Red" Visible="False"></asp:Label>
    </div>
    <div>
        <asp:Label ID="lblUserName" runat="server" Text="Корисничко име" Width="200px"></asp:Label>
        <asp:TextBox ID="username" runat="server" CssClass="margin-right"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="username" ErrorMessage="Задолжително поле" ForeColor="Red"></asp:RequiredFieldValidator>
    </div>
    <div>
        <asp:Label ID="lblPassword" runat="server" Text="Лозинка" Width="200px"></asp:Label>
        <asp:TextBox ID="password" runat="server" CssClass="margin-right" 
            TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="password" ErrorMessage="Задолжително поле" ForeColor="Red"></asp:RequiredFieldValidator>
    </div>
    <div>
        <asp:CheckBox ID="keepMeLogin" runat="server" CssClass="login-button" 
            Text="Зачувај ме најавен" />
    </div>
<div>
    <asp:Button ID="btnNajava" runat="server" CssClass="login-button" Text="Најава" 
        onclick="logInClick" />
</div>
</div>
</asp:Content>

