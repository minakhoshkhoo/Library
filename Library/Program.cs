using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal class Program
    {
        
        public class Book
        {
            public string Title { get; private set; }
            public string Author { get; private set; }
            public int Price { get; private set; }
            public int pageNamber { get; private set; }

            public Book()
            {
                Title = null;
                Author = null;
                Price = 0;
                pageNamber = 0;
            }

            public Book(string title, string author, int price, int pageNumber)
            {
                Title = title;
                Author = author;
                Price = price;
                pageNumber = pageNumber;
            }

            public void displayBook()
            {
                Console.WriteLine($"Title:{Title}");
                Console.WriteLine($"Author:{Author}");
                Console.WriteLine($"Price:{Price}");
                Console.WriteLine($"page number:{pageNamber}");
            }
        }
        public class Librarian
        {
            private Dictionary<string, Book> books;

            public Librarian(Dictionary<string, Book> books)
            {
                this.books = books;
            }

            public void Add(Book book)
            {
                if (!books.ContainsKey(book.Title))
                {
                    books[book.Title] = book;
                    Console.WriteLine($"Added book:{book}");
                }
                else
                {
                    Console.WriteLine("your book don't added.");
                }
            }

            public void Remove(string title)
            {
                if (books.Remove(title))
                {
                    Console.WriteLine($"Remove Book {title}");
                }
                else
                {
                    Console.WriteLine($"Book not found");
                }
            }

            public void display()
            {
                Console.WriteLine("library Books:");
                foreach (var book in books.Values)
                {
                    Console.WriteLine(book);
                }
            }

        }

        public class Reader
        {
            private List<Book> books= new List<Book>();
            private Dictionary<string, Book> availableBooks = new Dictionary<string, Book>();

            public Reader(Dictionary<string, Book> books)
            {
                availableBooks = books;
            }

            public void displayBooks()
            {
                Console.WriteLine("available books:");
                foreach (var book in availableBooks.Values)
                {
                    Console.WriteLine(book);
                }
            }

            public void order(string title)
            {
                if (availableBooks.TryGetValue(title, out var book))
                {
                    books.Add(book);
                    Console.WriteLine($"added to shopping cart:{book}");
                }
            }

            public void shappingCart()
            {
                Console.WriteLine("your book:");
                foreach (var book in books)
                {
                    Console.WriteLine(book);
                }
                {
                    Console.WriteLine(books);
                }
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Book book1 = new Book ("White Nights", "F.Dostoevsky", "200000, 120");

                    book1.displayBook();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            while (true)
            {
                try
                {
                    Librarian librarian = new Librarian(books);
                    Reader reader = new Reader(books);

                    Console.WriteLine("your books:");
                    librarian.display();
                    Console.WriteLine("pleas type your new book information");
                    librarian.Add(new Book());
                    Console.ReadLine();
                    Console.WriteLine("Pleas type your title for deleted:");
                    librarian.Remove();
                    Console.ReadLine();

                    Console.WriteLine("the list of the book: ");
                    reader.displayBooks();
                    Console.WriteLine("pleas select your favorit books:");
                    reader.order();
                    Console.WriteLine("you can see your books in shopping:");
                    reader.shappingCart();
                }
                catch(Exception ex)
                {
                    Console.WriteLine (ex.Message);
                }
                
            }
        }
    }
}

