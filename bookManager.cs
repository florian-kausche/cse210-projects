
using System;
using System.Collections.Generic;

public class BookManager
{
    private List<Book> bookList = new List<Book>();

    public void AddBook(Book book)
    {
        bookList.Add(book);
    }

    public void RemoveBook(Book book)
    {
        bookList.Remove(book);
    }

    public Book FindBook(string title)
    {
        foreach (Book book in bookList)
        {
            if (book.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                return book;
            }
        }
        return null;
    }
}

public class Book
{
    public string Title { get; set; }
    // Other properties of Book class
}

