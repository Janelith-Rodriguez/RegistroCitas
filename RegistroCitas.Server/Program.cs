using Microsoft.EntityFrameworkCore;
using RegistroCitas.BD.Data;
using RegistroCitas.BD.Data.Entity;
using RegistroCitas.Server.Repositorio;
using System.Text.Json.Serialization;

//-----------------------------------------------------------------------------------------------------
//Configuracion de los servicios en el constructor de la aplicacion
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddControllersWithViews().AddJsonOptions(
    x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddRazorPages();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Context>(op => op.UseSqlServer("name=conn"));

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IContactosEmergenciaRepositorio, ContactosEmergenciaRepositorio>();
builder.Services.AddScoped<ITDocumentoRepositorio, TDocumentoRepositorio>();

//------------------------------------------------------------------------------------------------------
//construcción de la aplicación
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
app.MapRazorPages();
app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.MapFallbackToFile("index.html");
app.Run();
