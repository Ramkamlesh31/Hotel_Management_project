using BLLI;
using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Variable;

namespace HotelManagement.Pages.Admin
{
    public partial class AddRoom : System.Web.UI.Page
    {
        public string filePath { get; set; }
        registervariable va = new registervariable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                showdata();
            }
            Label7.Visible = false;
            CheckBox1.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (va.image != null || Session["imgroom"] != null || FileUpload1.HasFile)
            {
                int value = insert();
                switch (value)
                {
                    case 1:
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ADD ROOM", "alert('inserted successfully'); document.location.href='" + ResolveUrl("~/Pages/Admin/AddRoom.aspx") + "';", true);
                        break;
                    case 2:
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Already booked Room no')", true);
                        break;
                }

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Choose Image !!')", true);
            }

        }


        public string Imageupload()
        {
            string path;
            if (FileUpload1.HasFile)
            {
                FileUpload1.SaveAs(HttpContext.Current.Request.PhysicalApplicationPath + "Images/" + FileUpload1.FileName);

            }
            path = FileUpload1.FileName;
            return path;
        }

        public int insert()
        {
            va.room_type = DropDownList1.SelectedValue;
            va.room_no = Convert.ToInt32(txtroomno.Text);
            va.image = Imageupload();
            if (va.image == "")
            {
                va.image = Session["imgroom"].ToString();
            }
            va.bookingcharge = Convert.ToDouble(TextBox1.Text);
            va.cancellation = Convert.ToDouble(TextBox2.Text);
            if (CheckBox1.Checked)
            {
                va.id = 1;
            }
            else
            {
                va.id = 0;
            }

            int result = Roomlogic.insertdata(va);
            return result;

        }
        public void showdata()
        {
            SqlDataReader dt = Roomlogic.show();
            GridView1.DataSource = dt;
            if (dt.HasRows)
            {
                GridView1.DataBind();
            }
            else
            {
                Label6.Text = "NO ADDED ROOM ";
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label7.Visible = true;
            CheckBox1.Visible = true;
            int id = Convert.ToInt32(GridView1.SelectedValue);
            SqlDataReader dt = Roomlogic.getAdddata(id);
            while (dt.Read())
            {
                DropDownList1.SelectedValue = dt["room_type"].ToString();
                txtroomno.Text = dt["room_no"].ToString();
                TextBox1.Text = dt["bookingcharge"].ToString();
                TextBox2.Text = dt["cancellation"].ToString();
                Session["img"] = dt["Image"].ToString();
                Image1.ImageUrl = "https://localhost:44395/Images/" + Session["img"].ToString();
                string checkvalue = dt["isactive"].ToString();
                if (checkvalue == "1")
                {
                    CheckBox1.Checked = true;

                }
                else
                {
                    CheckBox1.Checked = false;
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int data = updatedata();
            switch (data)
            {
                case 1:
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "usernotfound", "alert('Updated  Succesfully'); document.location.href='" + ResolveUrl("~/Pages/Admin/AddRoom.aspx") + "';", true);
                    break;
                case 2:
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Room No already exists')", true);
                    break;
            }
        }

        public int updatedata()
        {
            va.userid = Convert.ToInt32(Request.Cookies["loginid"].Value);
            va.roomid = Convert.ToInt32(GridView1.SelectedValue);
            va.room_type = DropDownList1.SelectedValue;
            va.room_no = Convert.ToInt32(txtroomno.Text);
            va.doublecharge = Convert.ToDouble(TextBox1.Text);
            va.cancellation = Convert.ToDouble(TextBox2.Text);
            va.image = Imageupload();
            if (va.image == "")
            {
                va.image = Session["img"].ToString();
            }
            if (CheckBox1.Checked)
            {
                va.id = 1;
            }
            else
            {
                va.id = 0;
            }
            int value = Roomlogic.updateroomadddata(va);
            return value;
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int roomid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            int userid = Convert.ToInt32(Request.Cookies["loginid"].Value);
            SqlDataReader dt = Roomlogic.getAdddata(roomid);
            while (dt.Read())
            {
                var roomno = dt["room_no"].ToString();
                Session["roomno"] = roomno.ToString();
            }
            var data = Session["roomno"].ToString();
            var num = Roomlogic.deletedata(userid, roomid, data);
            switch (num)
            {
                case 1:
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "usernotfound", "alert('Deleted  Succesfully'); document.location.href='" + ResolveUrl("~/Pages/Admin/AddRoom.aspx") + "';", true);
                    break;
                default:
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You can not delete this Room , because of is booked.')", true);
                    break;
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string filePath = FileUpload1.PostedFile.FileName;
                Session["imgroom"] = filePath.ToString();
                Image1.ImageUrl = "https://localhost:44395/Images/" + filePath.ToString();
            }
        }
    }
}
