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
        private List<Client> clients;
        private Dictionary<string, Book> books;
        private ObservableCollection<BookCopy> bookCopies;
        private ObservableCollection<BookEvent> events;
        public ConstantDataFiller(
            List<Client> clients,
            Dictionary<string, Book> books,
            ObservableCollection<BookCopy> copies,
            ObservableCollection<BookEvent> events
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
