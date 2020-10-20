using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public interface IDataFiller
    {
        void Fill(DataContext context);
    }
}
