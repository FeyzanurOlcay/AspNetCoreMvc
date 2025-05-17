var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(); // MVC deste�ini ekleyelim
var app = builder.Build();
app.UseRouting();
app.UseAuthorization();
app.MapControllers(); // T�m Controller'lar�ekleyelim
app.Run();
