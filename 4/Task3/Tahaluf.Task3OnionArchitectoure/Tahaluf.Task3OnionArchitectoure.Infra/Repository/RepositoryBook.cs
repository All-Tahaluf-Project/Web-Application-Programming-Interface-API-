using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Tahaluf.Task3OnionArchitectoure.Core.Connection;
using Tahaluf.Task3OnionArchitectoure.Core.Data.DTO;
using Tahaluf.Task3OnionArchitectoure.Core.Data.Models;
using Tahaluf.Task3OnionArchitectoure.Core.Repository;

namespace Tahaluf.Task3OnionArchitectoure.Infra.Repository
{
    public class RepositoryBook : IRepositoryBook
    {
        IConnection _connection;
        public RepositoryBook(IConnection connection)
        {
            _connection = connection;
        }
        public int DeleteBook(int Id)
        {
            var PCheck = new DynamicParameters();
            PCheck.Add("@Id", Id, DbType.Int32, direction: ParameterDirection.Input);
            var Book = _connection.DBConnection.Query<Book>("CheckBook", PCheck, commandType: CommandType.StoredProcedure).AsList();
            if (Book.Count == 0) { return 0; }

            var P = new DynamicParameters();
            P.Add("@BookId", Id, DbType.Int32, direction: ParameterDirection.Input);

            _connection.DBConnection.ExecuteAsync("DeleteBook", P, commandType: CommandType.StoredProcedure);
            return 1;
        }

        public DetailsDTOBook DetailsBook(int Id)
        {
            var P = new DynamicParameters();
            P.Add("@BookId", Id, DbType.Int32, direction: ParameterDirection.Input);
            var Book = _connection.DBConnection.Query<DetailsDTOBook>("DetailsBook", P, commandType: CommandType.StoredProcedure).AsList();
            if (Book.Count == 0) { return null; }
            return Book.ToArray()[0];
        }

        public List<Book> GetAllBook()
        {
            return _connection.DBConnection.Query<Book>("GetAllBook").AsList();
        }

        public int InsertBook(Book model)
        {
            var PCheck = new DynamicParameters();
            PCheck.Add("@Id", model.CourseId, DbType.Int32, direction: ParameterDirection.Input);
            var Course = _connection.DBConnection.Query<Course>("CheckCourse", PCheck,commandType:CommandType.StoredProcedure).AsList();
            if(Course.Count == 0) { return 0; }

            var P = new DynamicParameters();
            P.Add("@BookName", model.BookName, DbType.String, direction: ParameterDirection.Input);
            P.Add("@CourseId", model.CourseId, DbType.Int32, direction: ParameterDirection.Input);

            _connection.DBConnection.ExecuteAsync("InsertBook", P, commandType: CommandType.StoredProcedure);
            return 1;
        }

        public int UpdateBook(Book model)
        {
            var PCheck = new DynamicParameters();
            PCheck.Add("@Id", model.BookId, DbType.Int32, direction: ParameterDirection.Input);
            var Book = _connection.DBConnection.Query<Book>("CheckBook", PCheck, commandType: CommandType.StoredProcedure).AsList();
            if (Book.Count == 0) { return 0; }

             PCheck = new DynamicParameters();
            PCheck.Add("@Id", model.CourseId, DbType.Int32, direction: ParameterDirection.Input);
            var Course = _connection.DBConnection.Query<Course>("CheckCourse", PCheck, commandType: CommandType.StoredProcedure).AsList();
            if (Course.Count == 0) { return 2; }

            var P = new DynamicParameters();
            P.Add("@BookId", model.BookId, DbType.Int32, direction: ParameterDirection.Input);
            P.Add("@BookName", model.BookName, DbType.String, direction: ParameterDirection.Input);
            P.Add("@CourseId", model.CourseId, DbType.Int32, direction: ParameterDirection.Input);

            _connection.DBConnection.ExecuteAsync("UpdateBook", P, commandType: CommandType.StoredProcedure);
            return 1;
        }
    }
}
