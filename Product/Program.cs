using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Product.DAL;
using Product.DAL.Interfaces;
using Product.DAL.Repositories;
using Product.MIddleware;
using Product.Services.Implementations;
using Product.Services.Interfaces;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers().AddJsonOptions(options => 
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); ;
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IAdministratorRepository, AdministratorRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IInviteRepository, InviteRepository>();
builder.Services.AddScoped<IVendorRepository, VendorRepository>();
builder.Services.AddScoped<IVendorFacilityRepository, VendorFacilityRepository>();
builder.Services.AddScoped<IVendorFacilityServiceRepository, VendorFacilityServiceRepository>();
builder.Services.AddScoped<IVendorUserRepository, VendorUserRepository>();
builder.Services.AddScoped<IOperatorRepository, OperatorRepository>();
builder.Services.AddScoped<IOperatorIndustryRepository, OperatorIndustryRepository>();
builder.Services.AddScoped<IOperatorUserRepository, OperatorUserRepository>();

builder.Services.AddScoped<IAdministratorService, AdministratorService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IVendorService, VendorService>();
builder.Services.AddScoped<IFacilityService, FacilityService>();
builder.Services.AddScoped<IVendFacilityService, VendFacilityService>();
builder.Services.AddScoped<IVendorUserService, VendorUserService>();
builder.Services.AddScoped<IOperatorService, OperatorService>();
builder.Services.AddScoped<IOperatorIndustryService, OperatorIndustryService>();
builder.Services.AddScoped<IOperatorUserService, OperatorUserService>();
builder.Services.AddScoped<IInviteService, InviteService>();
builder.Services.AddScoped<IEmailService, EmailService>();




var app = builder.Build();

app.UseMiddleware<MyExceptionHandlingMiddleware>(); 

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
