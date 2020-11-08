using Model.Data;
using Model.Fillers;
using Model.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Utils;
using Model.Exceptions;

namespace Model.Tests
{
    public class DataRepository_BookCopyTests
    {
        #region test data

        private Book book1;

        private BookCopy copy1;

        public DataRepository_BookCopyTests()
        {
            book1 = new Book(
                "Taniec z gwiazdami",
                DateTime.Parse("2010-05-06"),
                "Jan",
                "Opis",
                4);
            copy1 = new BookCopy(
                book1,
                DateTime.Now);
        }

        #endregion test data

        [Test]
        public void AddBookCopy_NullishBookDetailsShouldThrow()
        {
            DataContext context = new DataContext();
            var builder = new ContextBuilder();
            DataRepository repository = new DataRepository(builder);
            var bookCopyWithoutDetail = copy1.Clone();
            Assert.Throws<InvalidModelException>(() => repository.AddBookCopy(bookCopyWithoutDetail));
        }

        [Test]
        public void AddBookCopy_DuplicatedItemShouldThrow(){
            DataContext context= new DataContext();
            var book = book1.Clone();
            var bookCopy = copy1.Clone();
            var builder = new ContextBuilder()
                .AddBook("isb-666", book)
                .AddBookCopy("isb-666", bookCopy);
            DataRepository repository = new DataRepository(builder);
            var duplicatedCopy = bookCopy.Clone();
            Assert.Throws<DuplicatedItemException>(() => repository.AddBookCopy(duplicatedCopy));
        }

        [Test]
        public void AddBookCopy_OuterBookDetailsShouldThrow(){
            DataContext context= new DataContext();
            var builder = new ContextBuilder()
            .AddBook("isb-666", book1.Clone());
            DataRepository repository = new DataRepository(builder);
            var bookNotExistingInContext = book1.CloneWith(x=>x.Title, "Koniec");
            var invalidBookCopy = copy1.CloneWith(x=>x.BookDetails, bookNotExistingInContext);
            Assert.Throws<InvalidModelException>(() => repository.AddBookCopy(invalidBookCopy));
        }
    }
}