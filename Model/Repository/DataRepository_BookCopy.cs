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
        public BookCopy GetBookCopy(int index)
        {
            return _context.BookCopies[index];
        }

        private void ValidateBookCopy(BookCopy bookCopy)
        {
            if (_context.BookCopies.Contains(bookCopy))
                throw new DuplicatedItemException();
            if (!_context.Books.ContainsValue(bookCopy.BookDetails))
                throw new InvalidModelException();
        }

        public void AddBookCopy(BookCopy bookCopy)
        {
            ValidateBookCopy(bookCopy);
            bookCopy.Available = true;
            _context.BookCopies.Add(bookCopy);
        }

        public IEnumerable<BookCopy> GetAllBookCopies(){
            return _context.BookCopies;
        }
    }
}
