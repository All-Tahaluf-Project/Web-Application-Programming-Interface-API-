using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.Task3OnionArchitectoure.Core.Data.DTO;
using Tahaluf.Task3OnionArchitectoure.Core.Data.Models;

namespace Tahaluf.Task3OnionArchitectoure.Core.Service
{
    public interface IServiceBook
    {
        public int InsertBook(Book model);
        public int UpdateBook(Book model);
        public List<Book> GetAllBook();
        public int DeleteBook(int Id);
        public DetailsDTOBook DetailsBook(int Id);
    }
}
