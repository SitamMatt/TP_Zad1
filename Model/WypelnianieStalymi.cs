using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Model
{
    public class WypelnianieStalymi : IDataFiller
    {
        public void Fill(DataContext context)
        {
            var wykazy = new List<Wykaz>();
            var wykaz1 = new Wykaz
            {
                ID = 1,
                Imie = "Jan",
                Nazwisko = "Kowalski"
            };
            wykazy.Add(wykaz1);
            var wykaz2 = new Wykaz
            {
                ID = 2,
                Imie = "Jarosław",
                Nazwisko = "Nowak"
            };
            wykazy.Add(wykaz2);
            var katalogi = new Dictionary<string, Katalog>();
            var katalog1 = new Katalog
            {
                Autor = "Michał Milowicz",
                DataWydania = DateTime.Parse("1999-02-01"),
                LiczbaStron = 50,
                Opis = "Świetna książka polecam"
            };
            katalogi["fff-aahh"] = katalog1;
            var katalog2 = new Katalog
            {
                Autor = "Jan Marczewski",
                DataWydania = DateTime.Parse("2001-06-09"),
                LiczbaStron = 255,
                Opis = "Super"
            };
            katalogi["hhshasdad"] = katalog2;
            var stany = new ObservableCollection<OpisStanu>();
            var opis1 = new OpisStanu
            {
                ID = 1,
                ISBN = "fff-aahh",
                DataZakupu = DateTime.Parse("2004-04-07")
            };
            stany.Add(opis1);
            var opis2 = new OpisStanu
            {
                ID = 2,
                ISBN = "hhshasdad",
                DataZakupu = DateTime.Parse("2005-09-01")
            };
            stany.Add(opis2);
            var opis3 = new OpisStanu
            {
                ID = 3,
                ISBN = "fff-aahh",
                DataZakupu = DateTime.Parse("2006-08-01")
            };
            stany.Add(opis3);
            var zdarzenia = new ObservableCollection<Zdarzenie>();
            var zdarz1 = new Zdarzenie
            {
                DataWypożyczenia = DateTime.Parse("2018-04-01"),
                DataZwrotu = DateTime.Parse("2018-06-01"),
                Egzemplarz = opis1,
                Klient = wykaz1
            };
            zdarzenia.Add(zdarz1);
            var zdarz2 = new Zdarzenie
            {
                DataWypożyczenia = DateTime.Parse("2020-08-01"),
                Egzemplarz = opis3,
                Klient = wykaz2
            };
            zdarzenia.Add(zdarz2);
            context.Wykazy = wykazy;
            context.Katalogi = katalogi;
            context.OpisyStanu = stany;
            context.Zdarzenia = zdarzenia;
        }
    }
}
