using BLL;
using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelManagement.Pages.Admin
{
    public partial class userdetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                user();
            }
        }
        public void user()
        {
            SqlDataReader lt = userdata.getuserdata();
            GridView1.DataSource = lt;
            if (lt.HasRows)
            {
                GridView1.DataBind();
            }
            else
            {
                Label2.Text = " NO Data Is Available ";
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int userid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            int backodd = Convert.ToInt32(Request.Cookies["loginid"].Value);
            bookingstatus.Softdelete(userid, backodd);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "usernotfound", "alert('Deleted succesfully'); document.location.href='" + ResolveUrl("~/Pages/Admin/userdetails.aspx") + "';", true);
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int userid = Convert.ToInt32(GridView1.SelectedValue);
            HttpCookie id = new HttpCookie("id");
            id.Value = userid.ToString();
            Response.Cookies.Add(id);
            Response.Redirect("~/Pages/Admin/UpdateUserDetails.aspx");

        }
    }
}