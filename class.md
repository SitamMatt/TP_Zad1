# Class overview

## Client

```csharp
public class Client
{
    public int ID { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
}
```

* ID - unique

## Book

```csharp
public class Book
{
    public string Title { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Author { get; set; }
    public string Description { get; set; }
    public int PageCount { get; set; }
}
```

* Identified by string key in dicitionary

## BookCopy

```csharp
public class BookCopy
{
    //TODO: Decide if it should keep some id of book not the reference
    public Book BookDetails { get; set; }
    public int CopyID { get; set; }
    public DateTime PurchaseDate { get; set; }
    public bool Available { get; set; }
}
```

* CopyID - unique
* BookDetails - not null, Book reference must exist in context
* Available - linked with ReturnDate of BookCheckout (true if ReturnDate is specified in referencing BookCheckout)

## BookCheckout

```csharp
public class BookCheckout
{
    public Client Client { get; set; }
    public BookCopy BookCopy { get; set; }
    public DateTime CheckoutDate { get; set; }
    //TODO check if DateTime can be null  
    public DateTime ReturnDate { get; set; }
}
```

* Client - not null, Client reference must exist in context
* BookCopy - not null, BookCopy reference must exist in context
* ReturnDate - if specified the BookCopy must be available