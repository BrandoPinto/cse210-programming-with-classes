using System;
using System.IO;

namespace ProjectFinal
{
    class Library
    {
        private Book[] books;

        public Library()
        {
            books = new Book[5];
        }

        public void AddBook(Book book)
        {
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i] == null)
                {
                    books[i] = book;
                    return;
                }
            }

            Console.WriteLine("The library is full. Cannot add more books.");
        }

        public void ListBooks()
        {
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i] != null)
                {
                    Console.WriteLine($"{i + 1}. {books[i].ToString()}");
                }
            }
        }

        public string FindBook(string title)
        {
            foreach (Book book in books)
            {
                if (book != null && book.Title == title)
                {
                    return book.ToString();
                }
            }

            return "Book not found.";
        }

        public string BorrowBook(int index)
        {
            if (index >= 1 && index <= books.Length)
            {
                int bookIndex = index - 1;

                if (books[bookIndex] != null)
                {
                    if (books[bookIndex].IsBorrowed)
                    {
                        return "The book is already borrowed.";
                    }

                    books[bookIndex].Borrow();

                    // Create a ticket with the borrowing details
                    string ticket = $"----- Library Ticket -----\n" +
                                    $"Book: {books[bookIndex].Title}\n" +
                                    $"Author: {books[bookIndex].Author}\n" +
                                    $"Borrowed on: {DateTime.Now.ToString("yyyy-MM-dd")}\n" +
                                    $"Return by: {DateTime.Now.AddDays(5).ToString("yyyy-MM-dd")}\n" +
                                    $"--------------------------";
                    File.WriteAllText("ticket.txt", ticket);

                    return "Book borrowed successfully. Ticket created.";
                }
                else
                {
                    return "There is no book at that position.";
                }
            }
            else
            {
                return "Invalid book number.";
            }
        }

        public string ReturnBook(int index)
        {
            if (index >= 1 && index <= books.Length)
            {
                int bookIndex = index - 1;

                if (books[bookIndex] != null)
                {
                    if (!books[bookIndex].IsBorrowed)
                    {
                        return "The book is not currently borrowed.";
                    }

                    books[bookIndex].Return();

                    // Delete the ticket file
                    if (File.Exists("ticket.txt"))
                    {
                        File.Delete("ticket.txt");
                    }

                    return "Book returned successfully. Ticket deleted.";
                }
                else
                {
                    return "There is no book at that position.";
                }
            }
            else
            {
                return "Invalid book number.";
            }
        }
    }
}