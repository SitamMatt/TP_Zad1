using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Model.Data;

namespace Model.Fillers
{
    public class ConstantDataFiller : IDataFiller
    {
        public void Fill(DataContext context)
        {
            var clients = new List<Client>();
            var wykaz1 = new Client
            {
                ID = 1,
                Firstname = "Jan",
                Lastname = "Kowalski",
            };
            clients.Add(wykaz1);
            var wykaz2 = new Client
            {
                ID = 2,
                Firstname = "Jarosław",
                Lastname = "Nowak"
            };
            clients.Add(wykaz2);
            var katalogi = new Dictionary<string, Book>();
            var katalog1 = new Book
            {
                Author = "Michał Milowicz",
                ReleaseDate = DateTime.Parse("1999-02-01"),
                PageCount = 50,
                Description = "Świetna książka polecam"
            };
            katalogi["fff-aahh"] = katalog1;
            var katalog2 = new Book
            {
                Author = "Jan Marczewski",
                ReleaseDate = DateTime.Parse("2001-06-09"),
                PageCount = 255,
                Description = "Super"
            };
            katalogi["hhshasdad"] = katalog2;
            var stany = new ObservableCollection<BookCopy>();
            var opis1 = new BookCopy
            {
                CopyID = 1,
                PurchaseDate = DateTime.Parse("2004-04-07")
            };
            stany.Add(opis1);
            var opis2 = new BookCopy
            {
                CopyID = 2,
                PurchaseDate = DateTime.Parse("2005-09-01")
            };
            stany.Add(opis2);
            var opis3 = new BookCopy
            {
                CopyID = 3,
                PurchaseDate = DateTime.Parse("2006-08-01")
            };
            stany.Add(opis3);
            var zdarzenia = new ObservableCollection<BookCheckout>();
            var zdarz1 = new BookCheckout
            {
                CheckoutDate = DateTime.Parse("2018-04-01"),
                ReturnDate = DateTime.Parse("2018-06-01"),
                BookCopy = opis1,
                Client = wykaz1
            };
            zdarzenia.Add(zdarz1);
            var zdarz2 = new BookCheckout
            {
                CheckoutDate = DateTime.Parse("2020-08-01"),
                BookCopy = opis3,
                Client = wykaz2
            };
            zdarzenia.Add(zdarz2);
            context.Clients = clients;
            context.Books = katalogi;
            context.BookCopies = stany;
            context.Lendings = zdarzenia;
        }
    }
}
