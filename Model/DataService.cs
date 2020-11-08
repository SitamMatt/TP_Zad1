using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Data;
using Model.Data.Events;
using Model.Exceptions;
using Model.Repository;
using Utils;
namespace Model
{
    public class DataService
    {
        private readonly IDataRepository dataRepository;

        public DataService(IDataRepository dataRepository)
        {
            this.dataRepository = dataRepository;
        }

        public void AddClient(string firstname, string lastname)
        {
            var client = new Client(
                firstname,
                lastname);
            dataRepository.AddClient(client);
        }

        public void CheckoutBook(Client client, BookCopy bookCopy)
        {
            var bookEvent = new BookCheckoutEvent(
                client,
                bookCopy,
                DateTime.UtcNow
            );
            dataRepository.AddBookEvent(bookEvent);
        }

        public void ReturnBook(BookCopy bookCopy)
        {
            var checkoutEvenet = dataRepository.GetAllBookEvents()
            .Where(x => x is BookCheckoutEvent && x.BookCopy == bookCopy)
            .OrderByDescending(x => x.Date)
            .FirstOrDefault();
            var bookEvent = new BookReturnEvent
            (
                checkoutEvenet.Client,
                bookCopy,
                DateTime.UtcNow
            );
            dataRepository.AddBookEvent(bookEvent);
        }

        public IEnumerable<BookCopy> GetAllBookCopies(Book book)
        {
            return dataRepository.GetAllBookCopies()
            .Where(x => x.BookDetails == book);
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

        public IEnumerable<Book> GetAllBooks()
        {
            return dataRepository.GetAllBooks();
        }

        public IEnumerable<Book> GetAvailableBooks()
        {
            return dataRepository.GetAllBookCopies()
            .Where(x => x.Available)
            .Select(x => x.BookDetails)
            .Distinct();
        }

        public bool IsBookAvailable(Book book)
        {
            return dataRepository.GetAllBookCopies()
            .Any(x => x.BookDetails == book && x.Available);
        }

        public bool IsBookAvailable(string isbn)
        {
            var book = dataRepository.GetBook(isbn);
            return IsBookAvailable(book);
        }

        public IEnumerable<BookCopy> GetAllCopiesCheckedOutByClient(Client client)
        {
            return dataRepository.GetAllBookEvents()
            .Where(x=>x is BookCheckoutEvent && x.Client == client)
            .Select(x=>x.BookCopy)
            .Distinct();
        }

        public void AddNewBookCopy(string isbn, DateTime purchaseDate){
            var book = dataRepository.GetBook(isbn);
            if(book == null)
            throw new BookNotExistException();
            var bookCopy = new BookCopy(
                book,
                purchaseDate);
            dataRepository.AddBookCopy(bookCopy);
        }
    }
}
