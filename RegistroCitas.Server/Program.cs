using RegistroCitas.BD.Data;
using RegistroCitas.Server.Repositorio;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;
//------------------------------------------------------------------
//configuracion de los servicios en el constructor de la aplicación
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOutputCache(options =>
{
    options.DefaultExpirationTimeSpan = TimeSpan.FromMinutes(60);
});

//builder.Services.AddStackExchangeRedisCache(options =>
//{
//    options.InstanceName = "Proyecto2024_";
//    options.Configuration = builder.Configuration.GetConnectionString("redis");
//});

builder.Services.AddControllers().AddJsonOptions(
    x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Context>(op => op.UseSqlServer("name=conn"));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<Context>()
                .AddDefaultTokenProviders();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(
                System.Text.Encoding.UTF8.GetBytes(builder.Configuration["jwtkey"]))
        };
    });

builder.Services.AddAutoMapper(typeof(Program));

//builder.Services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
//builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
//builder.Services.AddScoped<IProductoRepositorio, ProductoRepositorio>();
//builder.Services.AddScoped<IProveedorRepositorio, ProveedorRepositorio>();


//--------------------------------------------------------------------
//construccón de la aplicación
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();

app.UseAuthentication();
app.UseAuthorization();

app.UseOutputCache();

app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();