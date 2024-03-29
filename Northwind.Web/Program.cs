using Northwind.DataContext.Sqlite;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddNorthwindContext();

builder.Services.AddRazorPages();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapRazorPages();

app.MapGet("/hello", () => "Hello World!");

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.Use(async (HttpContext context, Func<Task> next) =>
{
    await next();
});

app.UseHttpsRedirection();

app.Run();

Console.WriteLine("This executes after the web server has stopped!");