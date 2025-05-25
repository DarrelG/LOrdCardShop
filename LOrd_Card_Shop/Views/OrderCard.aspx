<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Navbar.Master" AutoEventWireup="true" CodeBehind="OrderCard.aspx.cs" Inherits="LOrd_Card_Shop.Views.OrderCard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .card-container {
            display: grid;
            grid-template-columns: repeat(auto-fill, minmax(280px, 1fr));
            gap: 25px;
            padding: 30px;
        }

        .card-item {
            border: 1px solid #e0e0e0;
            border-radius: 12px;
            padding: 20px;
            transition: transform 0.3s;
            background: white;
            text-align: center;
        }

        .card-item:hover {
            transform: translateY(-5px);
            box-shadow: 0 4px 15px rgba(0,0,0,0.1);
        }

        .card-item h3 {
            color: #2c3e50;
            margin-bottom: 15px;
        }

        .card-price {
            color: #27ae60;
            font-size: 1.4em;
            margin: 15px 0;
        }

        .btn-group {
            display: flex;
            gap: 10px;
            justify-content: center;
        }

        .btn-add {
            background: #27ae60;
            color: white;
            border: none;
            padding: 8px 20px;
            border-radius: 6px;
            cursor: pointer;
        }

        .btn-detail {
            background: #3498db;
            color: white;
            padding: 8px 20px;
            border-radius: 6px;
            text-decoration: none;
        }
        .error-message {
            color: #e74c3c;
            font-size: 1.2em;
            text-align: center;
            margin: 20px;
        }
    </style>


    <div class="card-container">
        <asp:Repeater ID="rptCards" runat="server">
            <ItemTemplate>
                <div class="card-item">
                    <h3><%# Eval("CardName") %></h3>
                    <div class="card-price"><%# Eval("CardPrice", "{0:C}") %></div>
                    <div class="btn-group">
                        <asp:Button ID="AddButton" runat="server" Text="🛒 Add to Cart" CommandArgument='<%# Eval("CardID") %>' OnClick="AddButton_Click" CssClass="btn-add"/>
                            
                        <asp:HyperLink ID="DetailLink" runat="server" NavigateUrl='<%# "CardDetail.aspx?cardID=" + Eval("CardID") %>' Text="🔍 Details" CssClass="btn-detail"/>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <asp:Label ID="lblMessage" runat="server" Visible="false" CssClass="error-message" />
    </div>
</asp:Content>
