using CarCheck.Application.Services.Implement;
using CarCheck.Application.Services.Interfaces;
using CarCheck.Domain.Core.Contract.Repositories;
using CarCheck.Domain.Core.Contract.Services;
using CarCheck.Domain.Service.Service;
using CarCheck.Infrastructure.EFCore.Persistence;
using CarCheck.Infrastructure.EFCore.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorPages();
builder.Services.AddDbContext<CarCheckDbContext>(options =>
    options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CarCheck;Trusted_Connection=True"));





// Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
builder.Services.AddScoped<IInspectionRequestRepository, InspectionRequestRepository>();
builder.Services.AddScoped<IVehicleModelRepository, VehicleModelRepository>();

// AppServices
builder.Services.AddScoped<IUserAppService, UserAppService>();
builder.Services.AddScoped<IVehicleAppService, VehicleAppService>();
builder.Services.AddScoped<IInspectionRequestAppService, InspectionRequestAppService>();

//Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IInspectionRequestService, IInspectionRequestService>();
builder.Services.AddScoped<IVehicleService, VehicleService>();







var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
