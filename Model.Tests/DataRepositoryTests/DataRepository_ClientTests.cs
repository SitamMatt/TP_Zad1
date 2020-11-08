using System;
using System.Collections.Generic;
using System.Text;
using Model.Data;
using Model.Exceptions;
using Model.Fillers;
using Model.Repository;
using NUnit.Framework;

namespace Model.Tests
{
    class DataRepository_ClientTests
    {
        #region test data

        private Client client1;
        private Client client2;
        private Client client3;

        public DataRepository_ClientTests()
        {
            client1 = new Client("Janusz", "Tracz");
            client2 = new Client("Grzegorz", "Brzeczyszczykiewicz");
            client3 = new Client("Adam", "Mickiewicz");
        }

        #endregion test data

        [Test]
        public void AddClient_DuplicatedItemShouldThrowTest()
        {
            DataContext context = new DataContext();
            var builder = new ContextBuilder().AddClient(client1);
            DataRepository dataRepository = new DataRepository(builder);
            Assert.Throws<DuplicatedItemException>(() => dataRepository.AddClient(client1));
        }
        
        [Test]
        public void AddClientTest()
        {
            DataContext context = new DataContext();
            var builder = new ContextBuilder();
            DataRepository repository = new DataRepository(builder);
            repository.AddClient(client1);
            Assert.AreEqual(repository.GetClient(0), client1);
        }

        [Test]
        public void GetAllClientsTest()
        {
            var context = new DataContext();
            var builder = new ContextBuilder()
            .AddClient(client1)
            .AddClient(client2);
            var repository = new DataRepository(builder);
            CollectionAssert.AreEqual(new List<Client>() { client1, client2 }, repository.GetAllClient());
        }
    }
}
