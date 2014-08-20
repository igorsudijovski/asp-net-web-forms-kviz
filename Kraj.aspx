<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Kraj.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="navigationBar" ContentPlaceHolderID="mainLinks" Runat="Server">
    
    
        <div class="logedUser"> Вие сте најавен како <asp:Label ID="lblLogedUser" 
                runat="server" Text="Label" Font-Bold="True"></asp:Label></div>
        
</asp:Content>
<asp:Content ID="mainContent" ContentPlaceHolderID="mainContent" Runat="Server">
    <div style="margin-bottom: 15px; margin-left: 20px;">
        <asp:Label ID="error" runat="server" ForeColor="Red" Visible="False"></asp:Label>
    </div>
    <div class="main-content">
    
    <div>Поени:
        <asp:Label ID="lblPoints" runat="server" Text="Label"></asp:Label>
&nbsp;&nbsp; Време:
        <asp:Label ID="lblTime" runat="server" Text="Label"></asp:Label>
        </div>
        <div>
            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                Text="Почетна" />
        </div>
</div>
</asp:Content>

