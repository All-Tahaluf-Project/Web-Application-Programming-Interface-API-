using OurProject.Core.Data;
using OurProject.Core.Repository;
using OurProject.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace OurProject.Infra.Service
{
    public class ServiceC : IServiceC
    {
        IRepositoryC _repositoryC;
        public ServiceC(IRepositoryC repositoryC)
        {
            _repositoryC = repositoryC;
        }
        public int DeleteC(int Id)
        {
          return  _repositoryC.DeleteC(Id);
        }

        public List<C> GetAllC()
        {
            return _repositoryC.GetAllC();
        }

        public int InsertC(C model)
        {
            return _repositoryC.InsertC(model);
        }

        public int UpdateC(C model)
        {
            return _repositoryC.UpdateC(model);
        }
    }
}
