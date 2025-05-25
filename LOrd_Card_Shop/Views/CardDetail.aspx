<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Navbar.Master" AutoEventWireup="true" CodeBehind="CardDetail.aspx.cs" Inherits="LOrd_Card_Shop.Views.CardDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .card-detail-container {
            max-width: 800px;
            margin: 40px auto;
            padding: 30px;
            background: #ffffff;
            border-radius: 12px;
            box-shadow: 0 4px 12px rgba(0,0,0,0.1);
        }

        .card-title {
            color: #2c3e50;
            font-size: 2.2em;
            margin-bottom: 15px;
        }

        .card-meta {
            display: flex;
            gap: 25px;
            margin-bottom: 25px;
        }

        .card-price {
            color: #27ae60;
            font-size: 1.8em;
            font-weight: 600;
        }

        .card-type {
            color: #7f8c8d;
            font-style: italic;
        }

        .card-description {
            line-height: 1.7;
            color: #555;
            font-size: 1.1em;
            margin-bottom: 30px;
        }

        .action-buttons {
            display: flex;
            gap: 15px;
            margin-top: 25px;
        }

        .btn-back {
            background: #95a5a6;
            color: white;
            padding: 10px 25px;
            border: none;
            border-radius: 6px;
            cursor: pointer;
        }

        .btn-add-to-cart {
            background: #27ae60;
            color: white;
            padding: 10px 25px;
            border: none;
            border-radius: 6px;
            cursor: pointer;
        }
    </style>

    <div class="card-detail-container">
        <h1 class="card-title"><asp:Label ID="lblName" runat="server" /></h1>
        
        <div class="card-meta">
            <span class="card-price"><asp:Label ID="lblPrice" runat="server" /></span>
            <span class="card-type"><asp:Label ID="lblType" runat="server" /></span>
        </div>

        <div class="card-description">
            <asp:Label ID="lblDescription" runat="server" />
        </div>

        <div class="action-buttons">
            <asp:Button ID="btnBack" runat="server" Text="⬅ Back to List" 
                CssClass="btn-back" OnClick="btnBack_Click" />
            <asp:Button ID="btnAddToCart" runat="server" Text="🛒 Add to Cart" 
                CssClass="btn-add-to-cart" OnClick="btnAddToCart_Click" />
        </div>
    </div>
</asp:Content>
