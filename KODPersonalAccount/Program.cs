using KODPersonalAccount.Application.Groups;
using KODPersonalAccount.Application.Lessons;
using KODPersonalAccount.Contracts.Groups;
using KODPersonalAccount.Contracts.Lessons;
using KODPersonalAccount.EntityFrameworkCore.Implementation.Repository;
using KODPersonalAccount.Interfaces.Repository;
using KODPersonalAccount.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ILessonRepository, LessonRepository>();
builder.Services.AddScoped<ILessonAppService, LessonAppService>();


builder.Services.AddScoped<IGroupRepository, GroupRepository>();
builder.Services.AddScoped<IGroupAppService, GroupAppService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserAppService, UserAppService>();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresSQL"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();

app.Run();