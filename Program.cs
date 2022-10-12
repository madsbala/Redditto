using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.Json;

using Redditto.DataContext;
using Redditto.Services;

var builder = WebApplication.CreateBuilder(args);

// Sætter CORS så API'en kan bruges fra andre domæner
var AllowSomeStuff = "_AllowSomeStuff";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowSomeStuff, builder => {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

// Tilføj DbContext factory som service.
builder.Services.AddDbContext<BoardContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("ContextSQLite")));

// Tilføj DataService så den kan bruges i endpoints
builder.Services.AddScoped<DbService>();

var app = builder.Build();

// Seed data hvis nødvendigt.
using (var scope = app.Services.CreateScope())
{
    var dataService = scope.ServiceProvider.GetRequiredService<DbService>();
    dataService.SeedData(); // Fylder data på, hvis databasen er tom. Ellers ikke.
}

app.UseHttpsRedirection();
app.UseCors(AllowSomeStuff);

// Middlware der kører før hver request. Sætter ContentType for alle responses til "JSON".
app.Use(async (context, next) =>
{
    context.Response.ContentType = "application/json; charset=utf-8";
    await next(context);
});

// DataService fås via "Dependency Injection" (DI)
app.MapGet("/", (DbService service) =>
{
    return new { message = "Hello World!" };
});

app.MapGet("/api/boards", (DbService service) =>
{
    return service.GetBoards().Select(b => new {
        boardId = b.BoardID,
        header = b.Header,
        author = b.Author,
        comments = b.Comments,
        timePosted = b.TimePosted,
        vote = b.Vote
    });
});

app.Run();