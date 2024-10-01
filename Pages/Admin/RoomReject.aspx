<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="RoomReject.aspx.cs" Inherits="HotelManagement.Pages.Admin.RoomReject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .dropdown {
            margin-top: 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main">
        <asp:Label ID="Label2" runat="server"></asp:Label>
        <div class="dropdown">
            <label data-bs-toggle="dropdown" class="drp" runat="server">Room Reject <i class="fa-solid fa-caret-down"></i>&nbsp</label>
            <ul class="dropdown-menu" aria-labelledby="dropdownMenuLink">
                <li><a class="dropdown-item" href="<%=this.ResolveUrl("~/Pages/Admin/RoomApprove.aspx")%>">For Approve</a></li>
                <li><a class="dropdown-item" href="<%=this.ResolveUrl("~/Pages/Admin/RoomReject.aspx")%>">For Reject </a></li>
                <li><a class="dropdown-item" href="<%=this.ResolveUrl("~/Pages/Admin/Roomdata.aspx")%>">Room Data</a></li>
            </ul>
        </div>
        <asp:GridView ID="GridView1" runat="server" DataKeyNames="id" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None" Width="1000px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField HeaderText="Reject" SelectText="Reject" ShowSelectButton="True" />
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
    </div>
</asp:Content>
