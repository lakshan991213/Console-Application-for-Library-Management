using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Book
{
    public string BookID { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int Quantity { get; set; }

    public bool CheckAvailability()
    {
        return Quantity > 0;
    }
}

public class Member
{
    public int MemberID { get; set; }
    public string Name { get; set; }
    public string ContactNumber { get; set; }

    public void BorrowBook(Book book)
    {
        if (book.CheckAvailability())
        {
            Console.WriteLine($"{Name} borrowed the book '{book.Title}'.");
            book.Quantity--;
        }
        else
        {
            Console.WriteLine($"'{book.Title}' is not available.");
        }
    }

    public void ReturnBook(Book book)
    {
        Console.WriteLine($"{Name} returned the book '{book.Title}'.");
        book.Quantity++;
    }
}

public class Library
{
    public string Name { get; set; }
    public string Address { get; set; }
    public List<Book> Books { get; set; } = new List<Book>();
    public List<Member> Members { get; set; } = new List<Member>();
    public List<Transaction> Transactions { get; set; } = new List<Transaction>();

    public void AddBook(Book book)
    {
        Books.Add(book);
        Console.WriteLine($"Added the book '{book.Title}' to the library.");
    }

    public void RemoveBook(Book book)
    {
        Books.Remove(book);
        Console.WriteLine($"Removed the book '{book.Title}' from the library.");
    }

    public void RegisterMember(Member member)
    {
        Members.Add(member);
        Console.WriteLine($"Registered a new member: {member.Name}");
    }

    public void RemoveMember(Member member)
    {
        Members.Remove(member);
        Console.WriteLine($"Removed the member: {member.Name}");
    }
}

public class Transaction
{
    public int TransactionID { get; set; }
    public Book Book { get; set; }
    public Member Member { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public DateTime BarrowDate { get; set; }

    public void CalculateFine()
    {
        // Your implementation for calculating fine goes here
    }
}

class library
{
    static void Main(string[] args)
    {
        Library library = new Library
        {
            Name = "UOC Library",
            Address = "Colombo",
        };

        Book book1 = new Book
        {
            BookID = "S-Science",
            Title = "Science for life",
            Author = "John Doe",
            Quantity = 5,
        };

        Member member1 = new Member
        {
            MemberID = 1,
            Name = "Nayana",
            ContactNumber = "077-4567891",
        };

        Transaction transaction1 = new Transaction
        {
            TransactionID = 101,
            Book = book1,
            Member = member1,
            DueDate = DateTime.Now.AddDays(8),
            ReturnDate = DateTime.Now.AddDays(10),
            BarrowDate = DateTime.Now.AddDays(1),
        };

        library.AddBook(book1);
        library.RegisterMember(member1);
        member1.BorrowBook(book1);
        member1.ReturnBook(book1);
        transaction1.CalculateFine();

        Console.WriteLine("Books in the library:");
        foreach (var book in library.Books)
            Console.WriteLine(book.Title);

        Console.WriteLine("Registered Members:");
        foreach (var member in library.Members)
            Console.WriteLine(member.Name);
    }
}

