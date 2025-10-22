using Business.ItemServices;
using Business.UserServices;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Repository.ItemsRepository;
using Persistence.Repository.UsersRepository;

var builder = WebApplication.CreateBuilder(args);

var conString = builder.Configuration.GetConnectionString("PantryDbLaptop") ?? 
    throw new InvalidOperationException("Connection string 'PantryDb' not found.");

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PantryDbContext>(options=> 
    options.UseSqlServer(conString, sql => sql.MigrationsAssembly(typeof(PantryDbContext).Assembly.FullName)));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserServices, UserServices >();
builder.Services.AddScoped<IItemsRepository, ItemsRepository>();
builder.Services.AddScoped<IItemServices, ItemServices>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{     var dbContext = scope.ServiceProvider.GetRequiredService<PantryDbContext>();
    dbContext.Database.Migrate();
}

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

app.MapControllers();

app.Run();

