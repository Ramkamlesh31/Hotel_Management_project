using BLL;
using System;
using System.Data.SqlClient;

namespace HotelManagement.Pages.Admin
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dash();
            }
        }

        public void dash()
        {
            SqlDataReader dt = AdminHome.showmaindata();
            GridView1.DataSource = dt;
            if (dt.HasRows)
            {
                GridView1.DataBind();
            }
            else
            {
                Label2.Text = "NO Data Is Available ";
            }

        }

    }
}