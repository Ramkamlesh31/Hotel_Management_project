using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelManagement.Pages.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            HttpCookie cm = Request.Cookies["loginid"];
            cm.Expires= DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cm);
            Response.Redirect("~/Pages/masterpage/login.aspx");
        }
    }
}