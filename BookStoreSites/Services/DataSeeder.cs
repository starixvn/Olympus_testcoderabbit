namespace BookStoreSites.Services;

public class DataSeeder
{
    private readonly IBookService _bookService;
    private readonly string[] _publishers = new[]
    {
        "Kim Đồng", "Nhà Xuất Bản Trẻ", "Nhà Xuất Bản Giáo Dục",
        "First News", "Nhã Nam", "Phương Nam Book", "Alphabooks",
        "NXB Tổng hợp TPHCM", "NXB Hội Nhà Văn", "NXB Văn Học"
    };

    private readonly string[] _authors = new[]
    {
        "Nguyễn Nhật Ánh", "Tô Hoài", "Ngô Tất Tố",
        "Nam Cao", "Nguyễn Du", "Xuân Diệu",
        "Vũ Trọng Phụng", "Thạch Lam", "Hồ Xuân Hương",
        "Nguyễn Tuân", "Nguyễn Ngọc Tư", "Nguyễn Phong Việt"
    };

    private readonly string[] _bookTitles = new[]
    {
        "Cho tôi xin một vé đi tuổi thơ", "Dế mèn phiêu lưu ký", "Tắt đèn",
        "Lão Hạc", "Truyện Kiều", "Những ngã tư và những cột đèn",
        "Số đỏ", "Hai đứa trẻ", "Chí Phèo",
        "Tôi thấy hoa vàng trên cỏ xanh", "Mắt biếc", "Kính vạn hoa",
        "Bến không chồng", "Sống mòn", "Giông tố",
        "Hạnh phúc của một tang gia", "Vang bóng một thời", "Những mảnh hồi ức",
        "Tuổi thơ dữ dội", "Đất rừng phương nam", "Chiếc lược ngà",
        "Nhật ký trong tù", "Bỉ vỏ", "Giã từ tuổi trẻ",
        "Đời thay đổi khi chúng ta thay đổi", "Cánh đồng bất tận", "Đảo mộng mơ",
        "Bước ngoặt", "Ngày xưa có một chuyện tình", "Nơi không có người thân"
    };

    public DataSeeder(IBookService bookService)
    {
        _bookService = bookService;
    }

    public void SeedData()
    {
        var random = new Random();

        for (int i = 0; i < 100; i++)
        {
            var book = new Models.Book
            {
                Title = GetRandomBookTitle(random),
                Author = _authors[random.Next(_authors.Length)],
                Publisher = _publishers[random.Next(_publishers.Length)],
                Price = Math.Round(random.Next(50, 500) * 1000m, 0) // Giá từ 50,000 đến 500,000 VNĐ
            };

            _bookService.AddBook(book);
        }
    }

    private string GetRandomBookTitle(Random random)
    {
        // 80% cơ hội lấy tựa sách có sẵn
        if (random.NextDouble() < 0.8)
        {
            return _bookTitles[random.Next(_bookTitles.Length)];
        }

        // 20% cơ hội tạo tựa sách mới bằng cách kết hợp
        var firstPart = _bookTitles[random.Next(_bookTitles.Length)].Split(' ')[0];
        var secondPart = _bookTitles[random.Next(_bookTitles.Length)].Split(' ').Last();
        return $"{firstPart} {secondPart} {random.Next(1, 10)}";
    }
}
