using NUnit.Framework;

namespace Model.Tests
{
    public class DataRepositoryTests
    {
        private DataRepository _dataRepository;

        [SetUp]
        public void Setup()
        {
            _dataRepository = new DataRepository(new WypelnianieStalymi());
        }

        [Test]
        public void WykazAddTest()
        {
            var wykaz = new Wykaz
            {
                ID = 5,
                Imie = "Jacek",
                Nazwisko = "Robocznik"
            };
            Assert.Null(_dataRepository.GetWykaz(5));
            _dataRepository.AddWykaz(wykaz);
            Assert.NotNull(_dataRepository.GetWykaz(5));
            var record = _dataRepository.GetWykaz(5);
            Assert.AreEqual("Jacek", record.Imie);
            Assert.AreEqual("Robocznik", record.Nazwisko);
            Assert.AreEqual(5, record.ID);
        }
    }
}