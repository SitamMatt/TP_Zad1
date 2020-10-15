using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Model
{
    class DataContext
    {
        public List<Wykaz> Wykazy { get; set; }
        public Dictionary<string, Katalog> Katalogi {get;set;}
        public ObservableCollection<Zdarzenie> Zdarzenia { get; set; }      
        public ObservableCollection<OpisStanu> OpisyStanu { get; set; }
    }
}
