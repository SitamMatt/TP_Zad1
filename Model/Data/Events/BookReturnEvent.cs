using System;
using Model;

namespace Model.Data.Events
{
    public class BookReturnEvent : BookEvent
    {
        public BookReturnEvent(Client client, BookCopy bookCopy, DateTime date) : base(client, bookCopy, date)
        {
        }
    }
}