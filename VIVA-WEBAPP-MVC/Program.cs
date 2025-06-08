using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MOTTHRU.API.Application.Interfaces;
using MOTTHRU.API.Application.Services;
using MOTTHRU.API.Domain.Interfaces;
using MOTTHRU.API.Infrastructure.Data.AppData;
using MOTTHRU.API.Infrastructure.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<ApplicationContext>(options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres"));
});

builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<IUsuarioApplicationService, UsuarioApplicationService>();

builder.Services.AddSwaggerGen(conf =>
{
    conf.SwaggerDoc("v1", new OpenApiInfo()
    {
        Title = "VIVA API",
        Version = "v1",
        Description = "API Para gerenciar o backend da solução VIVA.",
    });
    conf.EnableAnnotations();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "VIVA API V1");
        c.RoutePrefix = "swagger";
    });
} else {
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllers();

app.Run();