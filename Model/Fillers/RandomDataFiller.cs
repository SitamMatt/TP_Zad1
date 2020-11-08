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
        public RandomDataFiller(int clientsNumber )
        {
            this.clientsNumber = clientsNumber;
        }

        private int clientsNumber;
        private string[] firstNames = { "Adam", "Albert", "Aleksander", "Andrzej", "Antoni", "Bartłomiej", "Bronisław", "Dariusz",
        "Dawid", "Dominik", "Filip"};
        private string[] lastNames = { "Adamiak", "Boryszewski", "Dąbrowski", "Frączczak", "Gołąb" };
        private string[] titles = { "Duma i uprzedzenie", "Ania z Zielonego Wzgórza", "Władca Pierścieni", "Lśnienie", "Zielona Mila", "Don Kichot",
        "Przygody Tomka Sawyera", "Podróże Guliwera", "Podróż do wnętrza Ziemi", "Wichrowe Wzgórza"};

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
            Client cl = new Client(firstNames[rnd.Next(firstNames.Length)], lastNames[rnd.Next(lastNames.Length)]);
            return cl;
        }

        public Book fillBookData()
        {
            Book book = new Book(titles[rnd.Next(titles.Length)], randomDay(new DateTime(1997, 1, 1)),
                (firstNames[rnd.Next(firstNames.Length)] + " " + lastNames[rnd.Next(lastNames.Length)]), "brak opisu", rnd.Next(30, 1000));
            return book;
        }

        public BookCopy fillBookCopyData(Book book)
        {
            BookCopy copy = new BookCopy(book, randomDay(new DateTime(1996, 1, 1)));
            return copy;
        }

        public (BookCheckoutEvent, BookReturnEvent) fillBookEventData(Client client, BookCopy copy) 
        {
            BookCheckoutEvent checkout = new BookCheckoutEvent(client, copy, randomDay(new DateTime(1996, 1, 1)));
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
                String isbn = RandomString(13);
                clients.Add(fillClientData());
                katalogi.Add(isbn ,fillBookData());
                stany.Add(fillBookCopyData(katalogi[isbn]));
                stany.Add(fillBookCopyData(katalogi[isbn]));
                (BookCheckoutEvent, BookReturnEvent) events = fillBookEventData(clients[i], stany[2*i]);
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
