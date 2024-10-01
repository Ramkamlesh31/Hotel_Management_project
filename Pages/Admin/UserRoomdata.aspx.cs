using BLL;
using System;
using System.Data.SqlClient;

namespace HotelManagement.Pages.Admin
{
    public partial class UserRoomdata : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                roomdata();
            }
        }
        public void roomdata()
        {
            SqlDataReader dr = userdata.getroomdata();
            grid.DataSource = dr;
            if (dr.HasRows)
            {
                grid.DataBind();
            }
            else
            {
                Label2.Text = "Data is Not Available ";
            }
        }
    }
}