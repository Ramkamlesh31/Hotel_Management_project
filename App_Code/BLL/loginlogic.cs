using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
using System.Data;
using System.Data.SqlClient;
using Variable;

namespace BLL
{
    public class loginlogic
    {
        public static int checkdata(registervariable va)
        {
            string sp_name = "userOrAdminLogin";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@username", va.username);
            param[1] = new SqlParameter("@password", va.password);
            

            int value =Convert.ToInt32( SqlHelper.ExecuteScalar(SqlHelper.ConnectionString(), CommandType.StoredProcedure, sp_name, param));
            return value;
            

        }


    }
}