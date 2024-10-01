<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoomBookingPage.aspx.cs" Inherits="HotelManagement.Pages.Room.RoomBookingPage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        * {
            box-sizing: border-box;
            margin: 0px;
            padding: 0px;
        }

        body {
            background-image: url("https://assets.hyatt.com/content/dam/hyatt/hyattdam/images/2022/04/12/1329/MUMGH-P0765-Inner-Courtyard-Hotel-Exterior-Evening.jpg/MUMGH-P0765-Inner-Courtyard-Hotel-Exterior-Evening.16x9.jpg")
        }

        .navbar {
            background-color: #D1B0C5 !important;
        }

        .top {
            margin-left: 50px;
            margin-right: 50px;
        }

        .roombooking {
            max-width: 100%;
            margin-top: 0px;
            margin-left: 260px;
            margin-right: 1170px;
            border: 1px solid black;
            padding: 20px;
        }

        /*.first {
            padding: 10px;
        }*/

        .roombtn {
            padding: 3px 10px;
            background: #89CFF0;
            border-radius: 12px;
        }

        .card {
            width: 180px;
        }

        .gridview {
            margin-left: 70px;
        }

        label, span {
            color: white;
            font-size: 18px;
        }

        #lblcharge {
            color: aqua;
            font-size: 22px;
            text-decoration: underline;
        }
    </style>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js"></script>
    <link href="https://code.jquery.com/ui/1.10.4/themes/ui-lightness/jquery-ui.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-1.12.4.min.js"></script>
    <script src="https://code.jquery.com/ui/1.10.4/jquery-ui.js"></script>
</head>
<body>
    <script>
        var arrayOf = "<%=getValue%>";
        var bolta = arrayOf.split(" ");

        $(function () {
            $("#textfrom").datepicker({
                dateFormat: 'dd-mm-yy',
                minDate: 0,
                beforeShowDay: function (date) {
                    var String = jQuery.datepicker.formatDate("m/dd/yy", date);
                    return [bolta.indexOf(String) == -1];
                }
            });

            $("#textto").datepicker({
                dateFormat: 'dd-mm-yy',
                minDate: 0,
                beforeShowDay: function (date) {
                    var String = jQuery.datepicker.formatDate("m/dd/yy", date);
                    return [bolta.indexOf(String) == -1];
                }
            });

        });
    </script>
    <form id="form1" runat="server">
        <div class="conatiner-fluid top">
            <nav class="navbar navbar-expand-lg navbar-light ">
                <div class="container-fluid">
                    <a class="navbar-brand text-primary" href="#">HotelManagement</a>
                    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                    </button>
                    <div class="collapse navbar-collapse" id="navbarSupportedContent">
                        <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                            <li class="nav-item">
                                <a class="nav-link active" href="<%=this.ResolveUrl("~/Pages/Room/getdata.aspx")%>">Home</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link active" href="<%=this.ResolveUrl("~/Pages/Room/showdeatails.aspx")%>">Room history</a>
                            </li>
                        </ul>
                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                        &nbsp;&nbsp;
                        <asp:Button ID="Button1" class="btn btn-outline-success" runat="server" Text="LOG OUT" OnClick="Button1_Click" />
                    </div>
                </div>
            </nav>
        </div>
        <div class="roombooking">
            <label>Username</label>
            &nbsp;:
             <asp:Label ID="lblname" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Label ID="Label7" runat="server" Text="Room Type"></asp:Label>
            &nbsp;:
             <asp:Label ID="lblroom" runat="server"></asp:Label>
            <br />
            <div class="row">
                <div class="col-md-5">
                    <asp:Label ID="Label3" runat="server" Text="From"></asp:Label>
                    <asp:TextBox ID="textfrom" autocomplete="off" CssClass="form-control" Width="300px" runat="server" TextMode="SingleLine">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="textfrom" ErrorMessage="Please select Date !!" ForeColor="Red" ValidationGroup="query"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-md-5">
                    <asp:Label ID="Label4" runat="server" Text="To"></asp:Label>
                    <asp:TextBox ID="textto" runat="server" TextMode="SingleLine" CssClass="form-control" Width="300px" autocomplete="off" AutoPostBack="True" OnTextChanged="textto_TextChanged"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="textto" ErrorMessage="Please select Date !!" ForeColor="Red" ValidationGroup="query" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </div>
            <asp:Label ID="Label8" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <asp:Label ID="Label6" runat="server" Text="Booking Charge :"></asp:Label>
            <asp:Label ID="lblcharge" runat="server"></asp:Label>
            <br />
            <div class="row">
                <div class="col-md-5">
                    <asp:Label ID="Label5" runat="server" Text="Review :"></asp:Label>
                    <asp:TextBox ID="txtreview" CssClass="form-control" Width="300px" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtreview" ErrorMessage="Please write Review !!" ForeColor="Red" ValidationGroup="query"></asp:RequiredFieldValidator>
                </div>
            </div>
            <br />
            <asp:Button ID="Button2" class="roombtn" runat="server" Text="Submit" ValidationGroup="query" OnClick="Button2_Click" />
        </div>
    </form>
</body>
</html>
