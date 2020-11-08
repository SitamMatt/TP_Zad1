using System;
using System.Collections.Generic;
using System.Text;
using Model.Data;
using Model.Fillers;
using Model.Repository;
using NUnit.Framework;

namespace Model.Tests
{
    class DataRepository_ClientTests
    {
        #region test data

        private Client klient1;
        private Client klient2;
        private Client klient3;

        public DataRepository_ClientTests()
        {
            klient1 = new Client("Janusz", "Tracz");
            klient2 = new Client("Grzegorz", "Brzeczyszczykiewicz");
            klient3 = new Client("Adam", "Mickiewicz");
        }

        #endregion test data

        [Test]
        public void AddClient_DuplicatedItemShouldThrowTest()
        {
            DataContext context = new DataContext();
            var builder = new ContextBuilder().AddClient(klient1);
            DataRepository dataRepository = new DataRepository(builder);
            Assert.Throws<DuplicatedItemException>(() => dataRepository.AddClient(klient1));
        }
        
        [Test]
        public void AddClientTest()
        {
            DataContext context = new DataContext();
            var builder = new ContextBuilder();
            DataRepository repository = new DataRepository(builder);
            repository.AddClient(klient1);
            Assert.AreEqual(repository.GetClient(0), klient1);
        }

        [Test]
        public void DeleteClientTest()
        {
            DataContext context = new DataContext();
            var builder = new ContextBuilder();
            DataRepository repository = new DataRepository(builder);
            repository.AddClient(klient1);
            repository.AddClient(klient2);
            repository.DeleteClient(klient1);
            Assert.AreNotEqual(repository.GetClient(0), klient1);
            Assert.AreEqual(repository.GetClient(0), klient2);
        }

        //[Test]
        //public void UpdateClientTest()
        //{
        //    DataContext context = new DataContext();
        //    var builder = new ContextBuilder();
        //    DataRepository repository = new DataRepository(builder);
        //    repository.AddClient(klient1);
        //    Assert.AreEqual(repository.GetClient(0), klient1);
        //    repository.UpdateClient(0, klient3);
        //    Assert.AreEqual(repository.GetClient(0).Firstname, klient3.Firstname);
        //    Assert.AreEqual(repository.GetClient(0).Lastname, klient3.Lastname);
        //}

        [Test]
        public void GetAllClientsTest()
        {
            //TODO: implementacja
        }
    }
}
