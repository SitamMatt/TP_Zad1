using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class BookCopy
    {
        //TODO: Decide if it should keep some id of book not the reference
        public Book BookDetails { get; set; }
        public int CopyID { get; set; }
        public DateTime PurchaseDate { get; set; }
        public bool Available { get; set; }
    }
}
