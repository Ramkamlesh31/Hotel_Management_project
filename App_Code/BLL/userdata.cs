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
    public class userdata
    {
        registervariable va = new registervariable();
        public static SqlDataReader getuserdata()
        {
            string sp_name = "userdata";
            SqlDataReader st;
            st = SqlHelper.ExecuteReader(SqlHelper.ConnectionString(),CommandType.StoredProcedure, sp_name);
            return st;

        }

        public static SqlDataReader getroomdata()
        {
            string sp_name = "getroomdata";
            SqlDataReader dr;
            dr=SqlHelper.ExecuteReader(SqlHelper.ConnectionString(),CommandType.StoredProcedure , sp_name);
            return dr;
        }
        public static SqlDataReader getroomdata1()
        {
            string sp_name = "getApprove";
            SqlDataReader dr;
            dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionString(), CommandType.StoredProcedure, sp_name);
            return dr;
        }
        public static SqlDataReader getroomdata2()
        {
            string sp_name = "getreject";
            SqlDataReader dr;
            dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionString(), CommandType.StoredProcedure, sp_name);
            return dr;
        }

        public static int insertusertype(registervariable va)   
        {
            string sp_name = "Methodofusertype";
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@id",va.id);
            param[1] = new SqlParameter("@usertype",va.type);
            param[2] = new SqlParameter("@status" ,va.status);
            param[3] = new SqlParameter("@userid", va.userid);
            param[4] = new SqlParameter("@isactive", va.isactive);

            int value =Convert.ToInt32( SqlHelper.ExecuteScalar(SqlHelper.ConnectionString(), CommandType.StoredProcedure, sp_name, param));
            return value;

        }

        public static SqlDataReader showusertypedata()
        {
            string sp_name = "showusertype";
            SqlDataReader st;
            st = SqlHelper.ExecuteReader (SqlHelper.ConnectionString(),CommandType.StoredProcedure , sp_name);
            return st;
        }
        public static SqlDataReader fillusertypedata(int id)
        {
            string sp_name = "FilluserTypedata";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", id);
            SqlDataReader st;
            st= SqlHelper.ExecuteReader(SqlHelper.ConnectionString(), CommandType.StoredProcedure, sp_name, param);
            return st;

        }
    }
}