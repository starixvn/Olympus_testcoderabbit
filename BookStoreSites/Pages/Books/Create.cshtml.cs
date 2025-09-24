using BookStoreSites.Models;
using BookStoreSites.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStoreSites.Pages.Books;

public class CreateModel : PageModel
{
    private readonly IBookService _bookService;

    public CreateModel(IBookService bookService)
    {
        _bookService = bookService;
    }

    [BindProperty]
    public Book Book { get; set; } = new();

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _bookService.AddBook(Book);
        return RedirectToPage("./Index");
    }
}
