using BLLI;
using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace HotelManagement.Pages.Room
{
    public partial class getdata : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                metadata();
            }
        }
        public void metadata()
        {
            SqlDataReader la = Roomlogic.getdata();
            ListView1.DataSource = la;
            ListView1.DataBind();
        }
        protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            HiddenField hide = new HiddenField();
            hide = (HiddenField)e.Item.FindControl("HiddenField1");
            //Response.Write(hide.Value);
            //Response.Redirect("~/Pages/Room/BookingPage.aspx?roomid=" + hide.Value);
            Response.Redirect("~/Pages/Room/RoomBookingPage.aspx?room_no=" + hide.Value);
        }
    }
}