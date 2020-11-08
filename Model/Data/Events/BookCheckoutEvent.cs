using System;
using Model;

namespace Model.Data.Events
{
    public class BookCheckoutEvent : BookEvent
    {
        public BookCheckoutEvent(Client client, BookCopy bookCopy, DateTime date) : base(client, bookCopy, date)
        {
        }
    }
}