using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    interface IDataFiller
    {
        void Fill(DataContext context);
    }
}
