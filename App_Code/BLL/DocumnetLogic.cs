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
    public class DocumnetLogic
    {
        registervariable va = new registervariable();

        public static int documnetinsert(registervariable va)
        {
            string sp_name = "sp_DocInsert";
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@documnet_type" , va.documnet_type);
            param[1] = new SqlParameter("@max_length", va.max_length);
            param[2] = new SqlParameter("@min_length", va.min_length);
            param[3] = new SqlParameter("@userid", va.userid);
            int value =Convert.ToInt32( SqlHelper.ExecuteScalar(SqlHelper.ConnectionString(), CommandType.StoredProcedure, sp_name , param));
            return value;

        }

        public static SqlDataReader showdocdata()
        {
            string sp_name = "sp_showdocdata";
            SqlDataReader st;
            st = SqlHelper.ExecuteReader(SqlHelper.ConnectionString(), CommandType.StoredProcedure, sp_name);
            return st;
        }

       
        public static int updata(registervariable va)
        {
            string sp_name = "Doc_updatedata";
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@documnet_type", va.documnet_type);
            param[1] = new SqlParameter("@max_length", va.max_length);
            param[2] = new SqlParameter("@min_length", va.min_length);
            param[3] = new SqlParameter("@isactive", va.isactive);
            param[4] = new SqlParameter("@userid", va.isactive);
            param[5] = new SqlParameter("@id", va.id);

            int value =Convert.ToInt32( SqlHelper.ExecuteScalar(SqlHelper.ConnectionString(), CommandType.StoredProcedure, sp_name, param));
            return value;
        }

        public static void deletedata(int id , int userid)
        {
            string sp_name = "deletedoctype";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@id", id);
            param[1] = new SqlParameter("@userid", userid);
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString(), CommandType.StoredProcedure, sp_name, param);


        }
    }
}