using Model.Data;
using Model.Fillers;
using Model.Repository;
using NUnit.Framework;

namespace Model.Tests
{
    public class DataRepositoryTests
    {
        private DataRepository _dataRepository;

        [SetUp]
        public void Setup()
        {
            _dataRepository = new DataRepository(new ConstantDataFiller());
        }

        [Test]
        public void WykazAddTest()
        {
            var wykaz = new Client
            {
                ID = 5,
                Firstname = "Jacek",
                Lastname = "Robocznik"
            };
            //Assert.Null(_dataRepository.GetWykaz(5));
            //_dataRepository.AddWykaz(wykaz);
            //Assert.NotNull(_dataRepository.GetWykaz(5));
            //var record = _dataRepository.GetWykaz(5);
            //Assert.AreEqual("Jacek", record.Firstname);
            //Assert.AreEqual("Robocznik", record.Lastname);
            //Assert.AreEqual(5, record.ID);
        }
    }
}