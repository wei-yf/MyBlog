using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MyBlog.Help
{
    public class DapperHelp
    {
        private static string connName = "connectstring";
        private static string connString;

        //public static IDbConnection getConn
        //{
        //    get
        //    {
        //        connString = ConfigurationManager.ConnectionStrings[connName].ConnectionString;
        //        return new SqlConnection(connString);
        //    }
        //}

        public static IDbConnection GetOpenConnection()
        {
            connString = ConfigurationManager.ConnectionStrings[connName].ConnectionString;
            return new SqlConnection(connString);
        }
    }
}