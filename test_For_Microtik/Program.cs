//using FluentValidation;
//using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
//using Serilog;
//using test_For_Microtik.Application.Departments;
//using test_For_Microtik.Application.Departments.Validators;
using test_For_Microtik.Application.Interfaces;
using test_For_Microtik.Application.Role;
//using test_For_Microtik.Application.Roles.Validators;
using test_For_Microtik.Application.Users;
using test_For_Microtik.Application.Users.Command.Create;

//using test_For_Microtik.Application.Users.Validators;
using test_For_Microtik.Infrastructure;
using test_For_Microtik.Infrastructure.MikroTik;
using tik4net.Objects;

var builder = WebApplication.CreateBuilder(args);

// ----------------------
// Serilog Logging
// ----------------------
//Log.Logger = new LoggerConfiguration()
//    .ReadFrom.Configuration(builder.Configuration)
//    .WriteTo.Console()
//    .CreateLogger();

//builder.Host.UseSerilog();

// ----------------------
// Swagger
// ----------------------
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




builder.Services.AddControllers();
// ----------------------
// Controllers + FluentValidation
// ----------------------
//builder.Services.AddControllers()
//       .AddFluentValidation(fv =>
//       {
//           fv.RegisterValidatorsFromAssemblyContaining<CreateUserCommandValidator>();
//       });

// ----------------------
// DbContext
// ----------------------
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ----------------------
// MediatR
// ----------------------
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblyContaining<CreateUserCommand>();
});

// ----------------------
// MikroTik Service
// ----------------------
builder.Services.AddScoped<IMikroTikService, MikroTikService>();

// ----------------------
// Build App
// ----------------------
var app = builder.Build();

// ----------------------
// Middleware
// ----------------------
app.UseSwagger();
app.UseSwaggerUI();

// (Optional) Authentication Middleware
// app.UseAuthentication();
// app.UseAuthorization();

app.MapControllers();

app.Run();