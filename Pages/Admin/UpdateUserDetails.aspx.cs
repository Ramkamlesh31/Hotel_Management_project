using BLL;
using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Variable;

namespace HotelManagement.Pages.Admin
{
    public partial class UpdateUserDetails : System.Web.UI.Page
    {
        registervariable va = new registervariable();
        public int userid;
        protected void Page_Load(object sender, EventArgs e)
        {

            int userid = Convert.ToInt32(Request.Cookies["id"].Value);
            if (!IsPostBack)
            {
                updatedata();
            }

        }       
        public void updatedata()
        {
            int userid = Convert.ToInt32(Request.Cookies["id"].Value);
            //Response.Write(userid);
            SqlDataReader dt = AdminLogic.Updaterecord(userid);
            while (dt.Read())
            {
                txtfname.Text = dt["firstname"].ToString();
                txtlname.Text = dt["lastname"].ToString();
                txtmobile.Text = dt["mobile"].ToString();
                txtemail.Text = dt["email"].ToString();
                txtaddress.Text = dt["address"].ToString();
                txtdoctype.Text = dt["documenttype"].ToString();
                txtdocno.Text = dt["DOCUMENTNO"].ToString();
                Session["image"] = dt["DOCIMAGE"].ToString();
                Image1.ImageUrl = "https://localhost:44395/Images/" + Session["image"].ToString();
                //if (FileUpload1.HasFile)
                //{
                //    string filePath = FileUpload1.PostedFile.FileName;
                //    TextBox1.Text = filePath;
                //}               
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

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            int value = vtnupdate();
            switch (value)
            {
                case 1:
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "usernotfound", "alert('Updated Succesfully'); document.location.href='" + ResolveUrl("~/Pages/Admin/userdetails.aspx") + "';", true);
                    break;
                case 2:
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Email already exists')", true);
                    break;
                case 3:
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Contact already exists')", true);
                    break;
                case 4:
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Documnet Type already exists')", true);
                    break;
            }

        }
        public int vtnupdate()
        {
            int userid = Convert.ToInt32(Request.Cookies["id"].Value);
            int backodd = Convert.ToInt32(Request.Cookies["loginid"].Value);
            //Response.Write(userid);
            va.backoff = backodd;
            va.userid = userid;
            va.firstname = txtfname.Text;
            va.lastname = txtlname.Text;
            va.mobile = txtmobile.Text;
            va.Email = txtemail.Text;
            va.address = txtaddress.Text;
            va.documnet_type = txtdoctype.Text;
            va.document_no = txtdocno.Text;
            va.document_img = Imageupload();            
            if (va.document_img == "")
            {
                va.document_img = Session["image"].ToString();
            }
            
            if (CheckBox1.Checked)
            {
                va.id = 1;
            }
            else
            {
                va.id = 0;
            }
            int alue = AdminLogic.Update(va);
            return alue;
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Admin/userdetails.aspx");
        }
    }
}