using Batch3.Core.Data.DTO;
using Batch3.Core.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Tahaluf.Task3OnionArchitectoure.Core.Connection;

namespace Batch3.Infra.Repository
{
    public class RepositoryMark : IRepositoryMark
    {
        IConnection _connection;
        public RepositoryMark(IConnection connection)
        {
            _connection = connection;
        }

        public object AboveAVG(int Id)
        {
            var Marks = GetAllMarks(Id);
            var AVG = Marks.Average(a => a.MarkValue);
            return Marks.Where(a=>a.MarkValue >= AVG);
        }

        public object AVG(int Id)
        {
            var Marks = GetAllMarks(Id);
            return Marks.Average(a=>a.MarkValue);
        }

        public List<DetailsDTOMark> GetAllMarks(int Id)
        {
            var P = new DynamicParameters();
            P.Add("@Id", Id, DbType.Int32, direction: ParameterDirection.Input);
            return _connection.DBConnection.Query<DetailsDTOMark>("GetAllMarks",P,commandType:CommandType.StoredProcedure).AsList();
        }

        public object BellowAVG(int Id)
        {
            var Marks = GetAllMarks(Id);
            var AVG = Marks.Average(a => a.MarkValue);
            return Marks.Where(a => a.MarkValue <= AVG);
        }

        public object Sum(int Id)
        {
            var Marks = GetAllMarks(Id);
            return Marks.Sum(a => a.MarkValue);
        }

        public object CountMarks(int Id)
        {
            var Marks = GetAllMarks(Id);
            return Marks.Count();
        }
    }
}
