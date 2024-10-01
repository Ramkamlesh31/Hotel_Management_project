using BLL;
using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using Variable;

namespace HotelManagement.Pages.Admin
{
    public partial class AddItems : System.Web.UI.Page
    {
        registervariable da = new registervariable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showdata();
            }
            Button3.Visible = false;
            Button1.Visible = false;
            Label5.Visible = false;
            CheckBox1.Visible = false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int data = adddocumnetdata();
            switch (data)
            {
                case 1:
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "usernotfound", "alert('Inserted successfully'); document.location.href='" + ResolveUrl("~/Pages/Admin/AddItems.aspx") + "';", true);
                    break;
                case 2:
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Documnet Type Already  exists')", true);
                    break;
            }
        }

        public int adddocumnetdata()
        {
            da.documnet_type = txtdoctype.Text;
            da.max_length = Convert.ToInt32(txtmaxlrngth.Text.Trim());
            da.min_length = Convert.ToInt32(txtminlength.Text.Trim());
            da.userid = Convert.ToInt32(Request.Cookies["loginid"].Value);
            int value = DocumnetLogic.documnetinsert(da);
            return value;
        }

        public void showdata()
        {
            SqlDataReader dt = DocumnetLogic.showdocdata();
            GridView1.DataSource = dt;
            if (dt.HasRows)
            {
                GridView1.DataBind();
            }
            else
            {
                Label6.Text = "No data is Available ";
            }

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Button2.Visible = false;
            Button3.Visible = true;
            Button1.Visible = true;
            Label5.Visible = true;
            CheckBox1.Visible = true;
            int id = Convert.ToInt32(GridView1.SelectedValue);
            SqlDataReader dt = DocumnetLogic.showdocdata();
            while (dt.Read())
            {
                txtdoctype.Text = dt["Type"].ToString();
                txtmaxlrngth.Text = dt["MaxLength"].ToString();
                txtminlength.Text = dt["MinLength"].ToString();
                int checkvalue = Convert.ToInt32(dt["Isactive"]);
                if (checkvalue == 1)
                {
                    CheckBox1.Checked = true;
                }
                else
                {
                    CheckBox1.Checked = false;
                }
            }
        }

        public int upadte()
        {
            da.documnet_type = txtdoctype.Text;
            da.max_length = Convert.ToInt32(txtmaxlrngth.Text);
            da.min_length = Convert.ToInt32(txtminlength.Text);
            if (CheckBox1.Checked)
            {
                da.isactive = 1;
            }
            else
            {
                da.isactive = 0;
            }
            da.userid = Convert.ToInt32(Request.Cookies["loginid"].Value);
            da.id = Convert.ToInt32(GridView1.SelectedValue);
            int store = DocumnetLogic.updata(da);
            return store;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int value = upadte();

            switch (value)
            {
                case 1:
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "usernotfound", "alert('Updated successfully'); document.location.href='" + ResolveUrl("~/Pages/Admin/AddItems.aspx") + "';", true);
                    break;
                case 2:
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Documnet Type Already  exists')", true);
                    break;
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            int userid = Convert.ToInt32(Request.Cookies["loginid"].Value);
            DocumnetLogic.deletedata(id, userid);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "usernotfound", "alert('Deleted successfully'); document.location.href='" + ResolveUrl("~/Pages/Admin/AddItems.aspx") + "';", true);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }
    }
}