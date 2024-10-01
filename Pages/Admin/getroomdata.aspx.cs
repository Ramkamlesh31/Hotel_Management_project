using BLL;
using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Variable;

namespace HotelManagement.Pages.Admin
{
    public partial class getroomdata : System.Web.UI.Page
    {
        registervariable va = new registervariable();
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

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(GridView1.SelectedValue);
            int useri = Convert.ToInt32(Request.Cookies["loginid"].Value);
            int email1 = bookingstatus.ApproveBooking(useri, id);
            int userid1 = email1;
            HttpCookie eng1 = new HttpCookie("mailid1");
            eng1.Value = userid1.ToString();
            Response.Cookies.Add(eng1);
            string emi = mail();
            AdminHome.sendemail("your booking is approved", emi, "");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "usernotfound", "alert('Approved'); document.location.href='" + ResolveUrl("~/Pages/Admin/getroomdata.aspx") + "';", true);

        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            int useri = Convert.ToInt32(Request.Cookies["loginid"].Value);
            int email = bookingstatus.RejectBooking(useri, id);
            int userid = email;
            HttpCookie eng = new HttpCookie("mailid");
            eng.Value = userid.ToString();
            Response.Cookies.Add(eng);
            string emi = mail2();
            AdminHome.sendemail("your booking is rejected", emi, "Room Request");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "usernotfound", "alert('Rejected'); document.location.href='" + ResolveUrl("~/Pages/Admin/getroomdata.aspx") + "';", true);
        }

        public string mail()
        {
            int useri = Convert.ToInt32(Request.Cookies["mailid1"].Value);
            string mailid = "";
            SqlDataReader dt = AdminHome.getemail(useri);
            while (dt.Read())
            {
                mailid = dt["email"].ToString();
            }
            return mailid;

        }

        public string mail2()
        {
            int useri = Convert.ToInt32(Request.Cookies["mailid"].Value);
            string Mailid = "";
            SqlDataReader dt = AdminHome.getemail(useri);
            while (dt.Read())
            {
                Mailid = dt["email"].ToString();
                //HttpCookie mail = new HttpCookie("mail");
                //mail.Value = dt["email"].ToString();
                //Response.Cookies.Add(mail);
            }
            return Mailid;
        }
    }
}