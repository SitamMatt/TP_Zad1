using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Repository
{
    public partial class DataRepository
    {
        public void ValidateBookCheckout(BookCheckout checkout)
        {
            if (_context.Lendings.Contains(checkout))
                throw new DuplicatedItemException();
            if (GetClientById(checkout.Client.ID) == null)
                throw new InvalidOperationException(); 
            if (GetBookCopy(checkout.BookCopy.CopyID) == null)
                throw new InvalidOperationException();
            if ((checkout.ReturnDate != null) & (checkout.BookCopy.Available != true))
                throw new InvalidOperationException(); //todo: jakie wyjatki????
            //todo: kolejne metody walidacji
        }
        public void AddCheckout(BookCheckout checkout)
        {
            _context.Lendings.Add(checkout);
        }

        public BookCheckout FindBookCheckout(Func<BookCheckout, bool> predicate)
        {
            throw new NotImplementedException(); // todo: implementation
        }

        public void UpdateCheckout(BookCheckout checkout, int key)
        {
            var originalCheckout = _context.Lendings[key];
            MapperHelper.Mapper.Map(checkout, originalCheckout);
        }

        public void DeleteCheckout(BookCheckout checkout)
        {
            _context.Lendings.Remove(checkout);
        }

        public IEnumerable<BookCheckout> GetAllBookCheckouts()
        {
            return _context.Lendings;
        }
    }
}
