using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.Batsh3DB.Core.Data;

namespace Tahaluf.Batsh3DB.Core.Repository
{
    public interface IBookReository
    {
        public List<Book> GetAllBook();
        public object AddBook(Book model);
        public object UpdateBook(Book model);
        public object DeleteBook(int Id);
    }
}
