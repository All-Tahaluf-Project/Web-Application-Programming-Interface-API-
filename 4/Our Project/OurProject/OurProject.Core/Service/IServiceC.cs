using OurProject.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OurProject.Core.Service
{
    public interface IServiceC
    {
        List<C> GetAllC();
        int InsertC(C model);
        int UpdateC(C model);
        int DeleteC(int Id);
    }
}
