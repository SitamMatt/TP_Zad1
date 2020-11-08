using System;
using System.Collections.Generic;
using System.Text;
using Model.Data;
using Model.Exceptions;

namespace Model.Repository
{
    public partial class DataRepository
    {
        public void ValidateClient(Client entity)
        {
            if (_context.Clients.Contains(entity))
                throw new DuplicatedItemException();
        }

        public void AddClient(Client entity)
        {
            ValidateClient(entity);
            _context.Clients.Add(entity);
        }

        public Client GetClient(int key)
        {
            return _context.Clients[key];
        }

        public IEnumerable<Client> GetAllClient()
        {
            return _context.Clients;
        }
    }
}
