using BLL;
using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using Variable;

namespace HotelManagement.Pages.Admin
{
    public partial class RoomType : System.Web.UI.Page
    {
        registervariable da = new registervariable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showdata();
            }
        }

        public int operationofuser()
        {
            da.id = 1;
            da.type = TextBox1.Text;
            da.status = "insert";
            da.userid = Convert.ToInt32(Request.Cookies["loginid"].Value);
            da.isactive = 1;

            int value = RoomTypeLogic.operationofroomtype(da);
            return value;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Button2.Text == "Add")
            {
                int value = operationofuser();
                switch (value)
                {
                    case 1:
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "usernotfound", "alert('inserted Succesfully'); document.location.href='" + ResolveUrl("~/Pages/Admin/RoomType.aspx") + "';", true);

                        break;
                    case 2:
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Roomtype already Exists')", true);
                        break;
                    default:
                        break;
                }

            }
            else if (Button2.Text == "Update")
            {
                int update = updateoperation();
                switch (update)
                {
                    case 3:
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "usernotfound", "alert('updated Succesfully'); document.location.href='" + ResolveUrl("~/Pages/Admin/RoomType.aspx") + "';", true);
                        break;
                    case 4:
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Roomtype already exists')", true);
                        break;
                }
            }
        }

        public void showdata()
        {
            Label3.Visible = false;
            CheckBox1.Visible = false;
            Button3.Visible = false;
            SqlDataReader dt = RoomTypeLogic.showroomtype();
            GridView1.DataSource = dt;
            if (dt.HasRows)
            {
                GridView1.DataBind();
            }
            else
            {
                Label4.Text = "Data is not Available ";
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label3.Visible = true;
            CheckBox1.Visible = true;
            Button3.Visible = true;
            Button2.Text = "Update";
            int id = Convert.ToInt32(GridView1.SelectedValue);
            SqlDataReader dt = RoomTypeLogic.Fillroomtypedata(id);
            while (dt.Read())
            {
                TextBox1.Text = dt["roomtype"].ToString();
                int checkvalue = Convert.ToInt32(dt["isactive"]);
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
        public int updateoperation()
        {
            da.id = Convert.ToInt32(GridView1.SelectedValue);
            da.type = TextBox1.Text;
            da.status = "update";
            da.userid = Convert.ToInt32(Request.Cookies["loginid"].Value);
            if (CheckBox1.Checked)
            {
                da.isactive = 1;
            }
            else
            {
                da.isactive = 0;
            }
            int update = RoomTypeLogic.operationofroomtype(da);
            return update;

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            da.id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            da.type = TextBox1.Text;
            da.status = "delete";
            da.userid = Convert.ToInt32(Request.Cookies["loginid"].Value);
            da.isactive = 1;
            RoomTypeLogic.operationofroomtype(da);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "usernotfound", "alert('Deleted Succesfully'); document.location.href='" + ResolveUrl("~/Pages/Admin/RoomType.aspx") + "';", true);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }
    }
}