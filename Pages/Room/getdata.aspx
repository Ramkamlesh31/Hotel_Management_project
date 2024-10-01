<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Room/roommaster.Master" AutoEventWireup="true" CodeBehind="getdata.aspx.cs" Inherits="HotelManagement.Pages.Room.getdata" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .cardstyle {
            max-width: 90%;
            margin: auto;
            display: grid;
            grid-template-columns: repeat(3, 1fr);
            box-sizing: content-box;
        }

        .para {
            margin: auto;
            margin-top: 20px;
            margin-bottom: 20px;
        }

        .roombtn {
            padding: 3px 10px;
            background: #89CFF0;
            border-radius: 12px;
        }
         body {
            background-image: url("https://assets.hyatt.com/content/dam/hyatt/hyattdam/images/2022/04/12/1329/MUMGH-P0765-Inner-Courtyard-Hotel-Exterior-Evening.jpg/MUMGH-P0765-Inner-Courtyard-Hotel-Exterior-Evening.16x9.jpg")
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="cardstyle">


        <asp:ListView ID="ListView1" runat="server" OnItemCommand="ListView1_ItemCommand">

            <ItemTemplate>

                <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("room_no")  %>' />
                <div class="para">

                    <div class="card" style="width: 18rem;">
                        <image src="https://localhost:44395/Images/<%# Eval("room_img") %>" class="card-img-top" alt="..."></image>

                        <div class="card-body">
                            Room Type :<h5 class="card-title"><%# Eval("room_type") %></h5>
                            Room no :<h5 class="card-title"><%# Eval("room_no") %></h5>
                            <%-- <h5 class="card-title"><%# Eval("bookingcharge") %></h5>--%>
                            <asp:Button ID="Button1" CssClass="roombtn" runat="server" Text="Book Now" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:ListView>

    </div>
</asp:Content>
