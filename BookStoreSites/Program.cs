var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSingleton<IBookService, BookService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseRouting();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

await app.RunAsync();
