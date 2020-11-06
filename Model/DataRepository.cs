using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Model
{
    public partial class DataRepository
    {
        private readonly DataContext _context;

        public DataRepository(IDataFiller filler)
        {
            _context = new DataContext();
            filler.Fill(_context);
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

        internal void AddCheckout(BookCheckout checkout)
        {
            _context.Lendings.Add(checkout);
        }

        internal BookCheckout FindBookCheckout(Func<BookCheckout, bool> predicate)
        {
            throw new NotImplementedException();
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
            //todo consider kvp return
            return _context.Books.Values;
        }

        public void UpdateKatalog(String isbn, Book katalog)
        {
            var originalBook = _context.Books[isbn];
            MapperHelper.Mapper.Map(katalog, originalBook);
            //TODO: Upewnić się czy taka wartość istnieje w słowniku
        }

        public void DeleteKatalog(String isbn)
        {
            //TODO: przemyśleć czy powinien przekazywać katalog czy klucz
            _context.Books.Remove(isbn);
        }
    }
}
