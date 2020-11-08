using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Data;

namespace Model.Repository
{
    public partial class DataRepository
    {
        public BookCopy GetBookCopy(int id)
        {
            return _context.BookCopies[id];
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

        public void UpdateBookCopy(int id, BookCopy bookCopy)
        {
            //todo prevent id change
            //todo observablecollection not triggered
            var original = GetBookCopy(id);
            ValidateBookCopy(original);
            MapperHelper.Mapper.Map(bookCopy, original);
        }

        public void DeleteBookCopy(BookCopy bookCopy)
        {
            _context.BookCopies.Remove(bookCopy);
        }

        public IEnumerable<BookCopy> GetAllBookCopies(){
            return _context.BookCopies;
        }
    }
}
