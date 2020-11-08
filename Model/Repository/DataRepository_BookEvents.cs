using System;
using System.Collections.Generic;
using System.Text;
using Model.Data.Events;

namespace Model
{
    public partial class DataRepository
    {
        public void ValidateBookEvent(BookEvent bookEvent)
        {
            #region references validation
            if (!_context.Clients.Contains(bookEvent.Client))
                throw new InvalidModelException();
            if (!_context.BookCopies.Contains(bookEvent.BookCopy))
                throw new InvalidModelException();
            #endregion
        }
        public void AddBookEvent(BookEvent bookEvent)
        {
            ValidateBookEvent(bookEvent);
            switch (bookEvent)
            {
                case BookCheckoutEvent bookCheckoutEvent:

                    if (!bookCheckoutEvent.BookCopy.Available)
                        throw new BookCheckedOutException();

                    bookCheckoutEvent.BookCopy.Available = false;
                    break;
                case BookReturnEvent bookReturnEvent:

                    if (bookReturnEvent.BookCopy.Available)
                        throw new BookNotCheckedOutException();

                    bookReturnEvent.BookCopy.Available = true;
                    break;
                default:
                    throw new UnknownEventException();
            }
            _context.Events.Add(bookEvent);
        }

        public BookEvent FindBookEvent(Func<BookEvent, bool> predicate)
        {
            throw new NotImplementedException(); // todo: implementation
        }

        //todo events should be immutable
        public void UpdateCheckout(BookEvent bookEvent, int key)
        {
            var originalCheckout = _context.Lendings[key];
            MapperHelper.Mapper.Map(bookEvent, originalCheckout);
        }

        public void DeleteCheckout(BookEvent bookEvent)
        {
            // todo remove check
            _context.Events.Remove(bookEvent);
        }

        public IEnumerable<BookEvent> GetAllBookEvents()
        {
            return _context.Events;
        }
    }
}
