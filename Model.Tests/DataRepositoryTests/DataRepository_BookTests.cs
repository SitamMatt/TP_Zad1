using System;
using System.Collections.Generic;
using System.Text;
using Model.Data;
using Model.Exceptions;
using Model.Fillers;
using Model.Repository;
using NUnit.Framework;

namespace Model.Tests
{
    class DataRepository_BookTests
    {
        #region test data

        private Book book1;
        private Book book2;

        public DataRepository_BookTests()
        {
            book1 = new Book(
                "Balladyna",
                DateTime.Parse("2017-06-09"),
                "Juliusz Słowacki",
                "Opis",
                213);

            book2 = new Book(
                "Pan Tadeusz",
                DateTime.Parse("2014-06-09"),
                "Adam Mickiewicz",
                "Jacek Soplica",
                356);
        }

        #endregion test data

        [Test]
        public void DuplicatedItemTest()
        {
            DataContext context = new DataContext();
            var builder = new ContextBuilder()
            .AddBook("978-2-21-15432-0", book1);
            DataRepository repository = new DataRepository(builder);
            Assert.Throws<BookAlreadyExistException>(() => repository.AddBook("978-2-21-15432-0", book2));
        }

        [Test]
        public void AddBookTest()
        {
            DataContext context = new DataContext();
            var builder = new ContextBuilder()
            .AddBook("978-2-21-15432-0" ,book1);
            DataRepository repository = new DataRepository(builder);
            Assert.AreEqual(repository.GetBook("978-2-21-15432-0"), book1);
        }

        [Test]
        public void GetAllBooksTest(){
            DataContext context = new DataContext();
            var builder = new ContextBuilder()
            .AddBook("978-2-21-15432-0" ,book1)
            .AddBook("isbn-666" ,book2);
            DataRepository repository = new DataRepository(builder);
            var expected = new List<KeyValuePair<string, Book>>(){
                new KeyValuePair<string, Book>("978-2-21-15432-0" ,book1),
                new KeyValuePair<string, Book>("isbn-666" ,book2)
            };
            CollectionAssert.AreEqual(expected, repository.GetAllBooks());
        }
    }
}
