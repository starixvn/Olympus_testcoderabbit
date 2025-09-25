using BookStoreSites.Models;

namespace BookStoreSites.Services;

public interface IBookService
{
    List<Book> GetAllBooks();
    List<Book> SearchBooks(string searchTerm);
    Book? GetBookById(int id);
    void AddBook(Book book);
    void UpdateBook(Book book);
    void DeleteBook(int id);
}

public class BookService : IBookService
{
    private readonly List<Book> _books;
    private int _nextId = 1;

    public BookService()
    {
        _books = new List<Book>();
    }

    public List<Book> GetAllBooks()
    {
        return _books;
    }

    public List<Book> SearchBooks(string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return _books;

        return _books.Where(b => b.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public Book? GetBookById(int id)
    {
        return _books.FirstOrDefault(b => b.Id == id);
    }

    public void AddBook(Book book)
    {
        book.Id = _nextId++;
        _books.Add(book);
    }

    public void UpdateBook(Book book)
    {
        var existingBook = _books.FirstOrDefault(b => b.Id == book.Id);
        if (existingBook != null)
        {
            existingBook.Title = book.Title;
            existingBook.Publisher = book.Publisher;
            existingBook.Author = book.Author;
            existingBook.Price = book.Price;
        }
    }

    public void DeleteBook(int id)
    {
        var book = _books.FirstOrDefault(b => b.Id == id);
        if (book != null)
        {
            _books.Remove(book);
        }
    }
}
