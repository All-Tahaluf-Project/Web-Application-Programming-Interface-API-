using Batch3.Core.Data.DTO;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tahaluf.Task3OnionArchitectoure.Core.Connection;
using Tahaluf.Task3OnionArchitectoure.Core.Data.DTO;
using Tahaluf.Task3OnionArchitectoure.Core.Data.Models;
using Tahaluf.Task3OnionArchitectoure.Core.Repository;

namespace Tahaluf.Task3OnionArchitectoure.Infra.Repository
{
    public class RepositoryCourse : IRepositoryCourse
    {
        IConnection _connection;
        public RepositoryCourse(IConnection connection)
        {
            _connection = connection;
        }
        public int DeleteCourse(int Id)
        {
            var PCheck = new DynamicParameters();
            PCheck.Add("@Id", Id, DbType.Int32, direction: ParameterDirection.Input);
            var Course = _connection.DBConnection.Query<Course>("CheckCourse", PCheck, commandType: CommandType.StoredProcedure).AsList();
            if (Course.Count == 0) { return 0; }

            PCheck = new DynamicParameters();
            PCheck.Add("@CourseId", Id, DbType.Int32, direction: ParameterDirection.Input);
            var BookList = _connection.DBConnection.Query<Book>("GetAllBookForCourse", PCheck, commandType: CommandType.StoredProcedure).AsList();
            if (BookList.Count != 0) { return 2; }

            PCheck = new DynamicParameters();
            PCheck.Add("@CourseId", Id, DbType.Int32, direction: ParameterDirection.Input);
            var TeacherCourse = _connection.DBConnection.Query<DetailsDTOTeacherCourse>("DetailsTeacherCourseForCourse", PCheck, commandType: CommandType.StoredProcedure).AsList();
            if (TeacherCourse.Count != 0) { return 3; }

            var P = new DynamicParameters();
            P.Add("@CourseId", Id, DbType.Int32, direction: ParameterDirection.Input);

            _connection.DBConnection.ExecuteAsync("DeleteCourse", P, commandType: CommandType.StoredProcedure);
            return 1;
        }

        public DetailsDTOCourse DetailsCourse(int Id)
        {
            var P = new DynamicParameters();
            P.Add("@CourseId", Id, DbType.Int32, direction: ParameterDirection.Input);
            var Course = _connection.DBConnection.Query<DetailsDTOCourse>("DetailsCourse", P, commandType: CommandType.StoredProcedure).AsList();
            if (Course.Count == 0) { return null; }

            P = new DynamicParameters();
            P.Add("@CourseId", Id, DbType.Int32, direction: ParameterDirection.Input);
            var Book = _connection.DBConnection.Query<Book>("GetAllBookForCourse", P, commandType: CommandType.StoredProcedure).AsList();
            Course.ToArray()[0].Books = Book;

            P = new DynamicParameters();
            P.Add("@CourseId", Id, DbType.Int32, direction: ParameterDirection.Input);
            var TeacherCourse = _connection.DBConnection.Query<DetailsDTOTeacherCourse>("DetailsTeacherCourseForCourse", P, commandType: CommandType.StoredProcedure).AsList();
            Course.ToArray()[0].TeacherCourse = TeacherCourse;

            return Course.ToArray()[0];
        }

        public List<Course> GetAllCourse()
        {
            return _connection.DBConnection.Query<Course>("GetAllCourse").AsList();
        }

        public int InsertCourse(Course model)
        {
            try
            {
                var P = new DynamicParameters();
                P.Add("@CourseName", model.CourseName, DbType.String, direction: ParameterDirection.Input);

                return _connection.DBConnection.ExecuteAsync("AddCourse", P, commandType: CommandType.StoredProcedure).Result;
            }
            catch
            {
                return 2;
            }
        }

        public int UpdateCourse(Course model)
        {
            var PCheck = new DynamicParameters();
            PCheck.Add("@Id", model.CourseId, DbType.Int32, direction: ParameterDirection.Input);
            var Course = _connection.DBConnection.Query<Course>("CheckCourse", PCheck, commandType: CommandType.StoredProcedure).AsList();
            if (Course.Count == 0) { return 0; }

            var P = new DynamicParameters();
            P.Add("@Id", model.CourseId, DbType.Int32, direction: ParameterDirection.Input);
            P.Add("@CourseName", model.CourseName, DbType.String, direction: ParameterDirection.Input);

            _connection.DBConnection.ExecuteAsync("UpdateCourse", P, commandType: CommandType.StoredProcedure);
            return 1;
        }

        public List<Course> Search(CourseDTO courseDTO)
        {
            var p = new DynamicParameters();
            p.Add("@CourseName", courseDTO.CourseName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@CategoryName", courseDTO.CategoryName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@DateFrom", courseDTO.DateFrom, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@DateTo", courseDTO.DateTo, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            IEnumerable<Course> result = _connection.DBConnection.Query<Course>("Search",p, commandType: CommandType.StoredProcedure);
            return result.AsList();
        }


        public async Task<List<Course>> GetAllCourseBook()
        {
            var Result = await _connection.DBConnection.QueryAsync<Course,Book,Course>("GetAllCourseBook", (course,book)=>
            {
                course.Book = course.Book ?? new List<Book>();
                course.Book.Add(book);
                return course;
            }
            //For Separate Books
            ,splitOn: "BookId"
            , param: null
            ,commandType:CommandType.StoredProcedure
            );

            var FinalResult = Result.AsList<Course>().GroupBy(p => p.CourseId)
                .Select(g =>
                 {
                     Course course = g.First();
                     course.Book = g.Where(a => a.Book.Any() && a.Book.Count() > 0).Select(a =>
                       a.Book.Single()
                     ).GroupBy(a => a.BookId).Select(b =>
                     new Book()
                     {
                         BookId = b.First().BookId,
                         BookName = b.First().BookName,
                     }
                     ).ToList();
                     return course;
                 });

            return FinalResult.AsList();
        }
    }
}
