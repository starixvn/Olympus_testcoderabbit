using BookStoreSites.Models;
using BookStoreSites.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStoreSites.Pages.Books;

public class EditModel : PageModel
{
    private readonly IBookService _bookService;

    public EditModel(IBookService bookService)
    {
        _bookService = bookService;
    }

    [BindProperty]
    public Book Book { get; set; } = new();

    public IActionResult OnGet(int id)
    {
        var book = _bookService.GetBookById(id);
        if (book == null)
        {
            return NotFound();
        }

        Book = book;
        return Page();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _bookService.UpdateBook(Book);
        return RedirectToPage("./Index");
    }
}
