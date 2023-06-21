using BloodBank.DAL.Data;
using Microsoft.EntityFrameworkCore;
using BloodBank.Service.Services;
using BloodBank.DAL.Repository;
using BloodBank.Domain.Interfaces;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Lucene.Net.Support;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
// Add services to the container.
//***************Logging***************
builder.Logging.ClearProviders();
builder.Logging.AddLog4Net();

//***************Authentication***************
//Read Appsettings
var appSettingsSection = builder.Configuration.GetSection("Jwt");
builder.Services.Configure<AppSettings>(appSettingsSection);
//JWT Authentication
var appSettings = appSettingsSection.Get<AppSettings>();
var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]);
//Jwt Configguration
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],

    };
});
builder.Services.AddDbContext<BloodDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BloodCS")));

builder.Services.AddControllers();

builder.Services.AddScoped<IBloodBagRepository, BloodBagRepository>();
builder.Services.AddScoped<IBloodBankCenterRepository, BloodBankCenterRepository>();
builder.Services.AddScoped<IDonorRepository, DonorRepository>();
builder.Services.AddScoped<IRecipientRepository, RecipientRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IBloodBankCenterService, BloodBankCenterService>();
builder.Services.AddScoped<IDonorService, DonorService>();
builder.Services.AddScoped<IRecipientService, RecipientService>();
builder.Services.AddScoped<IBloodBagService, BloodBagService>();
builder.Services.AddScoped<IUserService, UserService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
