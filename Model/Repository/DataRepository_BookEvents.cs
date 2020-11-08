using System;
using System.Collections.Generic;
using System.Text;
using Model.Data.Events;
using Model.Exceptions;

namespace Model.Repository
{
    public partial class DataRepository
    {
        private void ValidateBookEvent(BookEvent bookEvent)
        {
            if (!_context.Clients.Contains(bookEvent.Client))
                throw new InvalidModelException();
            if (!_context.BookCopies.Contains(bookEvent.BookCopy))
                throw new InvalidModelException();
        }

        public BookEvent GetBookEvent(int index){
            return _context.Events[index];
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
