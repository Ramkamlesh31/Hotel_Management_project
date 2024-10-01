<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/masterpage/master.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="HotelManagement.Pages.masterpage.register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        p, label {
            color: white;
            font-size: 18px;
            /*font-weight : bold;*/
        }

        p {
            text-decoration: underline;
        }

        body {
            background-image: url("https://assets.hyatt.com/content/dam/hyatt/hyattdam/images/2022/04/12/1329/MUMGH-P0765-Inner-Courtyard-Hotel-Exterior-Evening.jpg/MUMGH-P0765-Inner-Courtyard-Hotel-Exterior-Evening.16x9.jpg")
        }

        a {
            color: aqua;
            font-size: 18px;
        }

        .register {
            width: 50%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="register">
        <div class="row">
            <div class="col-md-5">
                <label>FirstName :<strong class="text-danger">*</strong></label>
                <asp:TextBox ID="txtfname" runat="server" MaxLength="10" CssClass="form-control" onkeyup="value=value.replace(/[^\a-\z\A-\Z]/g,'')"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtfname" ErrorMessage="Please enter firstname !!" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-5">
                <label>Lastname :<strong class="text-danger">*</strong></label>
                <asp:TextBox ID="txtlname" runat="server" MaxLength="10" CssClass="form-control" onkeyup="value=value.replace(/[^\a-\z\A-\Z]/g,'')"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtlname" ErrorMessage="Please enter lastname !!" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row">
            <div class="col-md-5">
                <label>Mobile :<strong class="text-danger">*</strong></label>
                <asp:TextBox ID="txtmobile" runat="server" MaxLength="10" CssClass="form-control" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtmobile" Display="Dynamic" ErrorMessage="Enter mobile number" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtmobile" Display="Dynamic" ErrorMessage="Enter valid number !!" ForeColor="Red" ValidationExpression="^(\+91[\-\s]?)?[0]?(91)?[789]\d{9}$"></asp:RegularExpressionValidator>
            </div>
            <div class="col-md-5">
                <label>Email :<strong class="text-danger">*</strong></label>
                <asp:TextBox ID="txtmail" runat="server" CssClass="form-control" MaxLength="40"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtmail" Display="Dynamic" ErrorMessage="Please enter email !!" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtmail" Display="Dynamic" ErrorMessage="Enter valid email !!" ForeColor="Red" ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"></asp:RegularExpressionValidator>
            </div>
        </div>
        <div class="row">
            <div class="col-md-5">
                <label>Address :<strong class="text-danger">*</strong></label>
                <asp:TextBox ID="txtadd" runat="server" TextMode="MultiLine" CssClass="form-control" MaxLength="500"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please enter address !!" ForeColor="Red" ControlToValidate="txtadd"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-5">
                <label>Username :<strong class="text-danger">*</strong></label>
                <asp:TextBox ID="txtuname" runat="server" CssClass="form-control" MaxLength="15"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtuname" ErrorMessage="Please enter username !!" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row">
            <div class="col-md-5">
                <label>Password :<strong class="text-danger">*</strong></label>
                <asp:TextBox ID="txtpassword" runat="server" CssClass="form-control" TextMode="Password" MaxLength="10"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtpassword" ErrorMessage="Please enter password !!" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-5">
                <label>Confirm-Password :<strong class="text-danger">*</strong></label>
                <asp:TextBox ID="txtcpass" runat="server" TextMode="Password" CssClass="form-control" MaxLength="10"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtpassword" Display="Dynamic" ErrorMessage="Password are not same !!" ForeColor="Red" ControlToValidate="txtcpass"></asp:CompareValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtcpass" Display="Dynamic" ErrorMessage="Please re-enter  password !!" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row">
            <div class="col-md-5">
                <label>Document Type :<strong class="text-danger">*</strong><i class="fa-solid fa-caret-down"></i></label>
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" DataSourceID="SqlDataSource1" DataTextField="documnet_type" DataValueField="documnet_type">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HOTELDBConnectionString %>" SelectCommand="SELECT [documnet_type] FROM [DocumneType] WHERE ([deleteby] IS NULL)"></asp:SqlDataSource>
            </div>
            <div class="col-md-5">
                <label>Documnet No :<strong class="text-danger">*</strong></label>

                <asp:TextBox ID="txtdocno" runat="server" CssClass="form-control" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')" MaxLength="12" AutoPostBack="False"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtdocno" ErrorMessage="Please enter document no  !!" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-5">
                <label>Documnet Image :<strong class="text-danger">*</strong></label>
                <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="True" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="FileUpload1" ErrorMessage="Please Choose an Image !!" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-5">
                <label>Select for Admin_Request :</label>
                <asp:CheckBox ID="CheckBox1" runat="server" CssClass="form-control" ForeColor="White" Text="Admin" />
            </div>
        </div>
        <br />
        <p>If you already register then click <a href="login.aspx">Login</a></p>
        <div class="row">
            <div class="col-md-4">
            </div>
            <div class="col-md-3">
                <asp:Button ID="btnregister" runat="server" CssClass="roombtn" Text="Register " OnClick="btnregister_Click" />
            </div>
        </div>
    </div>
</asp:Content>
