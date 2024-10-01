<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="UpdateUserDetails.aspx.cs" Inherits="HotelManagement.Pages.Admin.UpdateUserDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .roombooking2 {
            border: 1px solid black;
            margin-left: 220px;
            padding: 20px;
            margin-right: 1000px;
            height: auto;
        }

        label {
            color: white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="roombooking2">
        <div class="row">
            <div class="col-md-5">
                <label>Firstname :</label>
                <asp:TextBox ID="txtfname" runat="server" CssClass="form-control" onkeyup="value=value.replace(/[^\a-\z\A-\Z]/g,'')"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtfname" ErrorMessage="Please Enter Name !! " ForeColor="Red" ValidationGroup="updatepage"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-5">
                <label>Lastname :</label>

                <asp:TextBox ID="txtlname" runat="server" CssClass="form-control" onkeyup="value=value.replace(/[^\a-\z\A-\Z]/g,'')"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtlname" ErrorMessage="Please Enter Last Name !!" ForeColor="Red" ValidationGroup="updatepage"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-5">
                <label>Mobile :</label>
                <asp:TextBox ID="txtmobile" runat="server" CssClass="form-control" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtmobile" Display="Dynamic" ErrorMessage="Please Enter Mobile No !!" ForeColor="Red" ValidationGroup="updatepage"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtmobile" Display="Dynamic" ErrorMessage="Please Enter Valid No !!" ForeColor="Red" ValidationExpression="^(?:(?:\+|0{0,2})91(\s*[\-]\s*)?|[0]?)?[789]\d{9}$" ValidationGroup="updatepage"></asp:RegularExpressionValidator>
            </div>
            <div class="col-md-5">
                <label>Email :</label>

                <asp:TextBox ID="txtemail" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtemail" Display="Dynamic" ErrorMessage="Please Enter Email !!" ForeColor="Red" ValidationGroup="updatepage"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic" ErrorMessage="Please Enter Valid Email !!" ForeColor="Red" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" ValidationGroup="updatepage" ControlToValidate="txtemail"></asp:RegularExpressionValidator>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-5">
                <label>Address :</label>
                <asp:TextBox ID="txtaddress" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtaddress" ErrorMessage="Please Enter Address !!" ForeColor="Red" ValidationGroup="updatepage"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-5">
                <label>Document Type :</label>

                <asp:TextBox ID="txtdoctype" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtdoctype" ErrorMessage="please Enter document Type !!" ForeColor="Red" ValidationGroup="updatepage"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-5">
                <label>Document No : </label>
                <asp:TextBox ID="txtdocno" CssClass="form-control" runat="server" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtdocno" ErrorMessage="Please Enter Document No !!" ForeColor="Red" ValidationGroup="updatepage"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-5">

                <asp:Image ID="Image1" runat="server" Width="200px" Height="100px" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-5">
                <label>Choose Image : </label>
                <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" visible="false"></asp:TextBox>
                <asp:FileUpload ID="FileUpload1" CssClass="form-control"  runat="server" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="FileUpload1" Display="Dynamic" ErrorMessage="Please choose valid image !!" ForeColor="Red" ValidationExpression="([^\s]+(\.(?i)(jpg|png|gif|bmp))$)" ValidationGroup="updatepage"></asp:RegularExpressionValidator>
            </div>
            <div class="col-md-5">
                <label>IsActive</label>
                <asp:CheckBox ID="CheckBox1" CssClass="form-control" runat="server" />
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-md-3"></div>
            <div class="col-md-2">
                <asp:Button ID="btnupdate" class="roombtn" runat="server" Text="Update" OnClick="btnupdate_Click" ValidationGroup="updatepage" />
            </div>
            <div class="col-md-2">
                <asp:Button ID="Button2" CssClass="roombtn" runat="server" OnClick="Button2_Click" Text="Back" />
            </div>
        </div>
    </div>
</asp:Content>
