using DAL;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;

namespace BLL
{
    public class AdminHome
    {
        public static void sendemail(string emailbody, string reciever, string subject)
        {
            MailMessage mail = new MailMessage("sachinvarma4545@gmail.com", reciever);
            mail.Subject = subject;
            mail.Body = emailbody;

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "sachinvarma4545@gmail.com",
                Password = "wzljbnwnbkrqcsox"
            };
            smtpClient.EnableSsl = true;
            smtpClient.Send(mail);

        }

        public static SqlDataReader getemail(int userid)
        {
            string sp_name = "mailcheck";
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@userid", userid);
            SqlDataReader sql;
            sql = SqlHelper.ExecuteReader(SqlHelper.ConnectionString(), CommandType.StoredProcedure, sp_name, para);
            return sql;
        }

        public static SqlDataReader showmaindata()
        {
            string sp_name = "dashboard";
            SqlDataReader sql;
            sql = SqlHelper.ExecuteReader(SqlHelper.ConnectionString(), CommandType.StoredProcedure, sp_name);
            return sql;
        }
    }
}