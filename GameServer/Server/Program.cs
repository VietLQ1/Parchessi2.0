
using Microsoft.EntityFrameworkCore;
using Server.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<GameDbContext>(options =>
{
    // Retrieve the connection string from the configuration and use it in the options
    string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    
    if (connectionString != null) options.UseMySql(connectionString, 
        ServerVersion.AutoDetect(connectionString));
});



builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();