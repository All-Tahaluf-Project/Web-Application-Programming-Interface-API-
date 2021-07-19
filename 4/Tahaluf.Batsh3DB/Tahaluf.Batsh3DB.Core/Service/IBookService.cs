using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.Batsh3DB.Core.Data;

namespace Tahaluf.Batsh3DB.Core.Service
{
    public interface IBookService
    {
        public List<Book> GetAllBook();
        public object AddBook(Book model);
        public object UpdateBook(Book model);
        public object DeleteBook(int Id);
    }
}
