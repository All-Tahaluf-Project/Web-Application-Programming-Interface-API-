using Microsoft.Extensions.Configuration;
using OurProject.Core.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace OurProject.Infra.Connection
{
    public class Connection : IConnection
    {
        DbConnection _connection;
        IConfiguration _configuration;
        public Connection(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public DbConnection DBConnection { get { 

                if(_connection == null)
                {
                    _connection = new SqlConnection(_configuration.GetConnectionString("DBConnectionString"));

                    _connection.Open();
                }

                if(_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }

                return _connection;
            } }
    }
}
