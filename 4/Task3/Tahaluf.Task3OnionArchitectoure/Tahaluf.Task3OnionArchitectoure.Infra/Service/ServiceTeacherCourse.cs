using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.Task3OnionArchitectoure.Core.Data.DTO;
using Tahaluf.Task3OnionArchitectoure.Core.Data.Models;
using Tahaluf.Task3OnionArchitectoure.Core.Repository;
using Tahaluf.Task3OnionArchitectoure.Core.Service;

namespace Tahaluf.Task3OnionArchitectoure.Infra.Service
{
    public class ServiceTeacherCourse : IServiceTeacherCourse
    {
        IRepositoryTeacherCourse _repositoryTeacherCourse;
        public ServiceTeacherCourse(IRepositoryTeacherCourse repositoryTeacherCourse)
        {
            _repositoryTeacherCourse = repositoryTeacherCourse;
        }
        public int DeleteTeacherCourse(int Id)
        {
            return _repositoryTeacherCourse.DeleteTeacherCourse(Id);
        }

        public DetailsDTOTeacherCourse DetailsTeacherCourse(int Id)
        {
            return _repositoryTeacherCourse.DetailsTeacherCourse(Id);
        }

        public List<DetailsDTOTeacherCourse> GetAllTeacherCourse()
        {
            return _repositoryTeacherCourse.GetAllTeacherCourse();
        }

        public int InsertTeacherCourse(TeacherCourse model)
        {
            return _repositoryTeacherCourse.InsertTeacherCourse(model);
        }

        public List<DetailsDTOTeacherCourse> SearchTeacherCourseFromCourse(string CourseName)
        {
           return _repositoryTeacherCourse.SearchTeacherCourseFromCourse(CourseName);
        }

        public List<DetailsDTOTeacherCourse> SearchTeacherCourseFromTeacher(string TeacherName)
        {
            return _repositoryTeacherCourse.SearchTeacherCourseFromTeacher(TeacherName);
        }

        public int UpdateTeacherCourse(TeacherCourse model)
        {
            return _repositoryTeacherCourse.UpdateTeacherCourse(model);
        }
    }
}
