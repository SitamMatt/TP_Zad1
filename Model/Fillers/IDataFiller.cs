using System;
using System.Collections.Generic;
using System.Text;
using Model.Data;

namespace Model.Fillers
{
    public interface IDataFiller
    {
        void Fill(DataContext context);
    }
}
