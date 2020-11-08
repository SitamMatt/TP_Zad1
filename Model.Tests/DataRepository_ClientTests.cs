using System;
using System.Collections.Generic;
using System.Text;
using Model.Fillers;
using NUnit.Framework;

namespace Model.Tests
{
    class DataRepository_ClientTests
    {
        #region test data
        private Client klient1 = new Client
        {
            ID = 1,
            Firstname = "Janusz",
            Lastname = "Tracz"
        };

        private Client klientDuplicatedId = new Client
        {
            ID = 1,
            Firstname = "Andrzej",
            Lastname = "Adamiak"
        };

        private Client klient2 = new Client
        {
            ID = 23,
            Firstname = "Grzegorz",
            Lastname = "Brzeczyszczykiewicz"
        };

        private Client klient3 = new Client
        {
            ID = 4,
            Firstname = "Adam",
            Lastname = "Mickiewicz"
        };

        #endregion test data

        [Test]
        public void AddClient_DuplicatedItemShouldThrowTest()
        {
            DataContext context = new DataContext();
            var builder = new ContextBuilder().AddClient(klient1);
            DataRepository dataRepository = new DataRepository(builder);
            Assert.Throws<DuplicatedItemException>(() => dataRepository.AddClient(klient1));
            Assert.Throws<DuplicatedItemException>(() => dataRepository.AddClient(klientDuplicatedId));
        }
        
        [Test]
        public void AddClientTest()
        {
            DataContext context = new DataContext();
            var builder = new ContextBuilder();
            DataRepository repository = new DataRepository(builder);
            repository.AddClient(klient1);
            Assert.AreEqual(repository.GetClientById(1), klient1);
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
            Assert.AreEqual(repository.GetClientById(1), klient1);
            repository.DeleteClient(klient1);
            Assert.AreNotEqual(repository.GetClient(0), klient1);
            Assert.AreEqual(repository.GetClient(0), klient2);
            Assert.AreEqual(repository.GetClientById(1), null);
        }

        [Test]
        public void UpdateClientTest()
        {
            DataContext context = new DataContext();
            var builder = new ContextBuilder();
            DataRepository repository = new DataRepository(builder);
            repository.AddClient(klient1);
            Assert.AreEqual(repository.GetClient(0), klient1);
            repository.UpdateClient(0, klient3);
            Assert.AreEqual(repository.GetClient(0).ID, klient3.ID);
            Assert.AreEqual(repository.GetClient(0).Firstname, klient3.Firstname);
            Assert.AreEqual(repository.GetClient(0).Lastname, klient3.Lastname);
        }

        [Test]
        public void GetAllClientsTest()
        {
            //TODO: implementacja
        }
    }
}
