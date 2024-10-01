using BLL;
using System;
using System.Data.SqlClient;
using Variable;

namespace HotelManagement.Pages.Room
{
    public partial class showdeatails : System.Web.UI.Page
    {
        registervariable va = new registervariable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                alldata();
            }                
        }        
        public void alldata()
        { 
            int value = Convert.ToInt32(Request.Cookies["loginid"].Value);
            SqlDataReader la = roomdata.getalldata(value);
            GridView1.DataSource = la;
            if (la.HasRows)
            {
                GridView1.DataBind();
            }
            else
            {
                Label3.Text = "No Booked Room !!!";
            }
        }
    }
}