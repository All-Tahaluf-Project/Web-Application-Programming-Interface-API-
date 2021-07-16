using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Tahaluf.Batsh3DB.Core.Common;
using Tahaluf.Batsh3DB.Core.Data;
using Tahaluf.Batsh3DB.Core.Repository;

namespace Tahaluf.Batsh3DB.Infra.Repository
{
    public class BookRepository : IBookReository
    {
        private IDBContext _context;
        public BookRepository(IDBContext dBContext)
        {
            _context = dBContext;
        }
        public object AddBook(Book model)
        {
            var P = new DynamicParameters();

            P.Add("@Id", model.Id, DbType.Int32, direction: ParameterDirection.Input);
            P.Add("@Name", model.Name, DbType.String, direction: ParameterDirection.Input);
            P.Add("@CourseId", model.CourseId, DbType.Int32, direction: ParameterDirection.Input);

            return _context.Connection.ExecuteAsync("AddBook", P, commandType: CommandType.StoredProcedure).Status;
        }

        public object DeleteBook(int Id)
        {
            var P = new DynamicParameters();

            P.Add("@Id", Id, DbType.Int32, direction: ParameterDirection.Input);

            return _context.Connection.ExecuteAsync("DeleteBook", P, commandType: CommandType.StoredProcedure).Status;
        }

        public List<Book> GetAllBook()
        {
            return _context.Connection.Query<Book>("GetAllBook").AsList();
        }

        public object UpdateBook(Book model)
        {
            var P = new DynamicParameters();

            P.Add("@Id", model.Id, DbType.Int32, direction: ParameterDirection.Input);
            P.Add("@Name", model.Name, DbType.String, direction: ParameterDirection.Input);
            P.Add("@CourseId", model.CourseId, DbType.Int32, direction: ParameterDirection.Input);

            return _context.Connection.ExecuteAsync("UpdateBook", P, commandType: CommandType.StoredProcedure).Status;
        }
    }
}
