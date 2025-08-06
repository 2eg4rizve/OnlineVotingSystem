using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OnlineVotingSystem.Data;
using OnlineVotingSystem.Managers.Interface;
using OnlineVotingSystem.Managers.Manager;
using OnlineVotingSystem.Repositories.Interface;
using OnlineVotingSystem.Repositories.Repository;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// 1️⃣ Add DB Context: SQL Server with retry for transient faults
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: TimeSpan.FromSeconds(10),
                errorNumbersToAdd: null);
        }));

// 2️⃣ Dependency Injection
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserManager, UserManager>();

builder.Services.AddScoped<IVotingOccasionRepository, VotingOccasionRepository>();
builder.Services.AddScoped<IVotingOccasionManager, VotingOccasionManager>();

builder.Services.AddScoped<IVotingCategoryRepository, VotingCategoryRepository>();
builder.Services.AddScoped<IVotingCategoryManager, VotingCategoryManager>();

builder.Services.AddScoped<IStartVotingRepository, StartVotingRepository>();
builder.Services.AddScoped<IStartVotingManager, StartVotingManager>();



builder.Services.AddScoped<IVotingOccasionsLevelRepository, VotingOccasionsLevelRepository>();
builder.Services.AddScoped<IVotingOccasionsLevelManager, VotingOccasionsLevelManager>();

builder.Services.AddScoped<IVotingOccasionsLevelMapRepository, VotingOccasionsLevelMapRepository>();
builder.Services.AddScoped<IVotingOccasionsLevelMapManager, VotingOccasionsLevelMapManager>();


builder.Services.AddScoped<IApplyVoteRepository, ApplyVoteRepository>();
builder.Services.AddScoped<IApplyVoteManager, ApplyVoteManager>();
builder.Services.AddHttpContextAccessor();


builder.Services.AddScoped<IWinnerRepository, WinnerRepository>();
builder.Services.AddScoped<IWinnerManager, WinnerManager>();





// 3️⃣ JWT Authentication Configuration
var jwtKey = builder.Configuration["Jwt:Key"];
var jwtIssuer = builder.Configuration["Jwt:Issuer"];

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = true;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = jwtIssuer,
            ValidAudience = jwtIssuer,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
            ClockSkew = TimeSpan.Zero
        };
    });

// 4️⃣ Authorization
builder.Services.AddAuthorization();

// 5️⃣ Swagger with JWT Support
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Online Voting System API", Version = "v1" });

    // Add JWT Authentication to Swagger
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' followed by space and your JWT token.\n\nExample: Bearer eyJhbGciOiJIUzI1NiIsInR5c..."
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddControllers();

var app = builder.Build();

// 6️⃣ Middleware Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Online Voting System API v1");
        c.RoutePrefix = ""; // open Swagger at root
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();


//dotnet ef migrations add AddVotingCategory
//dotnet ef database update