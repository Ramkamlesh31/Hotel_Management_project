using DAL;
using System;
using System.Data;
using System.Data.SqlClient;
using Variable;

namespace BLLI
{
    public class Roomlogic
    {
        public static int insertdata(registervariable va)
        {
            string sp_name = "insertroomdata";
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@room_type", va.room_type);
            param[1] = new SqlParameter("@room_no", va.room_no);
            param[2] = new SqlParameter("@room_img", va.image);
            param[3] = new SqlParameter("@bookingcharge", va.bookingcharge);
            param[4] = new SqlParameter("@cancellation", va.cancellation);
            param[5] = new SqlParameter("@isactive", va.id);
            int result = Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionString(), CommandType.StoredProcedure, sp_name, param));
            return result;
        }
        public static SqlDataReader getdata()
        {
            SqlDataReader dt;
            string sp_name = "getroom";
            dt = SqlHelper.ExecuteReader(SqlHelper.ConnectionString(), CommandType.StoredProcedure, sp_name);
            return dt;
        }

        public static SqlDataReader getalldata(int roomid)
        {
            SqlDataReader dr;
            string sp_name = "getalldata";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@room_no", roomid);
            dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionString(), CommandType.StoredProcedure, sp_name, param);
            return dr;
        }

        public static SqlDataReader getid(string username)
        {
            SqlDataReader dr;
            string sp_name = "selectid";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@username", username);
            dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionString(), CommandType.StoredProcedure, sp_name, param);
            return dr;
        }
        public static SqlDataReader show()
        {
            SqlDataReader dr;
            string sp_name = "AddRommData";
            dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionString(), CommandType.StoredProcedure, sp_name);
            return dr;
        }

        public static SqlDataReader getAdddata(int roomid)
        {
            SqlDataReader dr;
            string sp_name = "GetdataByID";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@roomid", roomid);
            dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionString(), CommandType.StoredProcedure, sp_name, param);
            return dr;
        }

        public static int updateroomadddata(registervariable va)
        {
            string sp_name = "UpdateAddRoomData";
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@userid", va.userid);
            param[1] = new SqlParameter("@roomid", va.roomid);
            param[2] = new SqlParameter("@room_type", va.room_type);
            param[3] = new SqlParameter("@room_no", va.room_no);
            param[4] = new SqlParameter("@bookingcharge", va.doublecharge);
            param[5] = new SqlParameter("@cancellation", va.cancellation);
            param[6] = new SqlParameter("@isactive", va.id);
            param[7] = new SqlParameter("@room_img", va.image);

            int value = Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionString(), CommandType.StoredProcedure, sp_name, param));
            return value;

        }

        public static int deletedata(int userid, int roomid , string roomno)
        {
            string sp_name = "DeleteAddRoom";
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@userid", userid);
            param[1] = new SqlParameter("@roomid", roomid);
            param[2] = new SqlParameter("@roomno", roomno);
            var data = Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionString(), CommandType.StoredProcedure, sp_name, param));
            return data;

        }
       
    }
}