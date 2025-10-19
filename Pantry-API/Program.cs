using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var conString = builder.Configuration.GetConnectionString("PantryDb") ?? 
    throw new InvalidOperationException("Connection string 'PantryDb' not found.");

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Persistence.PantryDbContext>(options=> 
    options.UseSqlServer(conString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

