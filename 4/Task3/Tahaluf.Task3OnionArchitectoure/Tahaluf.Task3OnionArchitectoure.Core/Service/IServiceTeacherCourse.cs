using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.Task3OnionArchitectoure.Core.Data.DTO;
using Tahaluf.Task3OnionArchitectoure.Core.Data.Models;

namespace Tahaluf.Task3OnionArchitectoure.Core.Service
{
    public interface IServiceTeacherCourse
    {
        public int InsertTeacherCourse(TeacherCourse model);
        public int UpdateTeacherCourse(TeacherCourse model);
        public List<DetailsDTOTeacherCourse> GetAllTeacherCourse();
        public int DeleteTeacherCourse(int Id);
        public DetailsDTOTeacherCourse DetailsTeacherCourse(int Id);
        public List<DetailsDTOTeacherCourse> SearchTeacherCourseFromCourse(string CourseName);
        public List<DetailsDTOTeacherCourse> SearchTeacherCourseFromTeacher(string TeacherName);
    }
}
