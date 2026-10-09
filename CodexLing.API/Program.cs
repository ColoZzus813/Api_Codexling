using CodexLing.Query.Implements;
using CodexLing.Query.Interfaces;
using CodexLing.Repository.Implements;
using CodexLing.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(options =>
{
    options.Title = "CODEXLING";
});
builder.Services.AddScoped<IUsuarioQueries, UsuarioQueries>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi(settings =>
    {
        settings.DocumentTitle = "CODEXLING";
    });
}

app.UseAuthorization();
app.MapControllers();
app.Run();
