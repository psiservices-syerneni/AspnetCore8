using GameStore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


/* builder.Services.AddDbContext<GameDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))); */
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddSqlite<GameDbContext>(connection);

var app = builder.Build();

app.MigrateData();
app.Run();
