using Model.Data;
using Model.Data.Events;
using Model.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Model.Tests.DataServiceTests
{
    public class DataServiceTests
    {
        #region test data

        private Mock<IDataRepository> dataRepositoryMock;
        private List<Client> clients;
        private Dictionary<string, Book> books;
        private ObservableCollection<BookEvent> events;
        private ObservableCollection<BookCopy> bookCopies;

        public DataServiceTests()
        {
            dataRepositoryMock = new Mock<IDataRepository>();

            clients = new List<Client>()
            {
                new Client("Josh", "Graham"),
                new Client("Adam", "Miauczyñski"),
            };

            books = new Dictionary<string, Book>();
            books.Add("isbn-666", new Book("Taniec z gwiazdami",
                DateTime.Parse("2010-05-06"),
                "Jan",
                "Opis",
                4));
            books.Add("isbn-777", new Book(
                "Pan Tadeusz",
                DateTime.Parse("2014-06-09"),
                "Adam Mickiewicz",
                "Jacek Soplica",
                356));

            bookCopies = new ObservableCollection<BookCopy>()
            {
                new BookCopy(books["isbn-666"], DateTime.Parse("2020-03-07")){
                    Available = true
                },
                new BookCopy(books["isbn-777"], DateTime.Parse("2019-03-07"))
                {
                    Available = false
                },
                new BookCopy(books["isbn-666"], DateTime.Parse("2018-03-07")){
                    Available = true
                },
            };

            events = new ObservableCollection<BookEvent>()
            {
                new BookCheckoutEvent(clients[0], bookCopies[2], DateTime.Parse("2019-06-09")),
                new BookCheckoutEvent(clients[1], bookCopies[1], DateTime.Parse("2020-01-01")),
                new BookReturnEvent(clients[0], bookCopies[2], DateTime.Parse("2019-12-11"))
            };

            dataRepositoryMock.Setup(x => x.GetAllBookEvents()).Returns(() => events);
            dataRepositoryMock.Setup(x => x.GetAllBookCopies()).Returns(() => bookCopies);
            dataRepositoryMock.Setup(x => x.GetAllBooks()).Returns(() => books);
            dataRepositoryMock.Setup(x => x.GetAllClient()).Returns(() => clients);
        }

        #endregion test data

        [Test]
        public void AddClientTest()
        {
            dataRepositoryMock.Invocations.Clear();
            var dataService = new DataService(dataRepositoryMock.Object);

            dataService.AddClient("Matt", "D¿onson");

            dataRepositoryMock.Verify(
                x => x.AddClient(
                    Match.Create<Client>(a => a.Firstname == "Matt" && a.Lastname == "D¿onson")
                ),
                Times.Once()
            );
        }

        [Test]
        public void CheckoutBookTest()
        {
            dataRepositoryMock.Invocations.Clear();
            var dataService = new DataService(dataRepositoryMock.Object);

            dataService.CheckoutBook(clients[0], bookCopies[0]);

            dataRepositoryMock.Verify(
                x => x.AddBookEvent(
                    Match.Create<BookCheckoutEvent>(a => a.Client == clients[0] && a.BookCopy == bookCopies[0])
                ),
                Times.Once()
            );
        }

        [Test]
        public void ReturnBookTest()
        {
            dataRepositoryMock.Invocations.Clear();
            var dataService = new DataService(dataRepositoryMock.Object);

            dataService.ReturnBook(bookCopies[1]);

            dataRepositoryMock.Verify(
                x => x.GetAllBookEvents(),
                Times.Once()
            );
            dataRepositoryMock.Verify(
                x => x.AddBookEvent(
                     Match.Create<BookReturnEvent>(a => a.Client == clients[1] && a.BookCopy == bookCopies[1])
                ),
                Times.Once()
            );
        }

        [Test]
        public void GetAllBookCopiesTest()
        {
            dataRepositoryMock.Invocations.Clear();
            var dataService = new DataService(dataRepositoryMock.Object);

            var result = dataService.GetAllBookCopies(books["isbn-666"]);

            dataRepositoryMock.Verify(
                x => x.GetAllBookCopies(),
                Times.Once()
            );

            CollectionAssert.AreEqual(result, new List<BookCopy> { bookCopies[0], bookCopies[2] });
        }

        [Test]
        public void GetLendingsBetweenTest()
        {
            dataRepositoryMock.Invocations.Clear();
            var dataService = new DataService(dataRepositoryMock.Object);

            var result = dataService.GetLendingsBetween(DateTime.Parse("2019-12-30"), DateTime.Parse("2021-01-01"));

            dataRepositoryMock.Verify(
                x => x.GetAllBookEvents(),
                Times.Once()
            );

            CollectionAssert.AreEqual(result, new List<BookEvent> { events[1] });
        }

        [Test]
        public void GetAllBooksTest()
        {
            dataRepositoryMock.Invocations.Clear();
            var dataService = new DataService(dataRepositoryMock.Object);

            var result = dataService.GetAllBooks();

            dataRepositoryMock.Verify(
                x => x.GetAllBooks(),
                Times.Once()
            );

            CollectionAssert.AreEqual(result, books);
        }

        [Test]
        public void GetAvailableBooksTest()
        {
            dataRepositoryMock.Invocations.Clear();
            var dataService = new DataService(dataRepositoryMock.Object);

            var result = dataService.GetAvailableBooks();

            dataRepositoryMock.Verify(
                x => x.GetAllBookCopies(),
                Times.Once()
            );

            CollectionAssert.AreEqual(result, new List<Book> { books["isbn-666"] });
        }

        [Test]
        public void IsBookAvailableTest()
        {
            dataRepositoryMock.Invocations.Clear();
            var dataService = new DataService(dataRepositoryMock.Object);

            var result = dataService.IsBookAvailable(books["isbn-666"]);

            dataRepositoryMock.Verify(
                x => x.GetAllBookCopies(),
                Times.Once()
            );

            Assert.IsTrue(result);

            result = dataService.IsBookAvailable(books["isbn-777"]);

            dataRepositoryMock.Verify(
                x => x.GetAllBookCopies(),
                Times.Exactly(2)
            );

            Assert.IsFalse(result);
        }

        [Test]
        public void GetAllCopiesCheckedOutByClientTest()
        {
            dataRepositoryMock.Invocations.Clear();
            var dataService = new DataService(dataRepositoryMock.Object);

            var result = dataService.GetAllCopiesCheckedOutByClient(clients[0]);

            dataRepositoryMock.Verify(
                x => x.GetAllBookEvents(),
                Times.Once()
            );

            CollectionAssert.AreEqual(result, new List<BookCopy> { bookCopies[2] });
        }

        [Test]
        public void GetAllCopiesCheckedOutByClientTest2()
        {
            dataRepositoryMock.Invocations.Clear();
            var dataService = new DataService(dataRepositoryMock.Object);

            var result = dataService.GetAllCopiesCheckedOutByClient(clients[1]);

            dataRepositoryMock.Verify(
                x => x.GetAllBookEvents(),
                Times.Once()
            );
            CollectionAssert.AreEqual(result, new List<BookCopy> { bookCopies[1] });
        }
    }
}