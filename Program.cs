using Microsoft.AspNetCore.SignalR;
using Microsoft.Net.Http.Headers;
using Eshop;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//Add services
var connectionString =
    builder.Configuration.GetConnectionString("Information");
builder.Services.AddDbContext<EshopContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Information")));
builder.Services.AddRazorPages();
var app = builder.Build();
app.MapRazorPages();

//practice for LINQ
var scores = new Dictionary<string, int>
{
    {"David",97},
    {"Sarah",68},
    {"Jake",50},
    {"Mariya",84}
};
var scoreValues = scores.Values;
IEnumerable<string> scoresQuery =
from score in scores
where score.Value > 80
select score.Key;

foreach (var item in scoresQuery)
{
    Console.WriteLine($"{item} got score above 80 in exam.");
}

//working with database
var options = new DbContextOptionsBuilder<EshopContext>()
.UseSqlServer(connectionString)
.Options;
var context = new EshopContext(options);
var products = context.products;

app.Use(async (context, next) =>
{
    Console.WriteLine($"[{context.Request.Method} {context.Request.Path} {DateTime.UtcNow}] started");
    await next(context);
    Console.WriteLine($"[{context.Request.Method} {context.Request.Path} {DateTime.UtcNow}] finished");
});

app.MapGet("/products", () => products);
app.MapGet("/products/{id}", (int id) =>
{
    var product = products.FirstOrDefault(p => p.id == id);
    return product;
});
app.MapPost("/products", (Product product) =>
{
    context.Add(product);
    context.SaveChanges();
    return TypedResults.Created("/products/{product.id}", product);
});
app.MapDelete("/products/{id}", (int id) =>
{
    var product = context.products
                .Where(p => p.id == id)
                .FirstOrDefault();
    if (product is Product)
    {
        context.products.Remove(product);
        context.SaveChanges();
    }
    return TypedResults.NoContent();
});

app.Run();