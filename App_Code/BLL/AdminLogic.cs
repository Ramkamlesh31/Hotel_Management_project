using DAL;
using System;
using System.Data;
using System.Data.SqlClient;
using Variable;

namespace BLL
{
    public class AdminLogic
    {
        registervariable va = new registervariable();
        public static SqlDataReader requestforadmin()
        {
            string sp_name = "Admin_Req";
            SqlDataReader dt;
            dt = SqlHelper.ExecuteReader(SqlHelper.ConnectionString(), CommandType.StoredProcedure, sp_name);
            return dt;
        }

        public static void ApproveAdmin(int userid)
        {
            string sp_name = "ApproveForAdmin";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@userid", userid);
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString(), CommandType.StoredProcedure, sp_name, param);

        }

        public static SqlDataReader Updaterecord(int userid)
        {
            string sp_name = "FillUserTable";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@userid", userid);
            SqlDataReader sd;
            sd = SqlHelper.ExecuteReader(SqlHelper.ConnectionString(), CommandType.StoredProcedure, sp_name, param);
            return sd;

        }

        public static int Update(registervariable va)
        {
            string sp_name = "UpdateUserTable";
            SqlParameter[] param = new SqlParameter[11];
            param[0] = new SqlParameter("@userid", va.userid);
            param[1] = new SqlParameter("@firstname", va.firstname);
            param[2] = new SqlParameter("@lastname", va.lastname);
            param[3] = new SqlParameter("@mobile", va.mobile);
            param[4] = new SqlParameter("@email", va.Email);
            param[5] = new SqlParameter("@address", va.address);
            param[6] = new SqlParameter("@isactive", va.id);
            param[7] = new SqlParameter("@backoff", va.backoff);
            param[8] = new SqlParameter("@documenttype", va.documnet_type);
            param[9] = new SqlParameter("@documnetno", va.document_no);
            param[10] = new SqlParameter("@docimage", va.document_img);
            int value = Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionString(), CommandType.StoredProcedure, sp_name, param));
            return value;


        }
        public static SqlDataReader Appadmin()
        {
            string sp_name = "ApproveToAdminDetails";
            SqlDataReader dt;
            dt = SqlHelper.ExecuteReader(SqlHelper.ConnectionString(), CommandType.StoredProcedure, sp_name);
            return dt;
        }

    }
}