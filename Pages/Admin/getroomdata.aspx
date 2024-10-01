<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="getroomdata.aspx.cs" Inherits="HotelManagement.Pages.Admin.getroomdata" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function disableDel(delButton) {
            delButton.disabled = true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="main">
        <asp:Label ID="Label2" CssClass="msg" runat="server"></asp:Label>
        <asp:GridView ID="GridView1" DataKeyNames="id" runat="server" CellPadding="4" ForeColor="#333333" Width="1000px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDeleting="GridView1_RowDeleting" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="Approve" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="Approve" OnClientClick="disableDel(this);"></asp:LinkButton>
                    </ItemTemplate>
                    <ControlStyle CssClass="btn btn-success p-0" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Reject" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton2" CssClass="delete" OnClientClick="javascript:return disablethis()" runat="server" CausesValidation="False" CommandName="Delete" Text="Reject"></asp:LinkButton>
                    </ItemTemplate>
                    <ControlStyle CssClass="btn btn-danger p-0" />
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
    </div>
</asp:Content>
