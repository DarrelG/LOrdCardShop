<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Navbar.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="LOrd_Card_Shop.Views.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .cart-container {
            max-width: 800px;
            margin: 30px auto;
            padding: 20px;
        }
        
        .cart-item {
            border: 1px solid #e0e0e0;
            border-radius: 8px;
            padding: 15px;
            margin-bottom: 15px;
            background: white;
        }
        
        .checkout-btn {
            background: #27ae60;
            color: white;
            padding: 10px 25px;
            border: none;
            border-radius: 6px;
            cursor: pointer;
            float: right;
        }
    </style>

    <div class="cart-container">
        <h2>Your Cart</h2>
        
        <asp:Repeater ID="rptCartItems" runat="server">
            <ItemTemplate>
                <div class="cart-item">
                    <h3><%# Eval("CardName") %></h3>
                    <p>Price: <%# Eval("CardPrice", "{0:C}") %></p>
                    <p>Quantity: <%# Eval("Quantity") %></p>
                    <p><%# Eval("CardDesc") %></p>
                </div>
            </ItemTemplate>
        </asp:Repeater>

        <asp:Button ID="btnCheckout" runat="server" Text="Proceed to Checkout" 
            CssClass="checkout-btn" OnClick="btnCheckout_Click" />
    </div>
</asp:Content>
