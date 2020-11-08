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
            return _context.BookCopies.First(x => x.CopyID == id);
        }

        private void ValidateBookCopy(BookCopy bookCopy)
        {
            if (_context.BookCopies.Contains(bookCopy))
                throw new DuplicatedItemException();
            if (!_context.Books.ContainsValue(bookCopy.BookDetails))
                throw new InvalidModelException();
            if (_context.BookCopies.Any(x => x.CopyID == bookCopy.CopyID))
                throw new DuplicatedItemException();
        }

        public void AddBookCopy(BookCopy bookCopy)
        {
            ValidateBookCopy(bookCopy);
            //todo consider validating it
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
