var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(); // MVC desteðini ekleyelim
var app = builder.Build();
app.UseRouting();
app.UseAuthorization();
app.MapControllers(); // Tüm Controller'larýekleyelim
app.Run();
