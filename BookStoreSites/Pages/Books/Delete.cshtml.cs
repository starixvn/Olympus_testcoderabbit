using BookStoreSites.Models;
using BookStoreSites.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStoreSites.Pages.Books;

public class DeleteModel : PageModel
{
    private readonly IBookService _bookService;

    public DeleteModel(IBookService bookService)
    {
        _bookService = bookService;
    }

    [BindProperty]
    public Book Book { get; set; } = default!;

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

    public IActionResult OnPost(int id)
    {
        _bookService.DeleteBook(id);
        return RedirectToPage("./Index");
    }
}
