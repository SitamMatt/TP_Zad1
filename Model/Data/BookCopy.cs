using System;

namespace Model.Data
{
    public class BookCopy
    {
        public BookCopy(Book bookDetails, DateTime purchaseDate)
        {
            this.BookDetails = bookDetails;
            this.PurchaseDate = purchaseDate;
        }
        public Book BookDetails { get; }
        public DateTime PurchaseDate { get; }
        public bool Available { get; set; }
    }
}
