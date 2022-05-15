using Microsoft.AspNetCore.HttpLogging;
using WiredBrainCoffee.Api.Hubs;
using WiredBrainCoffee.Api;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
//Setup Database
var connectionString = builder.Configuration.GetConnectionString("Orders") ?? "Data Source=Orders.db";


// Add services to the container.
builder.Services.AddSignalR();
builder.Services.AddControllers();
builder.Services.AddRazorPages();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlite<OrderDbContext>(connectionString);
builder.Services.AddCors(options =>
{
    options.AddPolicy("Default", builder =>
    {
        builder.AllowAnyOrigin();
    });
});
builder.Services.AddHttpClient();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.MapHub<ChatHub>("/chathub");
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
//app.UseCors();
await CreateDb(app.Services, app.Logger);
app.Run();

async Task CreateDb(IServiceProvider services, ILogger logger)
{
    using var db = services.CreateScope().ServiceProvider.GetRequiredService<OrderDbContext>();
    await db.Database.MigrateAsync();
}