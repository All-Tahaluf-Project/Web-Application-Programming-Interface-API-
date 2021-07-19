using Dapper;
using OurProject.Core.Connection;
using OurProject.Core.Data;
using OurProject.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace OurProject.Infra.Repository
{
    public class RepositoryC : IRepositoryC
    {
        IConnection _connection;
        public RepositoryC(IConnection connection)
        {
            _connection = connection;
        }
        public int DeleteC(int Id)
        {
            var P = new DynamicParameters();

            P.Add("@Id",Id,DbType.Int32,direction:ParameterDirection.Input);

            _connection.DBConnection.ExecuteAsync("DeleteC", P,commandType:CommandType.StoredProcedure);
            return 1;
        }

        public List<C> GetAllC()
        {
            return _connection.DBConnection.Query<C>("GetAllC").AsList();
        }

        public int InsertC(C model)
        {
            var P = new DynamicParameters();

            P.Add("@AId", model.AId, DbType.Int32, direction: ParameterDirection.Input);
            P.Add("@DId", model.DId, DbType.Int32, direction: ParameterDirection.Input);

            _connection.DBConnection.ExecuteAsync("InsertC", P, commandType: CommandType.StoredProcedure);
            return 1;
        }

        public int UpdateC(C model)
        {
            var P = new DynamicParameters();

            P.Add("@Id", model.Id, DbType.Int32, direction: ParameterDirection.Input);
            P.Add("@AId", model.AId, DbType.Int32, direction: ParameterDirection.Input);
            P.Add("@DId", model.DId, DbType.Int32, direction: ParameterDirection.Input);

            _connection.DBConnection.ExecuteAsync("UpdateC", P, commandType: CommandType.StoredProcedure);
            return 1;
        }
    }
}
