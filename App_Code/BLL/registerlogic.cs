using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Variable;
using System.Data;
using System.Data.SqlClient;
using DAL;
using System.Runtime.InteropServices;

namespace BAL
{
    public class registerlogic
    {
        public static int userregister(registervariable va)
        {
            string sp_name = "userregister";
            SqlParameter[] param = new SqlParameter[11];
            param[0] = new SqlParameter("@firstname", va.firstname);
            param[1] = new SqlParameter("lastname", va.lastname);
            param[2] = new SqlParameter("@mobile", va.mobile);
            param[3] = new SqlParameter("@email", va.Email);
            param[4] = new SqlParameter("@address", va.address);
            param[5] = new SqlParameter("@username", va.username);
            param[6] = new SqlParameter("@password", va.password);
            param[7] = new SqlParameter("@DOCUMENTTYPE", va.documnet_type);
            param[8] = new SqlParameter("@DOCUMENTNO", va.document_no);
            param[9] = new SqlParameter("@docimage", va.document_img);
            param[10] = new SqlParameter("@admin_req", va.admin_req);
            int result =Convert.ToInt32( SqlHelper.ExecuteScalar(SqlHelper.ConnectionString(), sp_name, param));
            return result;


        }
      
    }
}