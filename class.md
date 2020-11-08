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
public abstract class BookEvent
{
    protected BookEvent(Client client, BookCopy bookCopy, DateTime date)
    {
        this.Client = client;
        this.BookCopy = bookCopy;
        this.Date = date;
    }

    public Client Client { get; }
    public BookCopy BookCopy { get; }
    public DateTime Date { get; }
}

public class BookReturnEvent : BookEvent {}

public class BookCheckoutEvent : BookEvent {}
```

* Client - not null, Client reference must exist in context
* BookCopy - not null, BookCopy reference must exist in context
* CheckoutDate < ReturnDate
* Availability of BookCopy is determined by existing of those events