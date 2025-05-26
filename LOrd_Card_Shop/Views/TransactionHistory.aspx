<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Navbar.Master" AutoEventWireup="true" CodeBehind="TransactionHistory.aspx.cs" Inherits="LOrd_Card_Shop.Views.TransactionHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
    #TransactionHistory {
        margin: 50px;
        display: flex;
        flex-wrap: wrap;
        gap: 20px;
        justify-content: start;
    }

    .custom-gridview {
        display: contents;
        border: none;
    }

    .custom-card-row {
        background-color: #EAEAEA;
        padding: 16px;
        border-radius: 15px;
        display: inline-flex;
        flex-direction: column;
        width: 250px;
        box-shadow: 0 2px 8px rgba(0,0,0,0.1);
        margin: 50px;
    }

    .custom-card-row td {
        border: none;
        padding: 8px 0;
        font-size: 16px;
        color: #333;
    }

    .custom-button {
        align-self: flex-end;
        margin-top: 10px;
        text-decoration: none !important;
    }
    </style>
<div id="TransactionHistory">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="custom-gridview" OnRowEditing="GridView1_RowEditing" DataKeyNames="TransactionID" ShowHeader="False">
        <RowStyle CssClass="custom-card-row" />

        <columns>
            <asp:BoundField DataField="TransactionDate" />
            <asp:BoundField DataField="Status" />
            <asp:CommandField EditText="Detail" ShowCancelButton="False" ShowEditButton="True" />
        </columns>
    </asp:GridView>
</div>
</asp:Content>
