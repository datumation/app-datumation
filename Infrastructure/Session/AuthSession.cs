using Dapper;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;

namespace Datumation.Infrastructure.Session
{
    public static class AuthSession
    {

        public static IDbConnection GetCon()
        {
            return new SqlConnection("Data Source=");
        }


        public static bool IsUserAuthenticated(string qbTicket)
        {
            bool validates = false;
            string getRequest = "https://ma.quickbase.com/db/bjquik34u?a=API_DoQueryCount&query={6.OAF.'" + DateTime.Now.AddDays(-30).Date.ToString("MM/dd/yyyy") + "'}&clist=6&ticket=" + qbTicket;
            // Infrastructure.Logging.LogFactory.Instance.Log().GenerateEmail("GetUserTicket ", "Client address: " + qbTicket);


            // Infrastructure.Logging.LogFactory.Instance.Log().GenerateEmail("Validates ", validates.ToString());

            return validates;
        }
    }
}