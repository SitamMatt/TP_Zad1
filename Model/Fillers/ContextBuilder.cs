using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Model.Fillers
{
    public class ContextBuilder : IDataFiller
    {
        private List<Client> Clients = new List<Client>();
        private Dictionary<string, Book> Books = new Dictionary<string, Book>();
        private ObservableCollection<BookCheckout> Lendings = new ObservableCollection<BookCheckout>();
        private ObservableCollection<BookCopy> BookCopies = new ObservableCollection<BookCopy>();
        public void Fill(DataContext context)
        {
            context.Lendings = Lendings;
            context.BookCopies = BookCopies;
            context.Clients = Clients;
            context.Books = Books;
        }

        public ContextBuilder AddClient(Client client)
        {
            Clients.Add(client);
            return this;
        }

        public ContextBuilder AddBook(string key, Book book)
        {
            Books[key] = book;
            return this;
        }

        public ContextBuilder AddBookCopy(string bookKey, BookCopy bookCopy)
        {
            var book = Books[bookKey];
            bookCopy.BookDetails = book;
            BookCopies.Add(bookCopy);
            return this;
        }

        public ContextBuilder AddBookCheckout(int copyId, int clientId, BookCheckout bookCheckout)
        {
            var copy = BookCopies.First(x => x.CopyID == copyId);
            var client = Clients.First(x => x.ID == clientId);
            bookCheckout.BookCopy = copy;
            bookCheckout.Client = client;
            Lendings.Add(bookCheckout);
            return this;
        }
    }
}
