using System;
using System.Collections.Generic;
using System.Text;
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

        public int InsertCourse(Course model)
        {
            return _repositoryCourse.InsertCourse(model);
        }

        public int UpdateCourse(Course model)
        {
            return _repositoryCourse.UpdateCourse(model);
        }
    }
}
