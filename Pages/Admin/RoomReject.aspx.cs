using BLL;
using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;


namespace HotelManagement.Pages.Admin
{
    public partial class RoomReject : System.Web.UI.Page
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
            SqlDataReader dr = userdata.getroomdata1();
            GridView1.DataSource = dr;
            if (dr.HasRows)
            {
                GridView1.DataBind();
            }
            else
            {
                Label2.Text = "No Room Data is Available ";
            }
        }
        public string mail2(int user)
        {

            //int useri = Convert.ToInt32(Request.Cookies["mailid"].Value);
            string Mailid = "";
            SqlDataReader dt = AdminHome.getemail(user);
            while (dt.Read())
            {
                Mailid = dt["email"].ToString();               
            }
            return Mailid;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            var id = Convert.ToInt32(GridView1.SelectedValue);
            int useri = Convert.ToInt32(Request.Cookies["loginid"].Value);
            int email = bookingstatus.RejectBooking(useri, id);
            //int userid = email;
            //HttpCookie eng = new HttpCookie("mailid");
            //eng.Value = userid.ToString();
            //Response.Cookies.Add(eng);

            string emi = mail2(email);
            AdminHome.sendemail("your booking is rejected", emi, "Room Request");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "usernotfound", "alert('Rejected'); document.location.href='" + ResolveUrl("~/Pages/Admin/Roomdata.aspx") + "';", true);
        }
    }
}