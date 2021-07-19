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
    public class RepositoryTeacher : IRepositoryTeacher
    {
        IConnection _connection;
        public RepositoryTeacher(IConnection connection)
        {
            _connection = connection;
        }
        public int DeleteTeacher(int Id)
        {
            var PCheck = new DynamicParameters();
            PCheck.Add("@Id", Id, DbType.Int32, direction: ParameterDirection.Input);
            var Teacher = _connection.DBConnection.Query<Teacher>("CheckTeacher", PCheck, commandType: CommandType.StoredProcedure).AsList();
            if (Teacher.Count == 0) { return 0; }

            PCheck = new DynamicParameters();
            PCheck.Add("@TeacherId", Id, DbType.Int32, direction: ParameterDirection.Input);
            var TeacherCourse = _connection.DBConnection.Query<DetailsDTOTeacherCourse>("DetailsTeacherCourseForTeacher", PCheck, commandType: CommandType.StoredProcedure).AsList();
            if(TeacherCourse.Count != 0) { return 2; }

            var P = new DynamicParameters();
            P.Add("@TeacherId", Id, DbType.Int32, direction: ParameterDirection.Input);

            _connection.DBConnection.ExecuteAsync("DeleteTeacher", P, commandType: CommandType.StoredProcedure);
            return 1;
        }

        public DetailsDTOTeacher DetailsTeacher(int Id)
        {
            var P = new DynamicParameters();
            P.Add("@TeacherId", Id, DbType.Int32, direction: ParameterDirection.Input);
            var Teacher = _connection.DBConnection.Query<DetailsDTOTeacher>("DetailsTeacher", P, commandType: CommandType.StoredProcedure).AsList();
            if (Teacher.Count == 0) { return null; }

            P = new DynamicParameters();
            P.Add("@TeacherId", Id, DbType.Int32, direction: ParameterDirection.Input);
            var TeacherCourse = _connection.DBConnection.Query<DetailsDTOTeacherCourse>("DetailsTeacherCourseForTeacher", P, commandType: CommandType.StoredProcedure).AsList();
            Teacher.ToArray()[0].TeacherCourse = TeacherCourse;

            return Teacher.ToArray()[0];
        }

        public List<Teacher> GetAllTeacher()
        {
            return _connection.DBConnection.Query<Teacher>("GetAllTeacher").AsList();
        }

        public int InsertTeacher(Teacher model)
        {
            var P = new DynamicParameters();
            P.Add("@TeacherName", model.TeacherName, DbType.String, direction: ParameterDirection.Input);

            _connection.DBConnection.ExecuteAsync("InsertTeacher", P, commandType: CommandType.StoredProcedure);
            return 1;
        }

        public int UpdateTeacher(Teacher model)
        {
            var P = new DynamicParameters();
            P.Add("@Id", model.TeacherId, DbType.Int32, direction: ParameterDirection.Input);
            var Teacher = _connection.DBConnection.Query<DetailsDTOTeacher>("CheckTeacher", P, commandType: CommandType.StoredProcedure).AsList();
            if (Teacher.Count == 0) { return 0; }

            P= new DynamicParameters();
            P.Add("@TeacherId", model.TeacherId, DbType.Int32, direction: ParameterDirection.Input);
            P.Add("@TeacherName", model.TeacherName, DbType.String, direction: ParameterDirection.Input);

            _connection.DBConnection.ExecuteAsync("UpdateTeacher", P, commandType: CommandType.StoredProcedure);
            return 1;
        }
    }
}
