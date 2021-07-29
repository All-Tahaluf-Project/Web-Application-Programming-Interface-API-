using Batch3.Core.Data.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tahaluf.Task3OnionArchitectoure.Core.Data.DTO;
using Tahaluf.Task3OnionArchitectoure.Core.Data.Models;

namespace Tahaluf.Task3OnionArchitectoure.Core.Repository
{
    public interface IRepositoryCourse
    {
        public int InsertCourse(Course model);
        public int UpdateCourse(Course model);
        public List<Course> GetAllCourse();
        public int DeleteCourse(int Id);
        public DetailsDTOCourse DetailsCourse(int Id);
        public List<Course> Search(CourseDTO courseDTO);

         public Task<List<Course>> GetAllCourseBook();
    }
}
