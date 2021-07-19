using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.Task3OnionArchitectoure.Core.Data.DTO;
using Tahaluf.Task3OnionArchitectoure.Core.Data.Models;
using Tahaluf.Task3OnionArchitectoure.Core.Repository;
using Tahaluf.Task3OnionArchitectoure.Core.Service;

namespace Tahaluf.Task3OnionArchitectoure.Infra.Service
{
    public class ServiceBook : IServiceBook
    {
        IRepositoryBook _repositoryBook;
        public ServiceBook(IRepositoryBook repositoryBook)
        {
            _repositoryBook = repositoryBook;
        }
        public int DeleteBook(int Id)
        {
            return _repositoryBook.DeleteBook(Id);
        }

        public DetailsDTOBook DetailsBook(int Id)
        {
            return _repositoryBook.DetailsBook(Id);
        }

        public List<Book> GetAllBook()
        {
            return _repositoryBook.GetAllBook();
        }

        public int InsertBook(Book model)
        {
            return _repositoryBook.InsertBook(model);
        }

        public int UpdateBook(Book model)
        {
            return _repositoryBook.UpdateBook(model);
        }
    }
}
