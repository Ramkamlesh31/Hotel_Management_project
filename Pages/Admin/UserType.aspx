<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="UserType.aspx.cs" Inherits="HotelManagement.Pages.Admin.UserType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        p , label{
            color: white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="roombooking3 ">

        <p>
            <label>Usertype :<strong class="text-danger">*</strong></label>
            <asp:TextBox ID="txtuser" runat="server" MaxLength="15" CssClass="form-control" Width="440px" onkeyup="value=value.replace(/[^\D]/g, '')"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtuser" ErrorMessage="Please Enter type !!" ForeColor="Red" ValidationGroup="diff"></asp:RequiredFieldValidator>
        </p>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Isactive :"></asp:Label>
            <asp:CheckBox ID="CheckBox1" CssClass="form-control" Width="440px" runat="server" />
        </p>
        <p>
            <asp:Button ID="Button2" class="roombtn" runat="server" OnClick="Button2_Click" Text="Add" ValidationGroup="diff" />
            <asp:Button ID="Button3" class="roombtn" runat="server" OnClick="Button3_Click" Text="Cancel" />
        </p>
        <p>
            <asp:Label ID="Label3" CssClass="msg2" runat="server"></asp:Label>
            <asp:GridView ID="GridView1" DataKeyNames="id" runat="server" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" Width="500px">
                <AlternatingRowStyle BackColor="#DCDCDC" />
                <Columns>
                    <asp:TemplateField ShowHeader="False" HeaderText="Select">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-success p-0" CausesValidation="False" CommandName="Select" Text="Select"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False" HeaderText="Delete">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn btn-danger p-0" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                <HeaderStyle BackColor="#747393" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#0000A9" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#000065" />
            </asp:GridView>
        </p>
    </div>
</asp:Content>
