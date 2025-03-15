using AutoMapper;
using ContactsMasterData.DBContext;
using ContactsMasterData.IRepository;
using ContactsMasterData.Repository;
using ContactsMasterLogic.AutoMapper;
using ContactsMasterLogic.BusinessLogic;
using ContactsMasterLogic.IBusinessLogic;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register In-Memory Database
builder.Services.AddDbContext<ContactsMasterDbContext>(options =>
    options.UseInMemoryDatabase("ContactsDB"));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
    {
        builder.WithOrigins("http://localhost:3000")  // Allow your React app URL
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});
#region Custom business logic and repository logic dependency injection	
builder.Services.AddTransient<IContactLogic, ContactLogic>();
builder.Services.AddTransient<IContactRepository, ContactRepository>();
#endregion

#region AutoMapper

var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new AutoMapperProfile());
});
builder.Services.AddHttpContextAccessor();
var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

#endregion


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ContactsMasterDbContext>();
    dbContext.Database.EnsureCreated(); // Ensures the in-memory database is initialized
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("AllowSpecificOrigin");
app.MapControllers();

app.Run();
