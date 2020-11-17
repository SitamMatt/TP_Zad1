using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Data;
using Model.Fillers;
using Model.Repository;
using NUnit.Framework;

namespace Model.Tests.FillerTests
{
    class RandomDataFillerTests
    {
        [Test]
        public void RandomDataFillerCorrectness()
        {
            DataContext context = new DataContext();
            RandomDataFiller filler = new RandomDataFiller(5, 10, 5, 3, new DateTime(1995, 1, 1));
            DataRepository repository = new DataRepository(filler);

            Assert.AreEqual(5, repository.GetAllClient().Count());
            Assert.AreEqual(5, repository.GetAllBooks().Count());
            Assert.AreEqual(15, repository.GetAllBookCopies().Count());
            Assert.AreEqual(10, repository.GetAllBookEvents().Count());
        }
    }
}
