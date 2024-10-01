using BLL;
using BLLI;
using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using Variable;

namespace HotelManagement.Pages.Room
{
    public partial class RoomBookingPage : System.Web.UI.Page
    {
        registervariable va = new registervariable();
        string userid;
        public string getValue;
        protected void Page_Load(object sender, EventArgs e)
        {
            int RoomNo = Convert.ToInt32(Request.QueryString["room_no"]);
            getValue = Listtostring(RoomNo);

            HttpCookie c = Request.Cookies["username"];
            if (c == null)
            {
                Label1.Text = "";
            }
            else
            {
                Label1.Text = c.Value;
            }
            if (!IsPostBack)
            {
                getdata();
                filldata();
            }
        }
        private string Listtostring(int roomId)
        {
            string value = string.Join(" ", roomdata.CheckDateAlreadyExists(0, roomId));
            return value;
        }
        public void filldata()
        {
            string name = Request.QueryString["roomid"];
            string gh = Request.Cookies["username"].Value;
            lblname.Text = Request.Cookies["username"].Value;
            HttpCookie c = new HttpCookie("userid");
            c.Value = userid;
            Response.Cookies.Add(c);
            readprice();
        }

        private double readprice()
        {
            string name = Request.QueryString["room_no"];
            double price = 0;
            SqlDataReader dr = Roomlogic.getalldata(Convert.ToInt32(name));
            while (dr.Read())
            {
                lblroom.Text = dr["room_type"].ToString();
                price = Convert.ToDouble(dr["bookingcharge"].ToString());
            }
            return price;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Label8.Text.Length <= 0)
            {
                va.roomid = Convert.ToInt32(Request.QueryString["room_no"]);
                va.userid = Convert.ToInt32(Request.Cookies["loginid"].Value);
                va.room_type = lblroom.Text;
                if (ChangeDate(textfrom.Text) != "")
                {
                    var date4 = DateTime.ParseExact(textfrom.Text, "mm-dd-yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    va.fromdate = date4;
                }
                if (ChangeDate(textto.Text) != "")
                {
                    var date5 = DateTime.ParseExact(textfrom.Text, "mm-dd-yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    va.todate = date5;
                }

                va.charge = float.Parse(lblcharge.Text);
                va.review = txtreview.Text;
                roomdata.insertdata(va);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "usernotfound", "alert('Inserted succesfully'); document.location.href='" + ResolveUrl("~/Pages/Room/getdata.aspx") + "';", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "usernotfound", "alert('Please Select Perfect date'); ", true);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            HttpCookie cm = Request.Cookies["loginid"];
            cm.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cm);
            Response.Redirect("~/Pages/masterpage/login.aspx");
        }
        public void getdata()
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
        public string ChangeDate(string date)
        {
            string MainValue = "";
            if (date != null)
            {
                string one = date.Substring(0, 2);
                string two = date.Substring(3, 2);
                string three = date.Substring(6, 4);
                MainValue = $"{one}-{two}-{three}";
            }
            return date;
        }

        protected void textto_TextChanged(object sender, EventArgs e)
        {
            if (textfrom.Text != "")
            {
                string date1 = ChangeDate(textfrom.Text);

                if (textto.Text != "")
                {
                    string date2 = ChangeDate(textto.Text);

                    double value = bookingstatus.CalculateDate(date1, date2);
                    switch (value)
                    {
                        case 1:
                            Label8.Text = "";
                            lblcharge.Text = readprice().ToString();
                            break;
                        //case 2:
                        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "usernotfound", "alert('Please Select Perfect date'); ", true);
                        //    break;
                        case -1:
                            Label8.Text = "please seleect perfect date";
                            break;
                        case 0:
                            Label8.Text = Label8.Text = "please select Perfect date";
                            break;
                        default:
                            Label8.Text = "";
                            lblcharge.Text = (value * readprice()).ToString();
                            break;
                    }
                }
            }
        }
    }
}