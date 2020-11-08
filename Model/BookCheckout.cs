using System;
using System.Collections.Generic;
using System.Text;
using Model.Data;

namespace Model
{
    // todo remove when 0 refs
    public class BookCheckout
    {
        public Client Client { get; set; }
        public BookCopy BookCopy { get; set; }

        public DateTime CheckoutDate { get; set; }
        //TODO check if DateTime can be null  
        public DateTime ReturnDate { get; set; }
    }
}
