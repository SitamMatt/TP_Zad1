using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Data;

namespace Model.Repository
{
    public partial class DataRepository
    {
        private void ValidateBook(String isbn)
        {
            if (_context.Books.ContainsKey(isbn))
                throw new DuplicatedItemException();
           // TODO: zastanowić się w jakich jeszcze przypadkach rzucać wyjątek
        }
        public void AddBook(String isbn, Book book)
        {
            ValidateBook(isbn);
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

        public IEnumerable<Book> GetBooksAll()
        {
            return _context.Books.Values;
        }

    }
}
