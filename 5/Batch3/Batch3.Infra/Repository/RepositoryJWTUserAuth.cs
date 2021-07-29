using Batch3.Core.Data.DTO;
using Batch3.Core.Data.Models;
using Batch3.Core.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Tahaluf.Task3OnionArchitectoure.Core.Connection;

namespace Batch3.Infra.Repository
{
    public class RepositoryJWTUserAuth : IRepositoryJWTUserAuth
    {
        IConnection _connection;
        public RepositoryJWTUserAuth(IConnection connection)
        {
            _connection = connection;
        }

        public User GetUser(User model)
        {
            var P = new DynamicParameters();

            P.Add("@UserName", model.UserName, DbType.String, direction: ParameterDirection.Input);
            P.Add("@Password", model.Password, DbType.String, direction: ParameterDirection.Input);

            var R = _connection.DBConnection.Query<DetailsDTOUser>("GetUser", P, commandType: CommandType.StoredProcedure).AsList();

            if(R.Count == 0) { return null; }
            var Data = R.ToArray()[0];
            var User = new User {
                Id = Data.Id,
                UserName = Data.UserName,
                Role = new Role() { Name = Data.RoleName}
            };

            return User;
        }

        public DetailsTraineeUserDTO GetTraineeUserById(int Id)
        {
            var P = new DynamicParameters();

            P.Add("@Id", Id, DbType.Int32, direction: ParameterDirection.Input);

            var R = _connection.DBConnection.Query<DetailsTraineeUserDTO>("GetTraineeUserById", P, commandType: CommandType.StoredProcedure).AsList();

            if (R.Count == 0) { return null; }

            return R.ToArray()[0];
        }

        public DetailsTeacherUserDTO GetTeacherUserById(int Id)
        {
            var P = new DynamicParameters();

            P.Add("@Id", Id, DbType.Int32, direction: ParameterDirection.Input);

            var R = _connection.DBConnection.Query<DetailsTeacherUserDTO>("GetTeacherUserById", P, commandType: CommandType.StoredProcedure).AsList();

            if (R.Count == 0) { return null; }

            return R.ToArray()[0];
        }
    }
}
