using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;

var builder = WebApplication.CreateBuilder(args);

// Create a SQLite connection that will be kept open for the lifetime of the application
var connection = new SqliteConnection("Data Source=:memory:");
connection.Open();

// Add services to the container.
builder.Services.AddDbContext<App.Interview.Server.Data.ApplicationDbContext>(options =>
    options.UseSqlite(connection));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Create and seed the database
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<App.Interview.Server.Data.ApplicationDbContext>();
    context.Database.EnsureCreated();
    
    // Verify the database was created
    var studentsExist = context.Students.Any();
    var staffExist = context.Staff.Any();
    var coursesExist = context.Courses.Any();
    var rostersExist = context.Rosters.Any();
    
    if (!studentsExist || !staffExist || !coursesExist || !rostersExist)
    {
        throw new Exception("Database initialization failed. Tables were not created properly.");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
