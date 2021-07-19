using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
