using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Model.Data.Events;

namespace Model.Data
{
    public class DataContext
    {
        public List<Client> Clients { get; set; }
        public Dictionary<string, Book> Books { get; set; }
        // todo remove when no refs
        public ObservableCollection<BookCheckout> Lendings { get; set; }
        public ObservableCollection<BookEvent> Events { get; set; }

        public ObservableCollection<BookCopy> BookCopies { get; set; }
    }
}
