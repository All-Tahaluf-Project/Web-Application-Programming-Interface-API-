using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.Task3OnionArchitectoure.Core.Connection;
using Tahaluf.Task3OnionArchitectoure.Core.Data.DTO;
using Tahaluf.Task3OnionArchitectoure.Core.Data.Models;
using Tahaluf.Task3OnionArchitectoure.Core.Repository;
using System.Data;

namespace Tahaluf.Task3OnionArchitectoure.Infra.Repository
{
    public class RepositoryTeacherCourse : IRepositoryTeacherCourse
    {
        IConnection _connection;
        public RepositoryTeacherCourse(IConnection connection)
        {
            _connection = connection;
        }
        public int DeleteTeacherCourse(int Id)
        {
            var PCheck = new DynamicParameters();
            PCheck.Add("@Id", Id, DbType.Int32, direction: ParameterDirection.Input);
            var TeacherCourse = _connection.DBConnection.Query<TeacherCourse>("CheckTeacherCourse", PCheck, commandType: CommandType.StoredProcedure).AsList();
            if (TeacherCourse.Count == 0) { return 0; }

            var P = new DynamicParameters();
            P.Add("@TeacherCourseId", Id, DbType.Int32, direction: ParameterDirection.Input);

            _connection.DBConnection.ExecuteAsync("DeleteTeacherCourse", P, commandType: CommandType.StoredProcedure);
            return 1;
        }

        public DetailsDTOTeacherCourse DetailsTeacherCourse(int Id)
        {
            var P = new DynamicParameters();
            P.Add("@TeacherCourseId", Id, DbType.Int32, direction: ParameterDirection.Input);
            var TeacherCourse = _connection.DBConnection.Query<DetailsDTOTeacherCourse>("DetailsTeacherCourse", P, commandType: CommandType.StoredProcedure).AsList();
            if (TeacherCourse.Count == 0) { return null; }
            
            return TeacherCourse.ToArray()[0];
        }

        public List<TeacherCourse> GetAllTeacherCourse()
        {
            return _connection.DBConnection.Query<TeacherCourse>("GetAllTeacherCourse").AsList();
        }

        public int InsertTeacherCourse(TeacherCourse model)
        {
            var PCheck = new DynamicParameters();
            PCheck.Add("@Id", model.CourseId, DbType.Int32, direction: ParameterDirection.Input);
            var Course = _connection.DBConnection.Query<Course>("CheckCourse", PCheck, commandType: CommandType.StoredProcedure).AsList();
            if (Course.Count == 0) { return 2; }

            PCheck = new DynamicParameters();
            PCheck.Add("@Id", model.TeacherId, DbType.Int32, direction: ParameterDirection.Input);
            var Teacher = _connection.DBConnection.Query<Teacher>("CheckTeacher", PCheck, commandType: CommandType.StoredProcedure).AsList();
            if (Teacher.Count == 0) { return 3; }

            var P = new DynamicParameters();
            P.Add("@CourseId", model.CourseId, DbType.Int32, direction: ParameterDirection.Input);
            P.Add("@TeacherId", model.TeacherId, DbType.Int32, direction: ParameterDirection.Input);

            _connection.DBConnection.ExecuteAsync("InsertTeacherCourse", P, commandType: CommandType.StoredProcedure);
            return 1;
        }

        public List<DetailsDTOTeacherCourse> SearchTeacherCourseFromCourse(string CourseName)
        {
            var P = new DynamicParameters();
            P.Add("@CourseName", CourseName, DbType.String, direction: ParameterDirection.Input);

            return _connection.DBConnection.Query<DetailsDTOTeacherCourse>("SearchTeacherCourseFromCourse", P, commandType: CommandType.StoredProcedure).AsList();
        }

        public List<DetailsDTOTeacherCourse> SearchTeacherCourseFromTeacher(string TeacherName)
        {
            var P = new DynamicParameters();
            P.Add("@TeacherName", TeacherName, DbType.String, direction: ParameterDirection.Input);

            return _connection.DBConnection.Query<DetailsDTOTeacherCourse>("SearchTeacherCourseFromTeacher", P, commandType: CommandType.StoredProcedure).AsList();
        }

        public int UpdateTeacherCourse(TeacherCourse model)
        {
            var PCheck = new DynamicParameters();
            PCheck.Add("@Id", model.TeacherCourseId, DbType.Int32, direction: ParameterDirection.Input);
            var TeacherCourse = _connection.DBConnection.Query<TeacherCourse>("CheckTeacherCourse", PCheck, commandType: CommandType.StoredProcedure).AsList();
            if (TeacherCourse.Count == 0) { return 0; }

            PCheck = new DynamicParameters();
            PCheck.Add("@Id", model.CourseId, DbType.Int32, direction: ParameterDirection.Input);
            var Course = _connection.DBConnection.Query<Course>("CheckCourse", PCheck, commandType: CommandType.StoredProcedure).AsList();
            if (Course.Count == 0) { return 2; }

            PCheck = new DynamicParameters();
            PCheck.Add("@Id", model.TeacherId, DbType.Int32, direction: ParameterDirection.Input);
            var Teacher = _connection.DBConnection.Query<Teacher>("CheckTeacher", PCheck, commandType: CommandType.StoredProcedure).AsList();
            if (Teacher.Count == 0) { return 3; }

            var P = new DynamicParameters();
            P.Add("@TeacherCourseId", model.TeacherCourseId, DbType.Int32, direction: ParameterDirection.Input);
            P.Add("@CourseId", model.CourseId, DbType.Int32, direction: ParameterDirection.Input);
            P.Add("@TeacherId", model.TeacherId, DbType.Int32, direction: ParameterDirection.Input);

            _connection.DBConnection.ExecuteAsync("UpdateTeacherCourse", P, commandType: CommandType.StoredProcedure);
            return 1;
        }
    }
}
