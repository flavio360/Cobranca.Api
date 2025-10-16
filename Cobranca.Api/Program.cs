using AutoMapper;
using Cobranca.Api.Config.DataBase;
using Cobranca.Api.Config.Swagger;
using Cobranca.Api.Data.Interface;
using Cobranca.Api.Data.Repository;
using Cobranca.Api.Service;
using Cobranca.Api.Service.Interface;
using Cobranca.Api.Service.Seguranca;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

#region Data Base

var ambiente = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
var DBSecret = Environment.GetEnvironmentVariable("DESKTOP-UK3VFUT") ?? "DESKTOP-UK3VFUT";
var UserSecret = Environment.GetEnvironmentVariable("UserSecret") ?? "impacto.cobranca";
var PassSecret = Environment.GetEnvironmentVariable("PassSecret") ?? "1mp@cto$";
var CatalogSecret = Environment.GetEnvironmentVariable("Impacto_Cobranca_Prod") ?? "Impacto_Cobranca_Prod";
#endregion

#region DB / DI
var srtConnection =
    $"Application Name=Reports_API;Data Source={DBSecret};Initial Catalog={CatalogSecret};User Id={UserSecret};Password={PassSecret};Connection Timeout=100;Encrypt=false;TrustServerCertificate=true;";

// registre SqlConnection explicitamente
builder.Services.AddScoped<SqlConnection>(_ => new SqlConnection(srtConnection));

// seu wrapper
builder.Services.AddScoped(typeof(IConnection), typeof(Connection));
#endregion

#region AutoMapper (?? se suspeitar, comente estas 2 linhas para testar)
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
// builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
#endregion




// Add services to the container.
builder.Services.AddControllersWithViews();

#region Services / Repos



builder.Services.AddSwaggerGen(options =>
{
    ImpSwaggerGen.ConfigureSwaggerGen(options);
    ImpSwaggerGenOptions.ConfigureSwaggerGenOptions(options);
});

ImpSwaggerApiVersioning.AddApiVersioning(builder.Services);
builder.Services.ConfigureOptions<ImpConfigureSwaggerOptions>();


builder.Services.AddScoped<ICobrancaService, CobrancaService>();
builder.Services.AddScoped<ILoginService, LoginService>();

builder.Services.AddScoped<ICobrancaRepository, CobrancaRepository>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
#endregion

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
