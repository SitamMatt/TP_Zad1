using Model.Data;
using Model.Data.Events;
using Model.Fillers;
using Model.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Utils;

namespace Model.Tests
{
    public class DataRepository_BookEventTests
    {
        #region test data

        private Book book1;
        private BookCopy copy1;
        private Client client1;
        private BookEvent event1;
        private BookEvent event2;
        private BookEvent event3;
        private BookEvent event4;
        private List<BookEvent> events;

        public DataRepository_BookEventTests()
        {
            book1 = new Book(
                "Taniec z gwiazdami",
                DateTime.Parse("2005-08-25"),
                "Jan",
                "Opis",
                4);

            copy1 = new BookCopy(
                book1,
                DateTime.Now);

            client1 = new Client(
                "Jacek",
                "Hyży");

            event1 = new BookCheckoutEvent(
                client1,
                copy1,
                DateTime.Now);
            event1 = new BookReturnEvent(
                client1,
                copy1,
                DateTime.Now);
            event1 = new BookCheckoutEvent(
                client1.Clone(),
                copy1.Clone(),
                DateTime.Now);
            event1 = new BookCheckoutEvent(
                client1.Clone(),
                copy1.Clone(),
                DateTime.Now);

            events = new List<BookEvent>(){
                event1, event2, event3, event4
            };
        }

        #endregion test data

        [Test]
        public void AddBookEvent_NullishClientShouldThrow()
        {
            var context = new DataContext();
            var builder = new ContextBuilder()
            .AddBook("isbn-666", book1.Clone())
            .AddBookCopy("isbn-666", copy1);
            var repository = new DataRepository(builder);
            var bookEvent = new BookCheckoutEvent(null, copy1, DateTime.Now);
            Assert.Throws<InvalidModelException>(() => repository.AddBookEvent(bookEvent));
            // adding book event with client out of repository
            var bookEvent2 = bookEvent.CloneWith(x => x.Client, client1);
            Assert.Throws<InvalidModelException>(() => repository.AddBookEvent(bookEvent2));
        }

        [Test]
        public void AddBookEvent_NullishBookCopyShouldThrow()
        {
            var context = new DataContext();
            var builder = new ContextBuilder()
            .AddBook("isbn-666", book1.Clone())
            .AddClient(client1);
            var repository = new DataRepository(builder);
            var bookEvent = new BookCheckoutEvent(client1, null, DateTime.Now);
            Assert.Throws<InvalidModelException>(() => repository.AddBookEvent(bookEvent));
            // adding book event with book copy out of repository
            var bookEvent2 = bookEvent.CloneWith(x => x.BookCopy, copy1);
            Assert.Throws<InvalidModelException>(() => repository.AddBookEvent(bookEvent));
        }

        [Test]
        public void AddBookEvent_BookAlreadyLendShouldThrow()
        {
            var context = new DataContext();
            var builder = new ContextBuilder()
            .AddBook("isbn-666", book1.Clone())
            .AddClient(client1)
            .AddBookCopy("isbn-666", copy1)
            .AddCheckoutEvent(client1, copy1);
            var repository = new DataRepository(builder);
            var bookEvent = new BookCheckoutEvent(client1, copy1, DateTime.Now);
            Assert.Throws<BookCheckedOutException>(() => repository.AddBookEvent(bookEvent));
        }

        [Test]
        public void AddBookEvent_BookCopyShouldBeNotAvailable()
        {
            var context = new DataContext();
            var builder = new ContextBuilder()
            .AddBook("isbn-666", book1.Clone())
            .AddClient(client1)
            .AddBookCopy("isbn-666", copy1);
            var repository = new DataRepository(builder);
            Assert.AreEqual(true, copy1.Available);
            var bookEvent = new BookCheckoutEvent(client1, copy1, DateTime.Now);
            repository.AddBookEvent(bookEvent);
            Assert.AreEqual(false, copy1.Available);
        }

        [Test]
        public void AddBookEvent_BookNotCheckedOutShouldThrow()
        {
            var context = new DataContext();
            var builder = new ContextBuilder()
            .AddBook("isbn-666", book1.Clone())
            .AddClient(client1)
            .AddBookCopy("isbn-666", copy1);
            var repository = new DataRepository(builder);
            var bookEvent = new BookReturnEvent(client1, copy1, DateTime.Now);
            Assert.Throws<BookNotCheckedOutException>(() => repository.AddBookEvent(bookEvent));
        }

        [Test]
        public void AddBookEvent_BookCopyShouldBeAvailable()
        {
            var context = new DataContext();
            var builder = new ContextBuilder()
            .AddBook("isbn-666", book1.Clone())
            .AddClient(client1)
            .AddBookCopy("isbn-666", copy1);
            var repository = new DataRepository(builder);
            Assert.AreEqual(true, copy1.Available);
            var bookEvent = new BookCheckoutEvent(client1, copy1, DateTime.Now);
            repository.AddBookEvent(bookEvent);
            Assert.AreEqual(false, copy1.Available);
            var bookReturnEvent = new BookReturnEvent(client1, copy1, DateTime.Now);
            repository.AddBookEvent(bookReturnEvent);
            Assert.AreEqual(true, copy1.Available);
        }

        [Test]
        public void AddBookEvent_UnknownEventShouldThrow()
        {
            var context = new DataContext();
            var builder = new ContextBuilder()
            .AddBook("isbn-666", book1.Clone())
            .AddClient(client1)
            .AddBookCopy("isbn-666", copy1);
            var repository = new DataRepository(builder);
            var bookEvent = new CustomBookEvent(client1, copy1, DateTime.Now);
            Assert.Throws<UnknownEventException>(() => repository.AddBookEvent(bookEvent));
        }

        [Test]
        public void GetAllBookEvents()
        {
            var context = new DataContext();
            var builder = new ContextBuilder()
            .AddBook("isbn-666", book1.Clone())
            .AddClient(client1)
            .AddBookCopy("isbn-666", copy1)
            .AddBookEvent(event1)
            .AddBookEvent(event2)
            .AddBookEvent(event3)
            .AddBookEvent(event4);
            var repository = new DataRepository(builder);
            CollectionAssert.AreEqual(events, repository.GetAllBookEvents());
        }

        [Test]
        public void GetBookEvent()
        {
            var context = new DataContext();
            var builder = new ContextBuilder()
            .AddBook("isbn-666", book1.Clone())
            .AddClient(client1)
            .AddBookCopy("isbn-666", copy1)
            .AddBookEvent(event1);
            var repository = new DataRepository(builder);
            Assert.AreEqual(event1, repository.GetBookEvent(0));
        }

        private class CustomBookEvent : BookEvent
        {
            public CustomBookEvent(Client client1, BookCopy copy1, DateTime now) : base(client1, copy1, now) { }
        }
    }
}