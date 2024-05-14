using System.Reflection;
using ManageStudents.Data;
using ManageStudents.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
.AddCookie()
.AddOpenIdConnect(options => {
    options.ResponseType = builder.Configuration["Authentication:Cognito:ResponseType"]!;
    options.MetadataAddress = builder.Configuration["Authentication:Cognito:MetadataAddress"]!;
    options.ClientId = builder.Configuration["Authentication:Cognito:ClientId"]!;
});

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.UseAuthentication();

app.Run();

