using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Zdarzenie
    {
        public Wykaz Klient { get; set; }
        public DateTime DataWypożyczenia { get; set; }
        public DateTime DataZwrotu { get; set; }
        //TODO: zdecydować czy OpisStanu czy Katalog
        public OpisStanu Egzemplarz { get; set; }
    }
}
