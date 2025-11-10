using Business.CategoriesService;
using Business.ItemsService;
using Business.StorageLocationsService;
using Business.UsersService;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Persistence;
using Persistence.Repository.CategoriesRepository;
using Persistence.Repository.ItemsRepository;
using Persistence.Repository.StorageLocationsRepository;
using Persistence.Repository.UsersRepository;


var builder = WebApplication.CreateBuilder(args);

var conString = builder.Configuration.GetConnectionString("PantryDbDesktop") ?? 
    throw new InvalidOperationException("Connection string 'PantryDb' not found.");

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PantryDbContext>(options=> 
    options.UseSqlServer(conString, sql => sql.MigrationsAssembly(typeof(PantryDbContext).Assembly.FullName)));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUsersService, UsersService >();

builder.Services.AddScoped<IStorageLocationsRepository, StorageLocationsRepository>();
builder.Services.AddScoped<IStorageLocationsService, StorageLocationsService>();

builder.Services.AddScoped<IItemsRepository, ItemsRepository>();
builder.Services.AddScoped<IItemsService, ItemsService>();

builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();
builder.Services.AddScoped<ICategoriesService, CategoriesService>();

builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<PantryDbContext>();

var app = builder.Build();

app.Use((ctx, next) =>
{
    ctx.Response.Headers.Add("Access-Control-Allow-Origin", "*");
    return next();
});

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

