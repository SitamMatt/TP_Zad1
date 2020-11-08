using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Model.Data;
using Model.Fillers;

namespace Model.Repository
{
    public partial class DataRepository
    {
        private readonly DataContext _context;

        public DataRepository(IDataFiller filler)
        {
            _context = new DataContext();
            filler.Fill(_context);
        }
    }
}
