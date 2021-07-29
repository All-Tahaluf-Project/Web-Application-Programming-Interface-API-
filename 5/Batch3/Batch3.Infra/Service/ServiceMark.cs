using Batch3.Core.Data.DTO;
using Batch3.Core.Repository;
using Batch3.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Batch3.Infra.Service
{
    public class ServiceMark : IServiceMark
    {
        IRepositoryMark _repositoryMark;
        public ServiceMark(IRepositoryMark repositoryMark)
        {
            _repositoryMark = repositoryMark;
        }
        public object AboveAVG(int Id)
        {
            return _repositoryMark.AboveAVG(Id);
        }

        public object AVG(int Id)
        {
            return _repositoryMark.AVG(Id);
        }

        public List<DetailsDTOMark> GetAllMarks(int Id)
        {
            return _repositoryMark.GetAllMarks(Id);
        }

        public object BellowAVG(int Id)
        {
            return _repositoryMark.BellowAVG(Id);
        }

        public object Sum(int Id)
        {
            return _repositoryMark.Sum(Id);
        }

        public object CountMarks(int Id)
        {
            return _repositoryMark.CountMarks(Id);
        }
    }
}
