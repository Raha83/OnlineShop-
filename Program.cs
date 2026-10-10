using Microsoft.AspNetCore.SignalR;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

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

var products = new List<Product>();

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
    products.Add(product);
    return TypedResults.Created("/products/{product.id}", product);
});
app.MapDelete("/products/{id}", (int id) =>
{
    products.RemoveAll(p => p.id == id);
    return TypedResults.NoContent();
});

app.Run();

public class Product(int id, string name, int price, string description)
{
    public int id { get; set; } = id;
    public string name { get; set; } = name;
    public int price { get; set; } = price;
    public string description { get; set; } = description;
}
