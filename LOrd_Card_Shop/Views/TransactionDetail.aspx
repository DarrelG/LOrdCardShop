<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Navbar.Master" AutoEventWireup="true" CodeBehind="TransactionDetail.aspx.cs" Inherits="LOrd_Card_Shop.Views.TransactionDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .custom-gridview td, .custom-gridview th {
            padding: 10px 15px !important;
            width: 100vw !important;
            text-align: center;
        }

        .custom-gridview a {
            text-decoration: none !important;
        }

        #Button1{
            width: 100vw;
            height: 50px;
            font-size: 20px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<style>
    #TransactionHistory {
        margin: 50px;
        display: flex;
        flex-wrap: wrap;
        gap: 20px;
        justify-content: center;
    }
</style>
    <div id="TransactionHistory">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="custom-gridview" ShowFooter="true" OnRowDataBound="GridView1_RowDataBound" DataFormatString="{0:C}">
            <Columns>
                <asp:BoundField DataField="CardName" HeaderText="Card Name"></asp:BoundField>
                <asp:BoundField DataField="CardPrice" HeaderText="Card Price"></asp:BoundField>
                <asp:BoundField DataField="CardDesc" HeaderText="Description"></asp:BoundField>
                <asp:BoundField DataField="CardType" HeaderText="Card Type"></asp:BoundField>
                <asp:BoundField DataField="Quantity" HeaderText="Quantity"></asp:BoundField>
                <asp:BoundField DataField="Total" HeaderText="Total"></asp:BoundField>
            </Columns>
        </asp:GridView>

        <asp:Button ID="Button1" runat="server" Text="Back" OnClick="Button1_Click" />
    </div>
</asp:Content>
