using System.ComponentModel.DataAnnotations;

namespace BookStoreSites.Models;

public class Book
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Title is required")]
    [StringLength(200, ErrorMessage = "Title cannot be longer than 200 characters")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Publisher is required")]
    [StringLength(100, ErrorMessage = "Publisher cannot be longer than 100 characters")]
    public string Publisher { get; set; } = string.Empty;

    [Required(ErrorMessage = "Author is required")]
    [StringLength(100, ErrorMessage = "Author cannot be longer than 100 characters")]
    public string Author { get; set; } = string.Empty;

    [Required(ErrorMessage = "Price is required")]
    [Range(0.01, 10000, ErrorMessage = "Price must be between 0.01 and 10000")]
    public decimal Price { get; set; }
}
