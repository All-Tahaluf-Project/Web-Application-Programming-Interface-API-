using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.Batsh3DB.Core.Common;
using Tahaluf.Batsh3DB.Core.Repository;
using Tahaluf.Batsh3DB.Core.Data;
using Dapper;
using System.Data;

namespace Tahaluf.Batsh3DB.Infra.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private IDBContext _context;
        public CourseRepository(IDBContext dBContext)
        {
            _context = dBContext;
        }

        public List<Course> GetAllCourse()
        {
            IEnumerable<Course> Result = _context.Connection.Query<Course>("GetAllCourse");
            return Result.AsList();
        }

        public object AddCourse(Course model)
        {
            var p = new DynamicParameters();

            p.Add("@Id", model.Id, dbType:DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Name", model.Name, dbType: DbType.String, direction: ParameterDirection.Input);

            var Result = _context.Connection.ExecuteAsync("AddCourse", p, commandType: CommandType.StoredProcedure);
            return Result.Status;
        }

        public object UpdateCourse(Course model)
        {
            var P = new DynamicParameters();

            P.Add("@Id", model.Id, DbType.Int32, direction: ParameterDirection.Input);
            P.Add("@Name", model.Name, DbType.String, direction: ParameterDirection.Input);

            var Result = _context.Connection.ExecuteAsync("UpdateCourse", P, commandType: CommandType.StoredProcedure);
            return Result.Status;
        }

        public object DeleteCourse(int Id)
        {
            var P = new DynamicParameters();
            P.Add("@Id", Id, DbType.Int32, direction:ParameterDirection.Input);

            var Result = _context.Connection.ExecuteAsync("DeleteCourse",P,commandType:CommandType.StoredProcedure);
            return Result.Status;
        }
    }
}
