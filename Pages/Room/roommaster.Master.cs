using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BLLI;
using System.Threading;

namespace HotelManagement.Pages.Room
{
    public partial class roommaster : System.Web.UI.MasterPage
    {
        public string userid;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if(!IsPostBack)
            {
                getdata();
                HttpCookie c = Request.Cookies["username"];
                if (c == null)
                {
                    Label1.Text = "";
                }
                else
                {
                    Label1.Text = c.Value;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            HttpCookie cm = Request.Cookies["loginid"];
            cm.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cm);
            HttpCookie cd = Request.Cookies["username"];
            cd.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cd);
            Response.Redirect("~/Pages/masterpage/login.aspx");
        }

        public  void getdata()
        {
            string gh = Request.Cookies["username"].Value;
            SqlDataReader dt = Roomlogic.getid(gh);
            while (dt.Read())
            {                
                userid = dt["userid"].ToString();
            }            
            HttpCookie c = new HttpCookie("userid");
            c.Value = userid;
            Response.Cookies.Add(c);         
        }
    }
}