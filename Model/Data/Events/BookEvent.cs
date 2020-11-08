
using System;

namespace Model.Data.Events
{
    public abstract class BookEvent
    {
        protected BookEvent(Client client, BookCopy bookCopy, DateTime date)
        {
            this.Client = client;
            this.BookCopy = bookCopy;
            this.Date = date;
        }

        public Client Client { get; private set; }
        public BookCopy BookCopy { get; private set; }
        public DateTime Date { get; }
    }
}
