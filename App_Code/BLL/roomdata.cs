using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using DAL;
using Variable;

namespace BLL
{
    public class roomdata
    {
        public static void insertdata(registervariable va)
        {
            string sp_name = "roomadd";
            SqlParameter[] param = new SqlParameter[8];
            param[1] = new SqlParameter("@room_no", va.roomid);
            param[2] = new SqlParameter("@userid", va.userid);
            param[3] = new SqlParameter("@roomtype", va.room_type);
            param[4] = new SqlParameter("@fromdate", va.fromdate);
            param[5] = new SqlParameter("@todate", va.todate);
            param[6] = new SqlParameter("@bookingcharge", va.charge);
            param[7] = new SqlParameter("@review", va.review);

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString(), CommandType.StoredProcedure, sp_name, param);
        }

        public static SqlDataReader getalldata(int va)
        {
            SqlDataReader dr;
            string sp_name = "getdetails";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@userid", va);
            dr=SqlHelper.ExecuteReader(SqlHelper.ConnectionString(), CommandType.StoredProcedure, sp_name , sqlParameters);
            return dr;


        }
        public static DataSet getValueofDate(int RoomId)
        {
            DataSet Dat = new DataSet();
            string sp_name = "getAllDatesForValidation";


            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@RoomId", RoomId);

                Dat = SqlHelper.ExecuteDataset(SqlHelper.ConnectionString(), CommandType.StoredProcedure, sp_name, param);
                return Dat;
            }
            catch
            {
                throw;
            }
        }

        public static List<string> containDate = new List<string>();
        public static List<string> CheckDateAlreadyExists(int initial, int roomId)
        {

            DataSet dat = getValueofDate(roomId);
            DataTable dt = new DataTable();
            dt = dat.Tables[0];

            if (dt.Rows.Count > initial)
            {
                DateTime D1 = DateTime.Parse(dt.Rows[initial]["FromDate"].ToString()).Date;
                DateTime D2 = DateTime.Parse(dt.Rows[initial]["ToDate"].ToString()).Date;
                while (D1 <= D2)
                {
                    containDate.Add(D1.ToShortDateString());
                    D1 = D1.AddDays(1);
                }
                CheckDateAlreadyExists(initial + 1, roomId);
            }
            return containDate;
        }
    }
}