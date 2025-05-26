<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Navbar.Master" AutoEventWireup="true" CodeBehind="EditCard.aspx.cs" Inherits="LOrd_Card_Shop.Views.EditCard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <asp:Label ID="IdLbl" runat="server" Text="Id :"></asp:Label></br>
    <asp:TextBox ID="IdTb" runat="server"></asp:TextBox></br>

    <asp:Label ID="NameLbl" runat="server" Text="Name :"></asp:Label></br>
    <asp:TextBox ID="NameTb" runat="server"></asp:TextBox></br>

    <asp:Label ID="PriceLbl" runat="server" Text="Price :"></asp:Label></br>
    <asp:TextBox ID="PriceTb" runat="server"></asp:TextBox></br>

    <asp:Label ID="DescLbl" runat="server" Text="Description :"></asp:Label></br>
    <asp:TextBox ID="DescTb" runat="server"></asp:TextBox></br>

    <asp:Label ID="TypeLbl" runat="server" Text="Type :"></asp:Label></br>
    <asp:TextBox ID="TypeTb" runat="server"></asp:TextBox></br>

    <asp:Label ID="FoilLbl" runat="server" Text="isFoil ?"></asp:Label></br>
    <asp:DropDownList ID="FoilDd" runat="server">
        <asp:ListItem Text="Yes" Value="yes" />
        <asp:ListItem Text="No" Value="no" />
    </asp:DropDownList></br>

    <asp:Label ID="Message" runat="server" Text="" ForeColor="Red"></asp:Label></br>
    <asp:Button ID="UpdateBtn" runat="server" Text="Update" OnClick="UpdateBtn_Click" />

</div>
</asp:Content>
