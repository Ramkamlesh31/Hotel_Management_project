using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace Variable
{
    public class registervariable
    {
        public DateTime date1 { get; set; }
        public DateTime date2{ get; set; }
        public string  firstname { get; set; }
        public string lastname { get; set; }
        public string mobile { get; set; }
        public string  Email { get; set; }
        public string address { get; set; }
        public string  username { get; set; }
        public string password { get; set; }
        public string documnet_type { get; set; }
        public string document_no { get; set; }
        public string document_img { get; set; }

        public byte admin_req { get; set; }
        public string room_type { get; set; }
        public int room_no { get; set; }
        public byte[] room_img { get; set; }
        public double bookingcharge { get; set; }
        
        public double cancellation { get; set; }
        public int roomid { get; set; }
        public DateTime fromdate { get; set; }
        public DateTime todate { get; set; }

        public string review { get; set; }

        public double doublecharge { get; set; }
        public float charge  { get; set; }

        public int userid { get; set; }
        public int id { get; set; }
        public string select { get; set; }
        public int usertype { get; set; }
        public string image { get; set; }
        public int backoff { get; set; }
        public int max_length { get; set; }
        public int min_length { get; set; }
        public string status { get; set; }
        public int isactive { get; set; }
        public string type { get; set; }
    }
}