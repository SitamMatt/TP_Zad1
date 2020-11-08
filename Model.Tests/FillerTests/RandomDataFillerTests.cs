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
            RandomDataFiller filler = new RandomDataFiller(4);
            DataRepository repository = new DataRepository(filler);

            Assert.AreEqual(4, repository.GetAllClient().Count());
            Assert.AreEqual(4, repository.GetAllBooks().Count());
            Assert.AreEqual(8, repository.GetAllBookCopies().Count());
            Assert.AreEqual(8, repository.GetAllBookEvents().Count());
        }
    }
}
