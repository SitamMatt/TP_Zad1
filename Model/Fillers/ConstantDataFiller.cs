using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Model.Data;
using Model.Data.Events;

namespace Model.Fillers
{
    public class ConstantDataFiller : IDataFiller
    {
        private List<Client> clients = new List<Client>();
        private Dictionary<string, Book> books = new Dictionary<string, Book>();
        private ObservableCollection<BookCopy> bookCopies = new ObservableCollection<BookCopy>();
        private ObservableCollection<BookEvent> events = new ObservableCollection<BookEvent>();
        public ConstantDataFiller(
            List<Client> clients = null,
            Dictionary<string, Book> books = null,
            ObservableCollection<BookCopy> copies = null,
            ObservableCollection<BookEvent> events = null
            )
        {
            this.clients = clients;
            this.books = books;
            this.bookCopies = copies;
            this.events = events;
        }
        public void Fill(DataContext context)
        {
            context.Clients = clients;
            context.Books = books;
            context.BookCopies = bookCopies;
            context.Events = events;
        }
    }
}
