<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Roomdata.aspx.cs" Inherits="HotelManagement.Pages.Admin.Roomdata" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css"  />
    <style>
        .drp{
            border:1px solid white;
            background-color:#747393;
            color:white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main">
        <asp:Label ID="Label2" runat="server"></asp:Label>
        <br />
        <div class="dropdown">
            <label  data-bs-toggle="dropdown" class="drp" runat="server" >Room Data <i class="fa-solid fa-caret-down"> </i>&nbsp</label>
            <ul class="dropdown-menu" aria-labelledby="dropdownMenuLink">
                <li><a class="dropdown-item" href="<%=this.ResolveUrl("~/Pages/Admin/RoomApprove.aspx")%>">For Approve</a></li>
                <li><a class="dropdown-item" href="<%=this.ResolveUrl("~/Pages/Admin/RoomReject.aspx")%>">For Reject </a></li>
                <li><a class="dropdown-item" href="<%=this.ResolveUrl("~/Pages/Admin/Roomdata.aspx")%>">Room Data</a></li>
            </ul>
        </div>

        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="1300px">
            <AlternatingRowStyle BackColor="White" />
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
    </div>

</asp:Content>
