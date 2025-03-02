using KODPersonalAccount.Application.Directions;
using KODPersonalAccount.Application.Groups;
using KODPersonalAccount.Application.Lessons;
using KODPersonalAccount.Application.Users;
using KODPersonalAccount.Contracts.Directions;
using KODPersonalAccount.Contracts.Groups;
using KODPersonalAccount.Contracts.Lessons;
using KODPersonalAccount.EntityFrameworkCore;
using KODPersonalAccount.EntityFrameworkCore.Implementation.Repository;
using KODPersonalAccount.Interfaces.Repository;
using KODPersonalAccount.Interfaces.Services.Users;
using KODPersonalAccount.Models;
using KODPersonalAccount.Models.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ILessonRepository, LessonRepository>();
builder.Services.AddScoped<ILessonAppService, LessonAppService>();


builder.Services.AddScoped<IGroupRepository, GroupRepository>();
builder.Services.AddScoped<IGroupAppService, GroupAppService>();

builder.Services.AddScoped<IDirectionRepository, DirectionRepository>();
builder.Services.AddScoped<IDirectionAppService, DirectionAppService>();

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

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<DataContext>();
    if (context.Database.GetPendingMigrations().Any())
    {
        context.Database.Migrate();
    }
}

app.Run();