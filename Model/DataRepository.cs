using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    class DataRepository
    {
        private readonly DataContext _context;

        public DataRepository(IDataFiller filler)
        {
            _context = new DataContext();
            filler.Fill(_context);
        }

        public void AddKatalog(Katalog katalog, String isbn)
        {
            _context.Katalogi.Add(isbn, katalog);
        }

        public Katalog GetKatalog(String isbn)
        {
            return _context.Katalogi[isbn];
        }

        public IEnumerable<Katalog> GetAllKatalog()
        {
            return _context.Katalogi.Values;
        }

        public void UpdateKatalog(String isbn, Katalog katalog)
        {
            //TODO: Upewnić się czy taka wartość istnieje w słowniku
            _context.Katalogi[isbn] = katalog;
        }

        public void DeleteKatalog(String isbn)
        {
            //TODO: przemyśleć czy powinien przekazywać katalog czy klucz
            _context.Katalogi.Remove(isbn);
        }

        public void AddWykaz(Wykaz wykaz)
        {
            _context.Wykazy.Add(wykaz);
        }

        public Wykaz GetWykaz(int id)
        {
            return _context.Wykazy.Find(w => w.ID == id);
        }

        public IEnumerable<Wykaz> GetAllWykaz()
        {
            return _context.Wykazy;
        }

        public void UpdateWykaz(Wykaz wykaz, int id)
        {
            _context.Wykazy[id] = wykaz;
        }

        public void DeleteWykaz(Wykaz wykaz)
        {
            _context.Wykazy.Remove(wykaz);
        }
    }
}
