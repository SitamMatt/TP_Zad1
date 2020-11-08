using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Model.Data;
using Model.Data.Events;
using Model.Fillers;
using Utils;

namespace Model.Tests
{
    public class ContextBuilder : IDataFiller
    {
        private List<Client> Clients = new List<Client>();
        private Dictionary<string, Book> Books = new Dictionary<string, Book>();
        private ObservableCollection<BookCopy> BookCopies = new ObservableCollection<BookCopy>();
        public ObservableCollection<BookEvent> Events = new ObservableCollection<BookEvent>();

        public void Fill(DataContext context)
        {
            context.Events = Events;
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
            bookCopy.With(x => x.BookDetails, book);
            bookCopy.Available = true;
            BookCopies.Add(bookCopy);
            return this;
        }

        public ContextBuilder AddReturnEvent(Client client, BookCopy book){
            var bookEvent = new BookReturnEvent(client, book, DateTime.Now);
            Events.Add(bookEvent);
            return this;
        }

        public ContextBuilder AddCheckoutEvent(Client client, BookCopy book){
            var bookEvent = new BookCheckoutEvent(client, book, DateTime.Now);
            book.Available = false;
            Events.Add(bookEvent);
            return this;
        }
        public ContextBuilder AddBookEvent(BookEvent bookEvent){
            Events.Add(bookEvent);
            return this;
        }
    }
}
