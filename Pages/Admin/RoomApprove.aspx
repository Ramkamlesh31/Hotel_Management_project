<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="RoomApprove.aspx.cs" Inherits="HotelManagement.Pages.Admin.RoomApprove" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .dropdown {
            margin-top: 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main">
        <div class="dropdown">
            <label data-bs-toggle="dropdown" class="drp" runat="server">Room Approve <i class="fa-solid fa-caret-down"></i>&nbsp</label>
            <ul class="dropdown-menu" aria-labelledby="dropdownMenuLink">
                <li><a class="dropdown-item" href="<%=this.ResolveUrl("~/Pages/Admin/RoomApprove.aspx")%>">For Approve</a></li>
                <li><a class="dropdown-item" href="<%=this.ResolveUrl("~/Pages/Admin/RoomReject.aspx")%>">For Reject </a></li>
                <li><a class="dropdown-item" href="<%=this.ResolveUrl("~/Pages/Admin/Roomdata.aspx")%>">Room Data</a></li>
            </ul>
        </div>
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" DataKeyNames="id" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="1000px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="Approve" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" OnClientClick="javascript:return confirm('Do you really want to Approve?');'yes,no'" CommandName="Select" Text="Approve"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        <asp:Label ID="Label2" runat="server"></asp:Label>
    </div>
</asp:Content>
