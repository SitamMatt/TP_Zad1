using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class DataRepository
    {
        private readonly DataContext _context;

        public DataRepository(IDataFiller filler)
        {
            _context = new DataContext();
            filler.Fill(_context);
        }

        public void AddClient(Client entity)
        {
            _context.Clients.Add(entity);
        }

        public Client GetClient(int key)
        {
            return _context.Clients[key];
        }

        public void UpdateClient(int key, Client entity)
        {
            _context.Clients[key] = entity;
        }

        public IEnumerable<Client> GetAllClient()
        {
            return _context.Clients;
        }

        public void AddKatalog(Book katalog, String isbn)
        {
            _context.Books.Add(isbn, katalog);
        }

        public Book GetKatalog(String isbn)
        {
            return _context.Books[isbn];
        }

        public IEnumerable<Book> GetAllKatalog()
        {
            return _context.Books.Values;
        }

        public void UpdateKatalog(String isbn, Book katalog)
        {
            //TODO: Upewnić się czy taka wartość istnieje w słowniku
            _context.Books[isbn] = katalog;
        }

        public void DeleteKatalog(String isbn)
        {
            //TODO: przemyśleć czy powinien przekazywać katalog czy klucz
            _context.Books.Remove(isbn);
        }

        public void AddWykaz(Client wykaz)
        {
            _context.Clients.Add(wykaz);
        }

        public Client GetWykaz(int id)
        {
            return _context.Clients.Find(w => w.ID == id);
        }

        public IEnumerable<Client> GetAllWykaz()
        {
            return _context.Clients;
        }

        public void UpdateWykaz(Client wykaz, int id)
        {
            _context.Clients[id] = wykaz;
        }

        public void DeleteWykaz(Client wykaz)
        {
            _context.Clients.Remove(wykaz);
        }

        public IEnumerable<BookCheckout> GetAllZdarzenias()
        {
            return _context.Lendings;
        }
    }
}
