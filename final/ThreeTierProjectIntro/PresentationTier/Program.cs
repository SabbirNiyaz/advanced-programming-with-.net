using DataTier.EF;
using DataTier.Repos;
using LogicTier.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Own create services DI
builder.Services.AddScoped<CategoryRepo>();
//builder.Services.AddScoped<ProductRepo>();

builder.Services.AddScoped(typeof(Repository<>)); // Generic Repo DI

builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<ProductService>();

// DI
builder.Services.AddDbContext<DatabaseRepresentContext>(opt => {
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConn"));
});

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
