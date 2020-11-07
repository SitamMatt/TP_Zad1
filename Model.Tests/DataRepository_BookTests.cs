using System;
using System.Collections.Generic;
using System.Text;
using Model.Fillers;
using NUnit.Framework;

namespace Model.Tests
{
    class DataRepository_BookTests
    {
        #region test data

        private Book book1 = new Book
        {
            Title = "Balladyna",
            Author = "Juliusz Słowacki",
            PageCount = 213,
            Description = "Przykładowy opis"
        };

        private Book book2 = new Book
        {
            Title = "Pan Tadeusz",
            Author = "Adam Mickiewicz",
            PageCount = 356,
            Description = "Jacek Soplica REEE"
        };

        #endregion test data

        [Test]
        public void DuplicatedItemTest()
        {
            DataContext context = new DataContext();
            var builder = new ContextBuilder();
            DataRepository repository = new DataRepository(builder);
            repository.AddBook("978-2-21-15432-0", book1);
            Assert.Throws<DuplicatedItemException>(() => repository.AddBook("978-2-21-15432-0", book2));
        }

        [Test]
        public void AddBookTest()
        {
            DataContext context = new DataContext();
            var builder = new ContextBuilder();
            DataRepository repository = new DataRepository(builder);
            repository.AddBook("978-2-21-15432-0" ,book1);
            Assert.AreEqual(repository.GetBook("978-2-21-15432-0"), book1);
        }

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

        [Test]
        public void UpdateBookTest()
        {
            DataContext context = new DataContext();
            var builder = new ContextBuilder();
            DataRepository repository = new DataRepository(builder);
            repository.AddBook("978-2-21-15432-0", book1);
            repository.UpdateBook("978-2-21-15432-0", book2);
            Assert.AreEqual(repository.GetBook("978-2-21-15432-0").Author, book2.Author);
            Assert.AreEqual(repository.GetBook("978-2-21-15432-0").Title, book2.Title);
            Assert.AreEqual(repository.GetBook("978-2-21-15432-0").Description, book2.Description);
            Assert.AreEqual(repository.GetBook("978-2-21-15432-0").PageCount, book2.PageCount);
        }
    }
}
