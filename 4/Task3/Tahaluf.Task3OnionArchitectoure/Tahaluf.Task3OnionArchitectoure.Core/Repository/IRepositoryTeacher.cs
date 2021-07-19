using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.Task3OnionArchitectoure.Core.Data.DTO;
using Tahaluf.Task3OnionArchitectoure.Core.Data.Models;

namespace Tahaluf.Task3OnionArchitectoure.Core.Repository
{
    public interface IRepositoryTeacher
    {
        public int InsertTeacher(Teacher model);
        public int UpdateTeacher(Teacher model);
        public List<Teacher> GetAllTeacher();
        public int DeleteTeacher(int Id);
        public DetailsDTOTeacher DetailsTeacher(int Id);
    }
}
