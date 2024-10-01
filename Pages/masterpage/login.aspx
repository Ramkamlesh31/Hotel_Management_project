<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/masterpage/master.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="HotelManagement.Pages.masterpage.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 400px;
            margin-left: 440px;
            margin-top: 150px;
            border: 1px solid black;
            padding: 20px;
            border-radius: 10px;
            background-image: inherit;
        }

        body {
            background-image: url("https://assets.hyatt.com/content/dam/hyatt/hyattdam/images/2022/04/12/1329/MUMGH-P0765-Inner-Courtyard-Hotel-Exterior-Evening.jpg/MUMGH-P0765-Inner-Courtyard-Hotel-Exterior-Evening.16x9.jpg")
        }

        label, span {
            color: white;
            font-size: 16px;
        }

        a {
            color: aqua;
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="auto-style1">
        <label>Username :<strong class="text-danger">*</strong></label>
        <asp:TextBox ID="txtuname" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtuname" ErrorMessage="Please Enter username  !!" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lbluerror" runat="server" ForeColor="Red" Text=""></asp:Label>
        <br />
        <label>Password :<strong class="text-danger">*</strong></label>
        <asp:TextBox ID="txtpass" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtpass" ErrorMessage="Please Enter Password !!" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lblperror" runat="server" ForeColor="Red" Text=""></asp:Label>
        <br />
        <asp:Button ID="btnlogin" CssClass="roombtn" runat="server" Text="Login" OnClick="btnlogin_Click" />
        <br />
        <br />
        <span runat="server">If you not register click <a href="register.aspx">Register</a></span>
    </div>
</asp:Content>
