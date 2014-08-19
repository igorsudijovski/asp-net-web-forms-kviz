<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Admin_Users.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="navigationBar" ContentPlaceHolderID="mainLinks" Runat="Server">
    
    <asp:HyperLink ID="users" runat="server" CssClass="main-links text-bold" 
        NavigateUrl="~/Admin_Users.aspx">Корисници</asp:HyperLink>
    <asp:HyperLink ID="associations" runat="server" CssClass="main-links" 
        NavigateUrl="~/Admin_Association.aspx">Асоцијација</asp:HyperLink>
        <asp:HyperLink ID="lnkQuestions" runat="server" CssClass="main-links" 
        NavigateUrl="~/Admin_Question.aspx">Прашања</asp:HyperLink>
        <div class="logedUser"> Вие сте најавен како <asp:Label ID="lblLogedUser" 
                runat="server" Text="Label" Font-Bold="True"></asp:Label></div>
    <asp:LinkButton ID="logOutButton" runat="server" 
        CssClass="main-links log-out-button" onclick="logOut_click">Одлогирај се</asp:LinkButton>
        
</asp:Content>
<asp:Content ID="mainContent" ContentPlaceHolderID="mainContent" Runat="Server">
    <div class="main-content">
    <div>
        <asp:Label ID="lstBoxLabel" runat="server" Text="Кориснички имиња" 
            Width="200px" CssClass="vertical"></asp:Label>
        <asp:ListBox ID="lstBoxUsers" runat="server" Height="100px" Width="300px" 
            AutoPostBack="True" onselectedindexchanged="selectUserForEditing"></asp:ListBox>
    </div>
    <div style="margin-bottom: 15px">
        <asp:Label ID="error" runat="server" ForeColor="Red" Visible="False"></asp:Label>
    </div>
    <div>
        <asp:Label ID="lblUserName" runat="server" Text="Корисничко име" Width="200px"></asp:Label>
        <asp:TextBox ID="txtUsername" runat="server" CssClass="margin-right" 
            ValidationGroup="validation1"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
            ControlToValidate="txtUsername" CssClass="margin-right" 
            ErrorMessage="Може да содржи мали букви, големи букви, бројки и _" 
            ForeColor="Red" ValidationExpression="^[0-9a-zA-Z_]*$" 
            ValidationGroup="validation1"></asp:RegularExpressionValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
            ControlToValidate="txtUsername" ErrorMessage="Минмална големина од 4 карактери" 
            ForeColor="Red" ValidationExpression=".{4,}" CssClass="margin-right" 
            ValidationGroup="validation1"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="txtUsername" ForeColor="Red" ValidationGroup="validation1">Задолжително поле</asp:RequiredFieldValidator>
    </div>
    <div>
        <asp:Label ID="lblPassword" runat="server" Text="Лозинка" Width="200px"></asp:Label>
        <asp:TextBox ID="password" runat="server" CssClass="margin-right" 
            ValidationGroup="validation1"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
            ControlToValidate="password" CssClass="margin-right" 
            ErrorMessage="Минимум: 1 голема буква, 1 мала буква , 1 бројка" ForeColor="Red" 
            ValidationExpression="^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])[0-9a-zA-Z]*$" 
            ValidationGroup="validation1"></asp:RegularExpressionValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
            ControlToValidate="password" ErrorMessage="Минмална големина од 6 карактери" 
            ForeColor="Red" ValidationExpression=".{6,}" CssClass="margin-right" 
            ValidationGroup="validation1"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="password" ForeColor="Red" ValidationGroup="validation1">Задолжително поле</asp:RequiredFieldValidator>
    </div>
    
    <div>
        <asp:CheckBox ID="chkAdmin" runat="server" CssClass="login-button" 
            Text="Админски привилегии" />
        </div>
<div>
    <asp:Button ID="btnAdd" runat="server" CssClass="margin-right" 
        Text="Додади" onclick="addUserClick" ValidationGroup="validation1" />
    <asp:Button ID="btnSave" runat="server" CssClass="margin-right" 
        Text="Зачувај" Enabled="False" onclick="saveUserClick" 
        ValidationGroup="validation1" />
    <asp:Button ID="btnCancel" runat="server" CssClass="margin-right" Text="Откажи" 
        Enabled="False" onclick="cancelClick" />
    <asp:Button ID="btnDelete" runat="server" CssClass="margin-right" 
        Text="Избриши" Enabled="False" onclick="deleteClick" />
</div>
</div>
</asp:Content>

