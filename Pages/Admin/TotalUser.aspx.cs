using BLL;
using System;
using System.Data.SqlClient;

namespace HotelManagement.Pages.Admin
{
    public partial class TotalUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                user();
            }
        }
        public void user()
        {
            SqlDataReader lt = userdata.getuserdata();
            GridView1.DataSource = lt;
            if (lt.HasRows)
            {
                GridView1.DataBind();
            }
            else
            {
                Label2.Text = " NO Data Is Available ";
            }
        }
    }
}