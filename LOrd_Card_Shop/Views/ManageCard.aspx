<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Navbar.Master" AutoEventWireup="true" CodeBehind="ManageCard.aspx.cs" Inherits="LOrd_Card_Shop.Views.ManageCard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <asp:GridView ID="CardsGV" runat="server" AutoGenerateColumns="False" OnRowEditing="CardsGV_RowEditing" OnRowDeleting="CardsGV_RowDeleting" DataKeyNames="CardID">
        <Columns>
            <asp:BoundField DataField="CardID" HeaderText="CardID" SortExpression="CardID" />
            <asp:BoundField DataField="CardName" HeaderText="CardName" SortExpression="CardName" />
            <asp:BoundField DataField="CardPrice" HeaderText="CardPrice" SortExpression="CardPrice" />
            <asp:BoundField DataField="CardDesc" HeaderText="CardDesc" SortExpression="CardDesc" />
            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <asp:Button ID="EditBtn" runat="server" Text="Edit" CommandName="Edit"/>
                    <asp:Button ID="DeleteBtn" runat="server" Text="Delete" CommandName="Delete"/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:Button ID="AddBtn" runat="server" Text="Add" OnClick="AddBtn_Click" style="height: 26px" />
</div>
</asp:Content>
