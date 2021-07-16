using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.Batsh3DB.Core.Data;
using Tahaluf.Batsh3DB.Core.Repository;
using Tahaluf.Batsh3DB.Core.Service;

namespace Tahaluf.Batsh3DB.Infra.Service
{
    public class CourseSerivce : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        public CourseSerivce(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public object AddCourse(Course model)
        {
            return _courseRepository.AddCourse(model);
        }

        public object DeleteCourse(int Id)
        {
            return _courseRepository.DeleteCourse(Id);
        }

        public List<Course> GetAllCourse()
        {
            return _courseRepository.GetAllCourse();
        }

        public object UpdateCourse(Course model)
        {
            return _courseRepository.UpdateCourse(model);
        }
    }
}
