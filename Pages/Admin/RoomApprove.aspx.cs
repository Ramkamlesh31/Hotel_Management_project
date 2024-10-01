using BLL;
using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;


namespace HotelManagement.Pages.Admin
{
    public partial class RoomApprove : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                roomdata();
            }
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            int id = Convert.ToInt32(GridView1.SelectedValue);
            int useri = Convert.ToInt32(Request.Cookies["loginid"].Value);
            int email1 = bookingstatus.ApproveBooking(useri, id);
            //int userid1 = email1;
            //HttpCookie eng1 = new HttpCookie("mailid1");
            //eng1.Value = userid1.ToString();
            //Response.Cookies.Add(eng1);
            string emi = mail(email1);
            AdminHome.sendemail("your booking is approved", emi, "");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "usernotfound", "alert('Approved'); document.location.href='" + ResolveUrl("~/Pages/Admin/Roomdata.aspx") + "';", true);

        }
        public string mail(int useri)
        {
            //int useri = Convert.ToInt32(Request.Cookies["mailid1"].Value);
            string mailid = "";
            SqlDataReader dt = AdminHome.getemail(useri);
            while (dt.Read())
            {
                mailid = dt["email"].ToString();
            }
            return mailid;

        }
        public void roomdata()
        {
            SqlDataReader dr = userdata.getroomdata2();
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