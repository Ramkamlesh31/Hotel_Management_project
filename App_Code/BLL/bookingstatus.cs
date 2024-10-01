using DAL;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class bookingstatus
    {
        public DateTime date = DateTime.Now;
        public static int ApproveBooking(int userid , int id)
        {
            
            string sp_name = "ApproveRoom";
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@userid", userid);
            sp[1] = new SqlParameter("@id", id);
            int value =Convert.ToInt32( SqlHelper.ExecuteScalar(SqlHelper.ConnectionString(), CommandType.StoredProcedure, sp_name, sp));
            return value;
        }
        public static int RejectBooking(int userid, int id)
        {
            string sp_name = "RejectRoom";
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@userid", userid);
            sp[1] = new SqlParameter("@id", id);
            int value=Convert.ToInt32( SqlHelper.ExecuteScalar(SqlHelper.ConnectionString(), CommandType.StoredProcedure, sp_name, sp));
            return value;
        }

        public static void Softdelete(int userid , int backoff)
        {
            string sp_name = "Softdelete";
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@userid", userid);
            sp[1] = new SqlParameter("@backoff", backoff);
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString(), CommandType.StoredProcedure, sp_name, sp);
        }

        public static double CalculateDate(string date1, string date2)
        {
            double value;            
            //var dateone = DateTime.ParseExact(date1 ,"mm-dd-yyyy" ,System.Globalization.CultureInfo.InvariantCulture);
            //var datetwo = DateTime.ParseExact(date2, "mm-dd-yyyy", System.Globalization.CultureInfo.InvariantCulture);
            var dateone = Convert.ToDateTime(date1);
            var datetwo = Convert.ToDateTime(date2);
            try
            {
                
                if (dateone >= DateTime.Now.AddDays(-1))
                {
                    TimeSpan Cal = datetwo - dateone;
                    double calConvert = Cal.Days;
                    int val = (int)calConvert;
                    if (val < 0)
                        value = -1;
                    else if (val == 0)
                        value = 1;
                    else
                        value = val;
                }
                else
                    value = 0;
            }
            catch (Exception e)
            {
                throw e;
            }
            return value;
        }
    }
}