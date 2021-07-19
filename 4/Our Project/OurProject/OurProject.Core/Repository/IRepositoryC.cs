using OurProject.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OurProject.Core.Repository
{
    public interface IRepositoryC
    {
        List<C> GetAllC();
        int InsertC(C model);
        int UpdateC(C model);
        int DeleteC(int Id);
    }
}
