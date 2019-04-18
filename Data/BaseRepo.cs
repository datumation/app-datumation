using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace app_datumation.Data
{
    public abstract class BaseRepo
    {
        public IDbConnection GetSql(string sqlCon)
        {
            return new SqlConnection(sqlCon);
        }
    }
}