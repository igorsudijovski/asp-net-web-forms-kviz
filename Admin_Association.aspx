<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Admin_Association.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="navigationBar" ContentPlaceHolderID="mainLinks" Runat="Server">
    
    <asp:HyperLink ID="users" runat="server" CssClass="main-links" 
        NavigateUrl="~/Admin_Users.aspx">Корисници</asp:HyperLink>
    <asp:HyperLink ID="associations" runat="server" CssClass="main-links text-bold" 
        NavigateUrl="~/Admin_Association.aspx">Асоцијација</asp:HyperLink>
        <asp:HyperLink ID="lnkQuestions" runat="server" CssClass="main-links" 
        NavigateUrl="~/Login.aspx">Прашања</asp:HyperLink>
        <div class="logedUser"> Вие сте најавен како <asp:Label ID="lblLogedUser" 
                runat="server" Text="Label" Font-Bold="True"></asp:Label></div>
    <asp:LinkButton ID="logOutButton" runat="server" 
        CssClass="main-links log-out-button" onclick="logOut_click">Одлогирај се</asp:LinkButton>
        
</asp:Content>
<asp:Content ID="mainContent" ContentPlaceHolderID="mainContent" Runat="Server">
    <div class="main-content">
    <div>
        <asp:Label ID="lstBoxLabel" runat="server" Text="Асоциации" Width="200px"></asp:Label>
        <asp:ListBox ID="lstBoxAsociation" runat="server" Height="96px" Width="93px" 
            AutoPostBack="True" onselectedindexchanged="selectAsocForEditing"></asp:ListBox>
    </div>
    <div style="margin-bottom: 15px">
        <asp:Label ID="error" runat="server" ForeColor="Red" Visible="False"></asp:Label>
    </div>
    <div>
        <asp:Label ID="lblAsocName" runat="server" Text="Име на асоцијациа" Width="200px"></asp:Label>
        <asp:TextBox ID="txtAsocName" runat="server" CssClass="margin-right" 
            ValidationGroup="validation1"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
            ControlToValidate="txtAsocName" CssClass="margin-right" 
            ErrorMessage="Може да содржи мали букви, големи букви и бројки" 
            ForeColor="Red" ValidationExpression="^[a-zA-Z0-9]*$" 
            ValidationGroup="validation1"></asp:RegularExpressionValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server"     
            ControlToValidate="txtAsocName" ErrorMessage="Минмална големина од 4 карактери" 
            ForeColor="Red" ValidationExpression=".{4,}" CssClass="margin-right" 
            ValidationGroup="validation1"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="txtAsocName" ForeColor="Red" ValidationGroup="validation1">Задолжително поле</asp:RequiredFieldValidator>
    </div>
    <div style="float:left; clear:both; width:100%">
        <div class="txt-a1"><span>A1:</span><asp:TextBox ID="txtA1" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
            ControlToValidate="txtA1" ErrorMessage="*" Font-Bold="True" ForeColor="Red" ValidationGroup="validation1"></asp:RequiredFieldValidator></div>
        <div class="txt-b1">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="txtB1" ErrorMessage="*" Font-Bold="True" ForeColor="Red" ValidationGroup="validation1"></asp:RequiredFieldValidator><span>B1:</span><asp:TextBox CssClass="" ID="txtB1" runat="server"></asp:TextBox>
        
        </div>
    </div>
    <div style="float:left; clear:both; width:100%">
        <div class="txt-a2"><span>A2:</span><asp:TextBox ID="txtA2" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
            ControlToValidate="txtA2" ErrorMessage="*" Font-Bold="True" ForeColor="Red" ValidationGroup="validation1"></asp:RequiredFieldValidator></div>
        <div class="txt-b2">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
            ControlToValidate="txtB2" ErrorMessage="*" Font-Bold="True" ForeColor="Red" ValidationGroup="validation1"></asp:RequiredFieldValidator><span>B2:</span><asp:TextBox CssClass="" ID="txtB2" runat="server"></asp:TextBox>
        </div>
    </div>
    <div style="float:left; clear:both; width:100%">
        <div class="txt-a3"><span>A3:</span><asp:TextBox ID="txtA3" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
            ControlToValidate="txtA3" ErrorMessage="*" Font-Bold="True" ForeColor="Red" ValidationGroup="validation1"></asp:RequiredFieldValidator></div>
        <div class="txt-b3">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
            ControlToValidate="txtB3" ErrorMessage="*" Font-Bold="True" ForeColor="Red" ValidationGroup="validation1"></asp:RequiredFieldValidator><span>B3:</span><asp:TextBox CssClass="" ID="txtB3" runat="server"></asp:TextBox>
        </div>
    </div>
    <div style="float:left; clear:both; width:100%">
        <div class="txt-a4"><span>A4:</span><asp:TextBox ID="txtA4" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
            ControlToValidate="txtA4" ErrorMessage="*" Font-Bold="True" ForeColor="Red" ValidationGroup="validation1"></asp:RequiredFieldValidator></div>
        <div class="txt-b4">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
            ControlToValidate="txtB4" ErrorMessage="*" Font-Bold="True" ForeColor="Red" ValidationGroup="validation1"></asp:RequiredFieldValidator><span>B4:</span><asp:TextBox CssClass="" ID="txtB4" runat="server"></asp:TextBox>
        </div>
    </div>
    <div style="float:left; clear:both; width:100%">
        <div class="txt-a5"><span>Одговор:</span><asp:TextBox ID="txtA5" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" 
            ControlToValidate="txtA5" ErrorMessage="*" Font-Bold="True" ForeColor="Red" ValidationGroup="validation1"></asp:RequiredFieldValidator></div>
        <div class="txt-b5">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" 
            ControlToValidate="txtB5" ErrorMessage="*" Font-Bold="True" ForeColor="Red" ValidationGroup="validation1"></asp:RequiredFieldValidator><span>Одговор:</span><asp:TextBox CssClass="" ID="txtB5" runat="server"></asp:TextBox>
        </div>
    </div>
    <div style="float:left; clear:both; width:100%">
        <asp:TextBox CssClass="txt-final" ID="txtFinal" runat="server"></asp:TextBox>
    </div>
        <div style="float:left; clear:both; width:100%">
        <div class="txt-a5"><span>Одговор:</span><asp:TextBox ID="txtC5" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" 
            ControlToValidate="txtC5" ErrorMessage="*" Font-Bold="True" ForeColor="Red" ValidationGroup="validation1"></asp:RequiredFieldValidator>
        </div>
        <div class="txt-b5">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" 
            ControlToValidate="txtD5" ErrorMessage="*" Font-Bold="True" ForeColor="Red" ValidationGroup="validation1"></asp:RequiredFieldValidator><span>Одговор:</span><asp:TextBox CssClass="" ID="txtD5" runat="server"></asp:TextBox>
        </div>
    </div>
    <div style="float:left; clear:both; width:100%">
        <div class="txt-a4"><span>C1:</span><asp:TextBox ID="txtC1" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
            ControlToValidate="txtC1" ErrorMessage="*" Font-Bold="True" ForeColor="Red" ValidationGroup="validation1"></asp:RequiredFieldValidator>
        </div>
        <div class="txt-b4">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
            ControlToValidate="txtD1" ErrorMessage="*" Font-Bold="True" ForeColor="Red" ValidationGroup="validation1"></asp:RequiredFieldValidator><span>D1:</span><asp:TextBox CssClass="" ID="txtD1" runat="server"></asp:TextBox>
        </div>
    </div>
    <div style="float:left; clear:both; width:100%">
        <div class="txt-a3"><span>C2:</span><asp:TextBox ID="txtC2" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
            ControlToValidate="txtC2" ErrorMessage="*" Font-Bold="True" ForeColor="Red" ValidationGroup="validation1"></asp:RequiredFieldValidator></div>
        <div class="txt-b3">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
            ControlToValidate="txtD2" ErrorMessage="*" Font-Bold="True" ForeColor="Red" ValidationGroup="validation1"></asp:RequiredFieldValidator><span>D2:</span><asp:TextBox CssClass="" ID="txtD2" runat="server"></asp:TextBox>
        </div>
    </div>
    <div style="float:left; clear:both; width:100%">
        <div class="txt-a2"><span>C3:</span><asp:TextBox ID="txtC3" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" 
            ControlToValidate="txtC3" ErrorMessage="*" Font-Bold="True" ForeColor="Red" ValidationGroup="validation1"></asp:RequiredFieldValidator></div>
        <div class="txt-b2">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" 
            ControlToValidate="txtD3" ErrorMessage="*" Font-Bold="True" ForeColor="Red" ValidationGroup="validation1"></asp:RequiredFieldValidator><span>D3:</span><asp:TextBox CssClass="" ID="txtD3" runat="server"></asp:TextBox>
        </div>
    </div>
    <div style="float:left; clear:both; width:100%">
        <div class="txt-a1"><span>C4:</span><asp:TextBox ID="txtC4" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" 
            ControlToValidate="txtC4" ErrorMessage="*" Font-Bold="True" ForeColor="Red" ValidationGroup="validation1"></asp:RequiredFieldValidator></div>
        <div class="txt-b1">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" 
            ControlToValidate="txtD4" ErrorMessage="*" Font-Bold="True" ForeColor="Red" ValidationGroup="validation1"></asp:RequiredFieldValidator><span>D4:</span><asp:TextBox CssClass="" ID="txtD4" runat="server"></asp:TextBox>
        </div>
    </div>
    <div>
        <asp:Button ID="btnAdd" runat="server" CssClass="margin-right" 
            Text="Додади" onclick="addClick" ValidationGroup="validation1" />
        <asp:Button ID="btnSave" runat="server" CssClass="margin-right" 
            Text="Зачувај" Enabled="False" onclick="saveClick" 
            ValidationGroup="validation1" />
        <asp:Button ID="btnCancel" runat="server" CssClass="margin-right" Text="Откажи" 
            Enabled="False" onclick="cancelClick" />
        <asp:Button ID="btnDelete" runat="server" CssClass="margin-right" 
            Text="Избриши" Enabled="False" onclick="deleteClick" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" 
            ControlToValidate="txtFinal" 
            ErrorMessage="Финалниод одговор е задолжителен" ForeColor="Red" 
            ValidationGroup="validation1"></asp:RequiredFieldValidator>
    </div>
</div>
</asp:Content>


