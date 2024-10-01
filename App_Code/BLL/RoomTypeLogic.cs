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
    public class RoomTypeLogic
    {
        registervariable va = new registervariable();
        public static int operationofroomtype(registervariable va)
        {
            string sp_name = "Methodofroomtype";
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@id", va.id);
            param[1] = new SqlParameter("@roomtype", va.type);
            param[2] = new SqlParameter("@status", va.status);
            param[3] = new SqlParameter("@userid", va.userid);
            param[4] = new SqlParameter("@isactive", va.isactive);

            int value = Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnectionString(), CommandType.StoredProcedure, sp_name, param));
            return value;

        }

        public static SqlDataReader showroomtype()
        {
            string sp_name = "showroomtype";
            SqlDataReader st;
            st = SqlHelper.ExecuteReader(SqlHelper.ConnectionString(), CommandType.StoredProcedure, sp_name);
            return st;
        }
        public static SqlDataReader Fillroomtypedata(int id)
        {
            string sp_name = "Fillroomtypedata";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", id);
            SqlDataReader st;
            st = SqlHelper.ExecuteReader(SqlHelper.ConnectionString(), CommandType.StoredProcedure, sp_name, param);
            return st;

        }
    }
}