using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WCF.DAO
{
    public class ConnectionString
    {
        private string _connectionString;

        public ConnectionString()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["UnivercityDatabase"].ConnectionString;
        }

        public string GetConnectionString()
        {
            return _connectionString;
        }
    }
}