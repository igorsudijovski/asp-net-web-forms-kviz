<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Pocetna.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="navigationBar" ContentPlaceHolderID="mainLinks" Runat="Server">
    
    
    <asp:HyperLink ID="preferences" runat="server" CssClass="main-links" 
        NavigateUrl="~/Podesuvanja.aspx">Подесувања</asp:HyperLink>
        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="main-links text-bold" 
        NavigateUrl="~/Admin_Users.aspx">Почетна</asp:HyperLink>
        <div class="logedUser"> Вие сте најавен како <asp:Label ID="lblLogedUser" 
                runat="server" Text="Label" Font-Bold="True"></asp:Label></div>
    <asp:LinkButton ID="logOutButton" runat="server" 
        CssClass="main-links log-out-button" onclick="logOut_click">Одлогирај се</asp:LinkButton>
        
</asp:Content>
<asp:Content ID="mainContent" ContentPlaceHolderID="mainContent" Runat="Server">
    <div style="margin-bottom: 15px; margin-left: 20px;">
        <asp:Label ID="error" runat="server" ForeColor="Red" Visible="False"></asp:Label>
    </div>
    <div class="main-content">
    <div class="float-left margin-right">
    <div>Топ 10</div>
        <asp:GridView ID="gridTop10Score" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
            CellPadding="3" ForeColor="Black" 
            GridLines="Vertical">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:BoundField DataField="username" HeaderText="Корисничко име" />
                <asp:BoundField DataField="points" HeaderText="Поени" />
                <asp:BoundField DataField="time" HeaderText="Време во секунди" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="Gray" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
    </div>
    <div style="clear:both">

        <asp:Button ID="Button1" runat="server" Text="Започни игра" 
            onclick="start_game" />

    </div>
</div>
</asp:Content>

