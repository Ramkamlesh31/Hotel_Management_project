using BLL;
using System;
using System.Data.SqlClient;

namespace HotelManagement.Pages.Admin
{
    public partial class ApproveToAdminDeatils : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                data();
            }
        }

        public void data()
        {
            SqlDataReader dt = AdminLogic.Appadmin();
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}