<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddItems.aspx.cs" Inherits="HotelManagement.Pages.Admin.AddItems" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .last {
            margin-left: 140px;
            border: 1px solid black;
            padding: 20px;
            width:1300px;
        }
        label
        {
            color:white;
        }
    </style>
    <script>
        function AllowAlphabet(e) {
            isIE = document.all ? 1 : 0
            keyEntry = !isIE ? e.which : event.keyCode;
            if (((keyEntry >= '65') && (keyEntry <= '90')) || ((keyEntry >= '97') && (keyEntry <= '122')) || (keyEntry == '46') || (keyEntry == '32') || keyEntry == '45')
                return true;

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="last ">
       <div class="row">
           <div class="col-md-3">                      
                <label>Document Type :</label>
            <asp:TextBox ID="txtdoctype" runat="server" CssClass="form-control" onkeyup="value=value.replace(/[^\D]/g, '')" MaxLength="20"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtdoctype" ErrorMessage="Enter Documnet Type !!" ForeColor="Red" ValidationGroup="additeam"></asp:RequiredFieldValidator>
                </div>
        <div class="col-md-3">                       
            <label>Max Length :</label>
            <asp:TextBox ID="txtmaxlrngth" runat="server" MaxLength="2" CssClass="form-control" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')" ValidationGroup="add"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtmaxlrngth" ErrorMessage="Please Enter MaxLength !!" ForeColor="Red" ValidationGroup="additeam"></asp:RequiredFieldValidator>
        </div>
       </div>
         <div class="row">
           <div class="col-md-3">    
            <label>Min Length :</label>
            <asp:TextBox ID="txtminlength" runat="server" MaxLength="2" CssClass="form-control" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')" ValidationGroup="add"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtminlength" ErrorMessage="Please Enter MinLength !!" ForeColor="Red" ValidationGroup="additeam" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator5" runat="server" ControlToCompare="txtmaxlrngth" ControlToValidate="txtminlength" ErrorMessage="This should be less than maxlength !!" ForeColor="Red" Operator="LessThan" Type="Integer" ValidationGroup="additeam"></asp:CompareValidator>
        </div>
       </div>
        <p>
            <asp:Label ID="Label5" runat="server" Text="Isactive"></asp:Label>
            <asp:CheckBox ID="CheckBox1" runat="server" />
        </p>
        <p>
            <asp:Button ID="Button2" runat="server" class="roombtn" OnClick="Button2_Click" Text="Submit" ValidationGroup="additeam" />
            &nbsp;
        <asp:Button ID="Button3" runat="server" CssClass="roombtn" OnClick="Button3_Click" Text="Update" ValidationGroup="additeam" />
            &nbsp;
        <asp:Button ID="Button1" CssClass="roombtn" runat="server" Text="Cancel" OnClick="Button1_Click" />
        </p>
        <p>
            <asp:Label ID="Label6" runat="server"></asp:Label>
        </p>
        <p>
            <asp:GridView ID="GridView1" runat="server" DataKeyNames="id" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="1000px" OnRowDeleting="GridView1_RowDeleting" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="Select" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="Select"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#747393" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
        </p>
    </div>
</asp:Content>
