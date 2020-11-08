using Model.Data;
using Model.Fillers;
using Model.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Utils;

namespace Model.Tests
{
    public class DataRepository_BookCopyTests
    {
        #region test data

        private Book book1 = new Book
        {
            Author = "Jan",
            Description = "Opis",
            PageCount = 4,
            Title = "Taniec z gwiazdami"
        };

        private BookCopy copy1 = new BookCopy
        {
            CopyID = 5,
        };

        #endregion test data

        [Test]
        public void AddBookCopy_NullishBookDetailsShouldThrow()
        {
            DataContext context = new DataContext();
            var builder = new ContextBuilder();
            DataRepository repository = new DataRepository(builder);
            Assert.Throws<InvalidModelException>(() => repository.AddBookCopy(copy1));
        }

        [Test]
        public void AddBookCopy_DuplicatedIdShouldThrow(){
            DataContext context= new DataContext();
            var book = book1.Clone();
            var copy = copy1.CloneWith(x => x.BookDetails, book);
            var builder = new ContextBuilder()
                .AddBook("isb-666", book)
                .AddBookCopy("isb-666", copy1.Clone());
            DataRepository repository = new DataRepository(builder);
            Assert.Throws<DuplicatedItemException>(() => repository.AddBookCopy(copy));
        }

        [Test]
        public void AddBookCopy_OuterBookDetailsShouldThrow(){
            DataContext context= new DataContext();
            var builder = new ContextBuilder()
            .AddBook("isb-666", book1.Clone());
            DataRepository repository = new DataRepository(builder);
            var copy = copy1.CloneWith(x=>x.BookDetails, book1.CloneWith(x=>x.Title, "Koniec"));
            Assert.Throws<InvalidModelException>(() => repository.AddBookCopy(copy));
        }
    }
}