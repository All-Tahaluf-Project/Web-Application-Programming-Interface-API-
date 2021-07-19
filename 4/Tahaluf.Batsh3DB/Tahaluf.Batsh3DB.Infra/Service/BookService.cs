using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.Batsh3DB.Core.Data;
using Tahaluf.Batsh3DB.Core.Repository;
using Tahaluf.Batsh3DB.Core.Service;

namespace Tahaluf.Batsh3DB.Infra.Service
{
    public class BookService : IBookService
    {
        private readonly IBookReository _courseRepository;

        public BookService(IBookReository bookReository)
        {
            _courseRepository = bookReository;
        }
        public object AddBook(Book model)
        {
            return _courseRepository.AddBook(model);
        }

        public object DeleteBook(int Id)
        {
            return _courseRepository.DeleteBook(Id);
        }

        public List<Book> GetAllBook()
        {
            return _courseRepository.GetAllBook();
        }

        public object UpdateBook(Book model)
        {
            return _courseRepository.UpdateBook(model);
        }
    }
}
