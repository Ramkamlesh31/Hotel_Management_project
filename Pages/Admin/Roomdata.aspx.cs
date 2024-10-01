using BLL;
using System;
using System.Data.SqlClient;

namespace HotelManagement.Pages.Admin
{
    public partial class Roomdata : System.Web.UI.Page
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
            GridView1.DataSource = dr;
            if (dr.HasRows)
            {
                GridView1.DataBind();
            }
            else
            {
                Label2.Text = "NO Room Data is Available ";
            }

        }
    }
}