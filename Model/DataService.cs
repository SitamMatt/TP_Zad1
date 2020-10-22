using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class DataService
    {
        private readonly DataRepository dataRepository;

        public DataService(DataRepository dataRepository)
        {
            this.dataRepository = dataRepository;
        }

        public IEnumerable<Katalog> GetAllKatalogs() => dataRepository.GetAllKatalog();

        public IEnumerable<Zdarzenie> GetAllForWykaz(Wykaz wykaz)
        {
            return dataRepository.GetAllZdarzenias().Where(z => z.Klient == wykaz);
        }

        public void DodajZdarzenie(Wykaz wykaz, OpisStanu stan)
        {
            var zdarzenie = new Zdarzenie
            {
                Klient = wykaz,
                Egzemplarz = stan,
                DataWypożyczenia = DateTime.Parse("2020-06-09")
            };
            // todo: dokończ
            //dataRepository.ad
        }
    }
}
