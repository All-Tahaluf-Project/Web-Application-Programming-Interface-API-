using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.Task3OnionArchitectoure.Core.Data.DTO;
using Tahaluf.Task3OnionArchitectoure.Core.Data.Models;
using Tahaluf.Task3OnionArchitectoure.Core.Repository;
using Tahaluf.Task3OnionArchitectoure.Core.Service;

namespace Tahaluf.Task3OnionArchitectoure.Infra.Service
{
    public class ServiceTeacher : IServiceTeacher
    {
        IRepositoryTeacher _repositoryTeacher;
        public ServiceTeacher(IRepositoryTeacher repositoryTeacher)
        {
            _repositoryTeacher = repositoryTeacher;
        }

        public int DeleteTeacher(int Id)
        {
            return _repositoryTeacher.DeleteTeacher(Id);
        }

        public DetailsDTOTeacher DetailsTeacher(int Id)
        {
            return _repositoryTeacher.DetailsTeacher(Id);
        }

        public List<Teacher> GetAllTeacher()
        {
            return _repositoryTeacher.GetAllTeacher();
        }

        public int InsertTeacher(Teacher model)
        {
            return _repositoryTeacher.InsertTeacher(model);
        }

        public int UpdateTeacher(Teacher model)
        {
            return _repositoryTeacher.UpdateTeacher(model);
        }
    }
}
