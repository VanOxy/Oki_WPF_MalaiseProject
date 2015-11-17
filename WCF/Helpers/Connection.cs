using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WCF.Helpers
{
    public class Connection
    {
        private string _connectionString;

        public Connection()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["UnivercityDatabase"].ConnectionString;
        }

        public string GetConnectionString()
        {
            return _connectionString;
        }
    }
}