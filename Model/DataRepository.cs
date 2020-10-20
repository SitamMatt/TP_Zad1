using System;
using System.Collections.Generic;
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
    }
}
