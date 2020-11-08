
using System;
using Model;

namespace Model.Data.Events
{
    public abstract class BookEvent
    {
        public Client Client { get; set; }
        public BookCopy BookCopy { get; set; }
        public DateTime Date { get; set; }
    }
}
