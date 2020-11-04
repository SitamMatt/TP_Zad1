using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            
        }

        public void CheckoutBook(Client client, BookCopy bookCopy)
        {
            throw new NotImplementedException();
        }

        public void ReturnBook(BookCopy bookCopy)
        {
            throw new NotImplementedException();
        }

        public void ReturnBook(BookCheckout lending)
        {
            throw new NotImplementedException();
        }

        public void GetAllBookCopies(Book book)
        {
            throw new NotImplementedException();
        }

        public void GetAllBookCopies(string isbn)
        {
            throw new NotImplementedException();
        }

        public void GetRentalsBetween(DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }

        public void GetAllBooks()
        {
            throw new NotImplementedException();
        }

        public void GetAvailableBooks()
        {
            throw new NotImplementedException();
        }

        public void IsBookAvailable(Book book)
        {
            throw new NotImplementedException();
        }

        public void IsBookAvailable(string isbn)
        {
            throw new NotImplementedException();
        }

        public void GetNearestAvailabilityDate(Book book)
        {
            throw new NotImplementedException();
        }

        public void GetNearestAvailabilityDate(string isbn)
        {
            throw new NotImplementedException();
        }

        public void GetUsersHoldingCopyFor(TimeSpan duration)
        {
            throw new NotImplementedException();
        }

        public void GetAllRentalsForClient(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
