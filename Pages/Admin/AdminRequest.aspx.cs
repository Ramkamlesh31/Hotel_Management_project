using BLL;
using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;

namespace HotelManagement.Pages.Admin
{
    public partial class AdminRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                request();
            }

        }

        public void request()
        {
            SqlDataReader dt = AdminLogic.requestforadmin();
            GridView1.DataSource = dt;
            if (dt.HasRows)
            {
                GridView1.DataBind();
            }
            else
            {
                Label2.Text = "No Request Are Available ";
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {          
            int userid = Convert.ToInt32(GridView1.SelectedValue);
            //HttpCookie imp = new HttpCookie("imp");
            //imp.Value = userid.ToString();
            //Response.Cookies.Add(imp);
            mail(userid);
            AdminLogic.ApproveAdmin(userid);
            string emi = Request.Cookies["mail"].Value;
            AdminHome.sendemail("now you are admin", emi, "Admin Request");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "usernotfound", "alert('Approved to Admin.'); document.location.href='" + ResolveUrl("~/Pages/Admin/AdminRequest.aspx") + "';", true);
        }

        public void mail(int userid)
        {            
            SqlDataReader dt = AdminHome.getemail(userid);
            while (dt.Read())
            {
                HttpCookie mail = new HttpCookie("mail");
                mail.Value = dt["email"].ToString();
                Response.Cookies.Add(mail);
            }

        }
    }
}