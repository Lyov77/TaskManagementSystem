using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.BLL.Repositories;
using TaskManagementSystem.BLL.Repositories.Base;
using TaskManagementSystem.DAL.Context;
using TaskManagementSystem.DAL.Repositories;
using TaskManagementSystem.DAL.Repositories.Base;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new ArgumentNullException("Connection string is null!");

// Add database
builder.Services.AddDbContext<TaskerApplicationDbContext>(options =>
{
    options.UseSqlServer(connectionString, opt => opt.MigrationsAssembly("TaskManagementSystem.DAL"));
});

// Add Repositories
builder.Services.AddTransient<IRepositoryManager, RepositoryManager>();
builder.Services.AddTransient<ITaskerRepository, TaskerRepository>();

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
