<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Navbar.Master" AutoEventWireup="true" CodeBehind="CheckOut.aspx.cs" Inherits="LOrd_Card_Shop.Views.CheckOut" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .checkout-container {
            max-width: 800px;
            margin: 30px auto;
            padding: 20px;
        }
        
        .checkout-item {
            border-bottom: 1px solid #e0e0e0;
            padding: 15px 0;
        }
        
        .total-price {
            font-size: 1.5em;
            color: #27ae60;
            margin-top: 20px;
        }
        
        .confirm-btn {
            background: #27ae60;
            color: white;
            padding: 10px 25px;
            border: none;
            border-radius: 6px;
            cursor: pointer;
        }
    </style>

    <div class="checkout-container">
        <h2>Checkout Summary</h2>
        
        <asp:Repeater ID="rptCheckoutItems" runat="server">
            <ItemTemplate>
                <div class="checkout-item">
                    <h3><%# Eval("CardName") %></h3>
                    <p>Price: <%# Eval("CardPrice", "{0:C}") %></p>
                    <p>Quantity: <%# Eval("Quantity") %></p>
                </div>
            </ItemTemplate>
        </asp:Repeater>

        <div class="total-price">
            Total: <asp:Label ID="lblTotal" runat="server" Text="0" />
        </div>

        <asp:Button ID="btnConfirm" runat="server" Text="Confirm Payment" 
            CssClass="confirm-btn" OnClick="btnConfirm_Click" />
    </div>
</asp:Content>
