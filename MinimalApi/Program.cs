
var builder = WebApplication.CreateBuilder(args);
	var app = builder.Build();
app.MapGet("/products",()=> new List<string> { "Laptop", "Telefon", "Tablet" });
app.Run();
