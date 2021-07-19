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
            var P = new DynamicParameters();
            P.Add("@CourseName", model.CourseName, DbType.String, direction: ParameterDirection.Input);

            _connection.DBConnection.ExecuteAsync("InsertCourse", P, commandType: CommandType.StoredProcedure);
            return 1;
        }

        public int UpdateCourse(Course model)
        {
            var PCheck = new DynamicParameters();
            PCheck.Add("@Id", model.CourseId, DbType.Int32, direction: ParameterDirection.Input);
            var Course = _connection.DBConnection.Query<Course>("CheckCourse", PCheck, commandType: CommandType.StoredProcedure).AsList();
            if (Course.Count == 0) { return 0; }

            var P = new DynamicParameters();
            P.Add("@CourseId", model.CourseId, DbType.Int32, direction: ParameterDirection.Input);
            P.Add("@CourseName", model.CourseName, DbType.String, direction: ParameterDirection.Input);

            _connection.DBConnection.ExecuteAsync("UpdateCourse", P, commandType: CommandType.StoredProcedure);
            return 1;
        }
    }
}
