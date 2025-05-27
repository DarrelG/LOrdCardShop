<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Navbar.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="LOrd_Card_Shop.Views.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .username {
            margin: 50px 50px 30px;
            font-size: 32px;
            font-weight: 700;
            color: #2c3e50;
            border-left: 5px solid #e74c3c;
            padding-left: 20px;
        }
        .section {
            margin: 40px 50px;
            padding: 30px;
            background: #ffffff;
            border-radius: 15px;
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
            transition: transform 0.3s ease;
        }
        .section:hover {
            transform: translateY(-5px);
        }
        .quick-links {
            display: flex;
            gap: 30px;
            margin-top: 20px;
        }
        .quick-link-card {
            flex: 1;
            padding: 25px;
            background: #f8f9fa;
            border-radius: 12px;
            text-align: center;
            transition: all 0.3s ease;
            min-width: 200px;
        }
        .quick-link-card:hover {
            background: #e9ecef;
            box-shadow: 0 3px 10px rgba(0, 0, 0, 0.1);
        }
        .quick-link-card a {
            display: block;
            font-size: 18px;
            color: #2c3e50;
            font-weight: 500;
            text-decoration: none;
        }
        .quick-link-card i {
            font-size: 32px;
            margin-bottom: 15px;
            display: block;
            color: #e74c3c;
        }
        .quote {
            margin: 60px 50px;
            font-size: 20px;
            color: #7f8c8d;
            text-align: center;
            position: relative;
            font-style: italic;
        }
        p{
            text-decoration: none;
        }
    </style>
    <asp:Label ID="welcome" runat="server" Text=""></asp:Label>
    <div class="section">
        <h3 style="font-size: 24px; color: #2c3e50; margin-bottom: 25px;">Quick Access</h3>
        <div class="quick-links">
            <a href="OrderCard.aspx" class="quick-link-card">
                <div>
                    <i class="fas fa-shopping-cart"></i>
                    <p>Order Cards</p>
                </div>
            </a>
            <a href="Cart.aspx" class="quick-link-card">
                <div>
                    <i class="fas fa-cart-plus"></i>
                    <p>View Cart</p>
                </div>
            </a>
            <a href="ProfilePage.aspx" class="quick-link-card">
                <div>
                    <i class="fas fa-user-edit"></i>
                    <p>Update Profile</p>
                </div>
            </a>
        </div>
    </div>
                
    <div class="quote">
        "Collect, play, conquer.<br/>Every card tells a story."
    </div>
</asp:Content>
