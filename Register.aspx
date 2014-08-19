<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="navigationBar" ContentPlaceHolderID="mainLinks" Runat="Server">
    <asp:HyperLink ID="register" runat="server" CssClass="main-links text-bold" 
        NavigateUrl="~/Register.aspx">Регистрирај се</asp:HyperLink>
    <asp:HyperLink ID="logIn" runat="server" CssClass="main-links" 
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
        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
            ControlToValidate="username" CssClass="margin-right" 
            ErrorMessage="Може да содржи мали букви, големи букви, бројки и _" 
            ForeColor="Red" ValidationExpression="^[0-9a-zA-Z_]*$"></asp:RegularExpressionValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
            ControlToValidate="username" ErrorMessage="Минмална големина од 4 карактери" 
            ForeColor="Red" ValidationExpression=".{4,}" CssClass="margin-right"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="username" ForeColor="Red">Задолжително поле</asp:RequiredFieldValidator>
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
    <asp:Button ID="btnRegister" runat="server" CssClass="login-button" Text="Регистрирај ме" 
        onclick="registerClick" />
</div>
</div>
</asp:Content>


