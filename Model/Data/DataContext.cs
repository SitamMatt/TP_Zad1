using System.Collections.Generic;
using System.Collections.ObjectModel;
using Model.Data.Events;

namespace Model.Data
{
    public class DataContext
    {
        public List<Client> Clients { get; }
        public Dictionary<string, Book> Books { get; }
        public ObservableCollection<BookEvent> Events { get; }
        public ObservableCollection<BookCopy> BookCopies { get; }
    }
}
