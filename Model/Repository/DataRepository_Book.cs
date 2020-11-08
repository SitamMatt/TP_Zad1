using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Data;
using Model.Exceptions;

namespace Model.Repository
{
    public partial class DataRepository
    {
        public void AddBook(String isbn, Book book)
        {
            if (_context.Books.ContainsKey(isbn))
                throw new BookAlreadyExistException();
            _context.Books.Add(isbn, book);
        }

        public Book GetBook(String isbn)
        {
            return _context.Books[isbn];
        }

        public void DeleteBook(String isbn)
        {
            _context.Books.Remove(isbn);
        }

        public void UpdateBook(String isbn, Book book)
        {
            var originalBook = _context.Books[isbn];
            MapperHelper.Mapper.Map(book, originalBook);
        }

        public IEnumerable<KeyValuePair<string, Book>> GetAllBooks()
        {
            return _context.Books;
        }
    }
}
