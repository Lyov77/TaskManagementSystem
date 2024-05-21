using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.BLL.Abstract;
using TaskManagementSystem.BLL.Concrete;
using TaskManagementSystem.DAL.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<TaskerApplicationDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;

    options.UseSqlServer(connectionString);
});

builder.Services.AddTransient<ITaskerRepository, EfTaskerRepository>(provider =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;

    return new EfTaskerRepository(provider.GetRequiredService<ITaskerRepository>(), provider.GetRequiredService<IRepositoryManager>());
});

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
