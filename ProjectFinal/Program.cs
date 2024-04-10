using System;

namespace ProjectFinal
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            // Add predefined books
            library.AddBook(new Book("The Great Gatsby", "F. Scott Fitzgerald"));
            library.AddBook(new Book("1984", "George Orwell"));
            library.AddBook(new Book("Moby Dick", "Herman Melville"));
            library.AddBook(new Book("Don Quixote", "Miguel de Cervantes"));
            library.AddBook(new Book("Pride and Prejudice", "Jane Austen"));

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("----- Library Menu -----");
                Console.WriteLine("1. List Books");
                Console.WriteLine("2. Find Book");
                Console.WriteLine("3. Borrow Book");
                Console.WriteLine("4. Return Book");
                Console.WriteLine("5. Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("List of books:");
                        library.ListBooks();
                        break;
                    case "2":
                        Console.Write("Enter book title: ");
                        string searchTitle = Console.ReadLine();
                        string bookInfo = library.FindBook(searchTitle);
                        Console.WriteLine(bookInfo);
                        break;
                    case "3":
                        Console.Write("Enter the book number you want to borrow: ");
                        int borrowIndex;
                        if (int.TryParse(Console.ReadLine(), out borrowIndex))
                        {
                            string borrowResult = library.BorrowBook(borrowIndex);
                            Console.WriteLine(borrowResult);
                        }
                        else
                        {
                            Console.WriteLine("Invalid number. Please try again.");
                        }
                        break;
                    case "4":
                        Console.Write("Enter the book number you want to return: ");
                        int returnIndex;
                        if (int.TryParse(Console.ReadLine(), out returnIndex))
                        {
                            string returnResult = library.ReturnBook(returnIndex);
                            Console.WriteLine(returnResult);
                        }
                        else
                        {
                            Console.WriteLine("Invalid number. Please try again.");
                        }
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}