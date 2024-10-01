using BAL;
using System;
using System.Web;
using Variable;
using System.Web.UI;

namespace HotelManagement.Pages.masterpage
{
    public partial class register : System.Web.UI.Page
    {
        public int value = 0;
        registervariable va = new registervariable();
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        public int num = 0;
        protected void btnregister_Click(object sender, EventArgs e)
        {
            value = registervalue();
            checkdata();
            switch (value)
            {
                case 1:
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "usernotfound", "alert('Register  Succesfully'); document.location.href='" + ResolveUrl("~/Pages/masterpage/login.aspx") + "';", true);
                    break;
                case 2:
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('contact already exists')", true);
                    break;
                case 3:
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Email already exists')", true);
                    break;
                case 4:
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Username already exists')", true);
                    break;
                case 5:
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('DocumnetNumber already exists')", true);
                    break;
                case 8:
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter valid Documnet No')", true);
                    break;
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

        public int registervalue()
        {
            va.firstname = txtfname.Text;
            va.lastname = txtlname.Text;
            va.mobile = txtmobile.Text;
            va.Email = txtmail.Text;
            va.address = txtadd.Text;
            va.username = txtuname.Text;
            va.password = txtpassword.Text;
            va.documnet_type = DropDownList1.SelectedValue;
            va.document_no = txtdocno.Text;
            va.document_img = Imageupload();

            if (CheckBox1.Checked)
            {
                va.admin_req = 1;
            }
            checkdata();
            int registerationvalue = registerlogic.userregister(va);
            return registerationvalue;
        }
        public void checkdata()
        {
            if (DropDownList1.SelectedValue == "Aadhar card" && Convert.ToInt64(txtdocno.Text.Length) == 12)
            {
                txtdocno.MaxLength = 12;
                num = 1;
            }
            else if (DropDownList1.SelectedValue == "Pan card" && Convert.ToInt64(txtdocno.Text.Length) == 10)
            {
                txtdocno.MaxLength = 10;
                num = 2;
            }
            switch (num)
            {
                case 1:
                    break;
                case 2:
                    break;
                default:
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter valid Documnet No')", true);
                    value = 8;
                    break;
            }
        }
    }
}
