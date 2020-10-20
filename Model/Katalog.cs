using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Katalog
    {
        public DateTime DataWydania { get; set; }
        public string Autor { get; set; }
        public string Opis { get; set; }
        public int LiczbaStron { get; set; }
    }
}
