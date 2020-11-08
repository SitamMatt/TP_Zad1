using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Data.Events;
using Utils;
namespace Model
{
    public abstract class DataService : IDataService
    {
        private readonly DataRepository dataRepository;

        public DataService(DataRepository dataRepository)
        {
            this.dataRepository = dataRepository;
        }

        public void AddClient(string firstname, string lastname)
        {
            var client = new Client
            {
                Firstname = firstname,
                Lastname = lastname
            };
            dataRepository.AddClient(client);
        }

        public void CheckoutBook(Client client, BookCopy bookCopy)
        {
            var bookEvent = new BookCheckoutEvent{
                Date = DateTime.UtcNow,
                BookCopy = bookCopy,
                Client = client
            };
            dataRepository.AddBookEvent(bookEvent);
        }

        public void ReturnBook(BookCopy bookCopy)
        {
            var bookEvent = new BookReturnEvent{
                Date = DateTime.UtcNow,
                BookCopy = bookCopy,
            };
            dataRepository.AddBookEvent(bookEvent);
        }

        public IEnumerable<BookCopy> GetAllBookCopies(Book book)
        {
            return dataRepository.GetAllBookCopies()
            .Where(x=>x.BookDetails == book);
        }

        public IEnumerable<BookCopy> GetAllBookCopies(string isbn)
        {
            var book = dataRepository.GetBook(isbn);
            return GetAllBookCopies(book);
        }

        public IEnumerable<BookCheckoutEvent> GetLendingsBetween(DateTime from, DateTime to)
        {
            return dataRepository.GetAllBookEvents()
            .Where(x => x is BookCheckoutEvent)
            .Where(x => x.Date.IsBetween(from, to))
            .Cast<BookCheckoutEvent>();
        }

        public void GetAllBooks()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetAvailableBooks()
        {
            return dataRepository.GetAllBookCopies()
            .Where(x=>x.Available)
            .Select(x=>x.BookDetails)
            .Distinct();
        }

        public bool IsBookAvailable(Book book)
        {
            return dataRepository.GetAllBookCopies()
            .Any(x=>x.BookDetails == book && x.Available);
        }

        public bool IsBookAvailable(string isbn)
        {
            var book = dataRepository.GetBook(isbn);
            return IsBookAvailable(book);
        }

        public void GetClientsHoldingCopyFor(TimeSpan duration)
        {

        }

        public void GetAllRentalsForClient(Client client)
        {
        }
    }
}
