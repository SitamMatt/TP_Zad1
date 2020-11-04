using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class BookCheckout
    {
        public Client Client { get; set; }
        public BookCopy BookCopy { get; set; }

        public DateTime CheckoutDate { get; set; }
        //TODO check if DateTime can be null  
        public DateTime ReturnDate { get; set; }
    }
}
