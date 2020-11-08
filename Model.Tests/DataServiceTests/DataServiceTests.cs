using Model.Data;
using Model.Data.Events;
using Model.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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

            //dataRepositoryMock.Setup(x=>x.)

        }
        #endregion
        [Test]
        public void AddClientTest(){
            var dataService = new DataService(dataRepositoryMock.Object);

            dataService.AddClient("Matt", "D¿onson");

        }

        [Test]
        public void CheckoutBookTest(){

        }

        [Test]
        public void ReturnBookTest(){

        }

        [Test]
        public void GetAllBookCopiesTest(){

        }

        [Test]
        public void GetLendingsBetweenTest(){

        }

        [Test]
        public void GetAllBooksTest(){

        }

        [Test]
        public void GetAvailableBooksTest(){

        }

        [Test]
        public void IsBookAvailableTest(){

        }

        [Test]
        public void GetAllCopiesCheckedOutByClientTest(){
            
        }
	}
}