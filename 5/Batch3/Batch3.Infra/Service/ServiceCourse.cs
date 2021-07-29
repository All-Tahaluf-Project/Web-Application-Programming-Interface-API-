using Batch3.Core.Data.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tahaluf.Task3OnionArchitectoure.Core.Data.DTO;
using Tahaluf.Task3OnionArchitectoure.Core.Data.Models;
using Tahaluf.Task3OnionArchitectoure.Core.Repository;
using Tahaluf.Task3OnionArchitectoure.Core.Service;

namespace Tahaluf.Task3OnionArchitectoure.Infra.Service
{
    public class ServiceCourse : IServiceCourse
    {
        IRepositoryCourse _repositoryCourse;
        public ServiceCourse(IRepositoryCourse repositoryCourse)
        {
            _repositoryCourse = repositoryCourse;
        }
        public int DeleteCourse(int Id)
        {
           return _repositoryCourse.DeleteCourse(Id);
        }

        public DetailsDTOCourse DetailsCourse(int Id)
        {
           return _repositoryCourse.DetailsCourse(Id);
        }

        public List<Course> GetAllCourse()
        {
            return _repositoryCourse.GetAllCourse();
        }

        public async Task<List<Course>> GetAllCourseBook()
        {
            return await _repositoryCourse.GetAllCourseBook();
        }

        public int InsertCourse(Course model)
        {
            return _repositoryCourse.InsertCourse(model);
        }

        public List<Course> Search(CourseDTO courseDTO)
        {
           return _repositoryCourse.Search(courseDTO);
        }

        public int UpdateCourse(Course model)
        {
            return _repositoryCourse.UpdateCourse(model);
        }
    }
}
