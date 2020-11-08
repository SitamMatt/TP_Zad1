using System;
using System.Collections.Generic;
using System.Text;
using Model.Data;
using Model.Fillers;
using Model.Repository;
using NUnit.Framework;
using Model.Exceptions;

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

        //todo 
        [Test]
        public void DeleteBookTest()
        {
            DataContext context = new DataContext();
            var builder = new ContextBuilder();
            DataRepository repository = new DataRepository(builder);
            repository.AddBook("978-2-21-15432-0", book1);
            repository.DeleteBook("978-2-21-15432-0");
            Assert.Throws<KeyNotFoundException>(() =>repository.GetBook("978-2-21-15432-0")); // TODO:consider is it correct
        }

        //todo
        [Test]
        public void UpdateBookTest()
        {
            /*DataContext context = new DataContext();
            var builder = new ContextBuilder();
            DataRepository repository = new DataRepository(builder);
            repository.AddBook("978-2-21-15432-0", book1);
            repository.UpdateBook("978-2-21-15432-0", book2);
            Assert.AreEqual(repository.GetBook("978-2-21-15432-0").Author, book2.Author);
            Assert.AreEqual(repository.GetBook("978-2-21-15432-0").Title, book2.Title);
            Assert.AreEqual(repository.GetBook("978-2-21-15432-0").Description, book2.Description);
            Assert.AreEqual(repository.GetBook("978-2-21-15432-0").PageCount, book2.PageCount);*/
        }
    }
}
