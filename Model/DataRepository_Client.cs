using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public partial class DataRepository
    {
        public void ValidateClient(Client entity)
        {
            if (_context.Clients.Contains(entity))
                throw new DuplicatedItemException();
           /* if (GetClientById(entity.ID) != null)
                throw new DuplicatedItemException();*/
        }
        public void AddClient(Client entity)
        {
            if (_context.Clients.Contains(entity))
            {
                throw new DuplicatedItemException();
            }
            _context.Clients.Add(entity);
        }

        public Client GetClient(int key)
        {
            return _context.Clients[key];
        }

        public Client GetClientById(int ID)
        {
            foreach (Client element in _context.Clients)
            {
                if (element.ID == ID)
                {
                    return element;
                }
            }
            return null;
        }

        public void UpdateClient(int key, Client entity)
        {
            var originalClient = _context.Clients[key];
            MapperHelper.Mapper.Map(entity, originalClient);
        }

        public void DeleteClient(Client client)
        {
            _context.Clients.Remove(client);
        }

        public IEnumerable<Client> GetAllClient()
        {
            return _context.Clients;
        }
    }
}
