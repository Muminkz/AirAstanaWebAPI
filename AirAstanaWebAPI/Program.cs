

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Infrastructure.DataDbContext;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Repositories;
using Application.Mappings;
using Application.Interfaces;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(c => {
    c.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    c.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    c.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x => {
    x.RequireHttpsMetadata = false;
    x.SaveToken = false;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8
            .GetBytes(builder.Configuration["ApplicationSettings:SecretKey"])
        ),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero
    };
});
builder.WebHost.UseIISIntegration();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AirAstana WebAPI", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement{
    {
        new OpenApiSecurityScheme{
            Reference = new OpenApiReference{
                Id = "Bearer",
                Type = ReferenceType.SecurityScheme
            }
        },
        new List<string>()
    }});
});
//builder.Services.AddDbContext<DataContext>(options =>
//           options.UseSqlServer(builder.Configuration.GetConnectionString("SQL")));
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQL"));
    options.EnableSensitiveDataLogging();
});

builder.Services.AddScoped<IFlightService, FlightRepository>();
builder.Services.AddScoped<IRolesService, RolesRepository>();
builder.Services.AddScoped<IUserService, UserRepository>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
