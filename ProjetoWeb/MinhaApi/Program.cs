using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using MinhaApi.Context;
using MinhaApi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

builder.Services.AddDbContext<MyDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("FortferConnection"));
});

builder.Services.AddDbContext<MyDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("PortaDeAcoConnection"));
});


builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}




app.UseCors(policy =>
    policy.WithOrigins("https://localhost:7164","http://localhost:5139")
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials()
    .WithHeaders(HeaderNames.ContentType)
      
);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
