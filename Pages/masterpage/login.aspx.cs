using BLL;
using BLLI;
using System;
using System.Data.SqlClient;
using System.Threading;
using System.Web;
using System.Web.UI;
using Variable;

namespace HotelManagement.Pages.masterpage
{

    public partial class login : System.Web.UI.Page
    {
        registervariable va = new registervariable();
        public int value;
        public int usertype;
        public string userid;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnlogin_Click(object sender, EventArgs e)
        {
            int value = logincheck();
            switch (value)
            {
                case 1:
                    HttpCookie cd = new HttpCookie("username");
                    cd.Value = txtuname.Text;
                    Response.Cookies.Add(cd);
                    adminid();
                    Thread.Sleep(100);
                    Response.Redirect("~/Pages/Admin/Dashboard.aspx", true);
                    break;
                case 2:
                    HttpCookie c = new HttpCookie("username");
                    c.Value = txtuname.Text;
                    Response.Cookies.Add(c);
                    adminid();
                    Thread.Sleep(100);
                    Response.Redirect("~/Pages/Room/getdata.aspx", true);
                    break;
                case 3:
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter valid Password')", true);
                    txtpass.Focus();
                    break;
                case 4:
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter valid Username ')", true);
                    txtuname.Focus();
                    break;
            }
        }
        public int logincheck()
        {
            va.username = txtuname.Text;
            va.password = txtpass.Text;
            int check = loginlogic.checkdata(va);
            return check;
        }

        public void adminid()
        {
            string name = txtuname.Text;
            SqlDataReader dt = Roomlogic.getid(name);
            while (dt.Read())
            {
                HttpCookie cm = new HttpCookie("loginid");
                cm.Value = dt["userid"].ToString();
                Response.Cookies.Add(cm);
            }
        }
    }
}