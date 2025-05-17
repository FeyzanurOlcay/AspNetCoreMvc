using System.ComponentModel.DataAnnotations;
using M.BindingValidation.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var products = new List<Products>();
// ??Ürün ekleme API’si(Validationile)
app.MapPost("/addproduct", (Products product) =>
{
	var context = new ValidationContext(product);
	var results = new List<ValidationResult>();
	if (!Validator.TryValidateObject(product, context, results, true))
	{
		return Results.BadRequest(results.Select(r => r.ErrorMessage));
	}
	products.Add(product);
	return Results.Ok($"Ürün eklendi: {product.Name}, Fiyat: {product.Price}");
});
app.MapGet("/products", () => products);
app.Run();

