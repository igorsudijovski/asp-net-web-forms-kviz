<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Admin_Question.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="navigationBar" ContentPlaceHolderID="mainLinks" Runat="Server">
    
    <asp:HyperLink ID="users" runat="server" CssClass="main-links" 
        NavigateUrl="~/Admin_Users.aspx">Корисници</asp:HyperLink>
    <asp:HyperLink ID="associations" runat="server" CssClass="main-links" 
        NavigateUrl="~/Admin_Association.aspx">Асоцијација</asp:HyperLink>
        <asp:HyperLink ID="lnkQuestions" runat="server" CssClass="main-links text-bold" 
        NavigateUrl="~/Admin_Question.aspx">Прашања</asp:HyperLink>
        <div class="logedUser"> Вие сте најавен како <asp:Label ID="lblLogedUser" 
                runat="server" Text="Label" Font-Bold="True"></asp:Label></div>
    <asp:LinkButton ID="logOutButton" runat="server" 
        CssClass="main-links log-out-button" onclick="logOut_click">Одлогирај се</asp:LinkButton>
        
</asp:Content>
<asp:Content ID="mainContent" ContentPlaceHolderID="mainContent" Runat="Server">
    <div class="main-content">
    <div>
        <asp:Label ID="lstBoxLabel" runat="server" Text="Опис на прашањето" 
            Width="200px" CssClass="vertical"></asp:Label>
        <asp:ListBox ID="lstBoxQuestions" runat="server" Height="100px" Width="300px" 
            AutoPostBack="True" onselectedindexchanged="selectQuestionForEditing"></asp:ListBox>
    </div>
    <div style="margin-bottom: 15px">
        <asp:Label ID="error" runat="server" ForeColor="Red" Visible="False"></asp:Label>
    </div>
    <div>
        <asp:Label ID="lblUserName" runat="server" Text="Опис на прашањето" Width="200px"></asp:Label>
        <asp:TextBox ID="txtOpis" runat="server" CssClass="margin-right" 
            ValidationGroup="validation1" Width="200px"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
            ControlToValidate="txtOpis" CssClass="margin-right" 
            ErrorMessage="Може да содржи мали букви, големи букви и бројки" 
            ForeColor="Red" ValidationExpression="^[a-zA-Z0-9]*$" 
            ValidationGroup="validation1"></asp:RegularExpressionValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server"     
            ControlToValidate="txtOpis" ErrorMessage="Минмална големина од 4 карактери" 
            ForeColor="Red" ValidationExpression=".{4,}" CssClass="margin-right" 
            ValidationGroup="validation1"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="txtOpis" ForeColor="Red" ValidationGroup="validation1">Задолжително поле</asp:RequiredFieldValidator>
    </div>
    <div>
        <asp:Label ID="lblUserName0" runat="server" Text="Прашање" Width="200px" 
            CssClass="vertical"></asp:Label>
        <asp:TextBox ID="txtQuestion" runat="server" CssClass="margin-right" Rows="3" 
            TextMode="MultiLine" Width="300px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="txtQuestion" ForeColor="Red" 
            ValidationGroup="validation1">Задолжително поле</asp:RequiredFieldValidator>
    </div>
    <div>
        <asp:Label ID="lblAnswer1" runat="server" Text="Одговор 1" Width="200px"></asp:Label>
        <asp:TextBox ID="txtAnswer1" runat="server" CssClass="margin-right" 
            ValidationGroup="validation1" Width="200px"></asp:TextBox>
        <asp:RadioButton ID="RadioButtonAnswer1" runat="server" Checked="True" 
            CssClass="margin-right" GroupName="Answer" Text="Точен одговор" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
            ControlToValidate="txtAnswer1" ForeColor="Red" 
            ValidationGroup="validation1">Задолжително поле</asp:RequiredFieldValidator>
        </div>
    <div>
    <asp:Label ID="lblAnswer2" runat="server" Text="Одговор 2" Width="200px"></asp:Label>
        <asp:TextBox ID="txtAnswer2" runat="server" CssClass="margin-right" 
            ValidationGroup="validation1" Width="200px"></asp:TextBox>
        <asp:RadioButton ID="RadioButtonAnswer2" runat="server" Checked="false" 
            CssClass="margin-right" GroupName="Answer" Text="Точен одговор" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
            ControlToValidate="txtAnswer2" ForeColor="Red" 
            ValidationGroup="validation1">Задолжително поле</asp:RequiredFieldValidator>
            </div>
    <div>
    <asp:Label ID="lblAnswer3" runat="server" Text="Одговор 3" Width="200px"></asp:Label>
        <asp:TextBox ID="txtAnswer3" runat="server" CssClass="margin-right" 
            ValidationGroup="validation1" Width="200px"></asp:TextBox>
        <asp:RadioButton ID="RadioButtonAnswer3" runat="server" Checked="false" 
            CssClass="margin-right" GroupName="Answer" Text="Точен одговор" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
            ControlToValidate="txtAnswer3" ForeColor="Red" 
            ValidationGroup="validation1">Задолжително поле</asp:RequiredFieldValidator></div>
    <div>
    <asp:Label ID="lblAnswer4" runat="server" Text="Одговор 4" Width="200px"></asp:Label>
        <asp:TextBox ID="txtAnswer4" runat="server" CssClass="margin-right" 
            ValidationGroup="validation1" Width="200px"></asp:TextBox>
        <asp:RadioButton ID="RadioButtonAnswer4" runat="server" Checked="false" 
            CssClass="margin-right" GroupName="Answer" Text="Точен одговор" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
            ControlToValidate="txtAnswer4" ForeColor="Red" 
            ValidationGroup="validation1">Задолжително поле</asp:RequiredFieldValidator></div>
<div>
    <asp:Button ID="btnAdd" runat="server" CssClass="margin-right" 
        Text="Додади" onclick="addQuestionClick" ValidationGroup="validation1" />
    <asp:Button ID="btnSave" runat="server" CssClass="margin-right" 
        Text="Зачувај" Enabled="False" onclick="saveQuestionClick" 
        ValidationGroup="validation1" />
    <asp:Button ID="btnCancel" runat="server" CssClass="margin-right" Text="Откажи" 
        Enabled="False" onclick="cancelClick" />
    <asp:Button ID="btnDelete" runat="server" CssClass="margin-right" 
        Text="Избриши" Enabled="False" onclick="deleteClick" />
</div>
</div>
</asp:Content>

