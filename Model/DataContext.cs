using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Model
{
    public class DataContext
    {
        public List<Client> Clients { get; set; }
        public Dictionary<string, Book> Books {get;set;}
        public ObservableCollection<BookCheckout> Lendings { get; set; }  
        public ObservableCollection<BookCopy> BookCopies { get; set; }
    }
}
