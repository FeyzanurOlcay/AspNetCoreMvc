using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddApiVersioning(options =>
{
	options.DefaultApiVersion = new ApiVersion(1, 0);
	options.AssumeDefaultVersionWhenUnspecified = true;
	options.ReportApiVersions = true;
})
	.AddApiExplorer(options =>
	{
		options.GroupNameFormat = "'v'VVV";
		options.SubstituteApiVersionInUrl = true;

	});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
	var provider = builder.Services.BuildServiceProvider()
	.GetRequiredService<IApiVersionDescriptionProvider>();
	foreach(var description in provider.ApiVersionDescriptions)
	{
		options.SwaggerDoc(description.GroupName, new OpenApiInfo
		{
			Title=$"Versioned API{description.ApiVersion}",
			Version=description.GroupName
		});
	}
});
var app =builder.Build();
var apiVersionDescriptionProvider=app.Services.GetRequiredService<IApiVersionDescriptionProvider> ();
app.UseSwagger();
app.UseSwaggerUI(options =>
{
	foreach(var desc in apiVersionDescriptionProvider.ApiVersionDescriptions)
	{
		options.SwaggerEndpoint($"/swagger/{desc.GroupName}/swagger.json",
			$"Versioned API {desc.GroupName.ToUpper()}");
	}
});
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
