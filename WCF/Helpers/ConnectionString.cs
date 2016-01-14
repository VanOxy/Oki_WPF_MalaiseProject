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

        /// <summary>
        /// Permet d'aller rechercher les données dans le Web.config
        /// </summary>
        public ConnectionString()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Univercity"].ConnectionString;
        }

        public string GetConnectionString()
        {
            return _connectionString;
        }
    }
}