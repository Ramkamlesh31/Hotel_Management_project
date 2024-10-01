<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddRoom.aspx.cs" Inherits="HotelManagement.Pages.Admin.AddRoom" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://code.jquery.com/jquery-3.6.4.js"></script>
    <script>
        $(document).ready(function () {
            $("#ContentPlaceHolder1_FileUpload1").click(function () {
                $("#ContentPlaceHolder1_Image1").attr('src')
            })
        });
    </script>
    <style>
        .float {
            display: flex;
        }

        #ContentPlaceHolder1_lblroomtype, #ContentPlaceHolder1_Label2, #ContentPlaceHolder1_Label3, #ContentPlaceHolder1_Label4, #ContentPlaceHolder1_Label5, #ContentPlaceHolder1_Label7 {
            color: white;
            font-size: 18px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="float">
        <div class="roombooking">
            <div class="first">
                <asp:Label ID="lblroomtype" runat="server" Text="Room type :"></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="roomtype" DataValueField="roomtype">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HOTELDBConnectionString %>" SelectCommand="SELECT [roomtype] FROM [RoomtypeTable] WHERE ([deleteby] IS NULL)"></asp:SqlDataSource>
                <br />
                <asp:Label ID="Label2" runat="server" Text="Room No :"></asp:Label>
                <asp:TextBox ID="txtroomno" placeholder="Enter room no:" runat="server" MaxLength="3" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtroomno" ErrorMessage="Please enter Room no !!" ForeColor="Red" ValidationGroup="checkvalid" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtroomno" Display="Dynamic" ErrorMessage="Plaese Enter valid input !!" ForeColor="Red" ValidationExpression="^\d+" ValidationGroup="checkvalid"></asp:RegularExpressionValidator>
                <br />
            </div>
            <asp:Image ID="Image1" CssClass="image" runat="server" Height="113px" Width="266px" />
            <div class="first">
                <asp:Label ID="Label3" runat="server" Text="Choose Image :"></asp:Label>
                <asp:FileUpload ID="FileUpload1" placeholder="select image" runat="server" CssClass="accordion-header" />
                <asp:Button ID="Button3" runat="server" Text="Preview Image"  OnClick="Button3_Click"/>
               <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="FileUpload1" ErrorMessage="Please Choose Image !!" ForeColor="Red" ValidationGroup="checkvalid" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="FileUpload1" ErrorMessage="please choose correct type !!" ForeColor="Red" ValidationExpression="(?:([^:/?#]+):)?(?://([^/?#]*))?([^?#]*\.(?:jpg|gif|png))(?:\?([^#]*))?(?:#(.*))?" ValidationGroup="checkvalid"></asp:RegularExpressionValidator>
                <br />
            </div>
            <div class="first">
                <asp:Label ID="Label4" runat="server" Text="Enter Amount :"></asp:Label>
                <asp:TextBox ID="TextBox1" placeholder="enter money" runat="server" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')" ValidationGroup="default"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox1" ErrorMessage="Please Enter amount !!" ForeColor="Red" ValidationGroup="checkvalid" Display="Dynamic"></asp:RequiredFieldValidator>
                <br />
            </div>
            <div class="first">
                <asp:Label ID="Label5" runat="server" Text="Cancellation Charge :"></asp:Label>
                <asp:TextBox ID="TextBox2" runat="server" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox2" ErrorMessage="Please Enter Cancellation Charge  !!" ForeColor="Red" ValidationGroup="checkvalid" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBox1" ControlToValidate="TextBox2" Display="Dynamic" ErrorMessage="This should be less than bookin charge !!" ForeColor="Red" Operator="LessThan" Type="Integer" ValidationGroup="checkvalid"></asp:CompareValidator>
                <br />
                <br />
                <asp:Label ID="Label7" runat="server" Text="Isactive"></asp:Label>
                &nbsp;<asp:CheckBox ID="CheckBox1" runat="server" />
            </div>
            <div class="first">
                <asp:Button ID="Button1" runat="server" class="roombtn" Text="Add Room" OnClick="Button1_Click" ValidationGroup="checkvalid" />
                &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" class="roombtn" OnClick="Button2_Click" Text="Update Room" ValidationGroup="check" />
                <br />
            </div>
        </div>
        <div class="roombooking1">
            <asp:Label ID="Label6" CssClass="msg" runat="server"></asp:Label>
            <asp:GridView ID="GridView1" runat="server" DataKeyNames="roomid" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="700px" OnRowDeleting="GridView1_RowDeleting" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-success p-0" CausesValidation="False" CommandName="Select" Text="Select"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn btn-danger p-0" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
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
        </div>
    </div>
</asp:Content>
