using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Model.Data;
using Model.Data.Events;

namespace Model.Fillers
{
    public class RandomDataFiller : IDataFiller
    {
        public RandomDataFiller(int clientsNumber, int stringLen, int books, int bookCopies, DateTime date)
        {
            this.clientsNumber = clientsNumber;
            this.ranStrLen = stringLen;
            this.booksNumber = books;
            this.copiesPerBookNumber = bookCopies;
            this.startDate = date;
        }

        private int clientsNumber;
        private int ranStrLen;
        private int booksNumber;
        private int copiesPerBookNumber;
        private int checkoutPerUserNumber;
        private DateTime startDate;

        private Random rnd = new Random();

        public DateTime randomDay(DateTime startDay)
        {
            int range = (DateTime.Today - startDay).Days;
            return startDay.AddDays(rnd.Next(range));
        }

        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[rnd.Next(s.Length)]).ToArray());
        }

        public Client fillClientData()
        {
            Client cl = new Client(RandomString(ranStrLen), RandomString(ranStrLen));
            return cl;
        }

        public Book fillBookData()
        {
            Book book = new Book(RandomString(ranStrLen), randomDay(startDate),
                (RandomString(ranStrLen) + " " + RandomString(ranStrLen)), RandomString(ranStrLen), rnd.Next(30, 1000));
            return book;
        }

        public BookCopy fillBookCopyData(Book book)
        {
            BookCopy copy = new BookCopy(book, randomDay(startDate));
            return copy;
        }

        public (BookCheckoutEvent, BookReturnEvent) fillBookEventData(Client client, BookCopy copy) 
        {
            BookCheckoutEvent checkout = new BookCheckoutEvent(client, copy, randomDay(startDate));
            BookReturnEvent ret = new BookReturnEvent(client, copy, randomDay(checkout.Date));
            return (checkout, ret);
        }

        public void Fill(DataContext context)
        {
            var clients = new List<Client>();
            var katalogi = new Dictionary<string, Book>();
            var stany = new ObservableCollection<BookCopy>();
            var zdarzenia = new ObservableCollection<BookEvent>();
            for (int i=0; i<clientsNumber; i++)
            {
                clients.Add(fillClientData());
            }

            for (int i =0; i<booksNumber; i++)
            {
                String isbn = RandomString(13);
                katalogi.Add(isbn, fillBookData());
                for (int j = 0; j<copiesPerBookNumber; j++)
                {
                    stany.Add(fillBookCopyData(katalogi[isbn]));
                }
                (BookCheckoutEvent, BookReturnEvent) events = fillBookEventData(clients[i], stany[2 * i]);
                zdarzenia.Add(events.Item1);
                zdarzenia.Add(events.Item2);
            }

            context.Clients = clients;
            context.Books = katalogi;
            context.BookCopies = stany;
            context.Events = zdarzenia;
        }
    }
}
