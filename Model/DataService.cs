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
            var client = new Client
            {
                Firstname = firstname,
                Lastname = lastname
            };
            dataRepository.AddClient(client);
        }

        public void CheckoutBook(Client client, BookCopy bookCopy)
        {
            var clientExists = dataRepository.GetClient(client.ID);
            var copyExists = dataRepository.GetBookCopy(bookCopy.CopyID);
            if (clientExists != null && copyExists != null && copyExists.Available)
            {
                var checkout = new BookCheckout
                {
                    BookCopy = copyExists,
                    Client = clientExists,
                    CheckoutDate = DateTime.Now
                };
                dataRepository.AddCheckout(checkout);
            }
        }

        public void ReturnBook(BookCopy bookCopy)
        {
            var checkout = dataRepository.FindBookCheckout(x => x.BookCopy.CopyID == bookCopy.CopyID);
            if (!checkout.BookCopy.Available)
            {

            }
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
