using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using Tahaluf.Batsh3DB.Core.Common;

namespace Tahaluf.Batsh3DB.Infra.Common
{
    public class DBContext : IDBContext
    {
        private DbConnection _connection;
        private IConfiguration _configuration;
        public DBContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public DbConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    //My Solution (1)
                    _connection = new
                    SqlConnection(_configuration.GetConnectionString("DBConnectionString"));
                    //Her Solution (2)
                    //_connection = new
                    //SqlConnection(_configuration["ConnectionStrings:DBConnectionString"]);
                    _connection.Open();
                }
                else
                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }
                return _connection;
            }
        }
    }
}
