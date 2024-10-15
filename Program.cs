using CareWithLoveApp.Data;
using CareWithLoveApp.Models.Entities;
using CareWithLoveApp.Repositories;
using CareWithLoveApp.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<User, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Instanciando as services e reps
builder.Services.AddScoped<IDependenteService, DependenteService>();
builder.Services.AddScoped<IDependenteRepository, DependenteRepository>();

builder.Services.AddScoped<ICuidadorRepository, CuidadorRepository>();
builder.Services.AddScoped<ICuidadorService, CuidadorService>();

builder.Services.AddScoped<IServicoClienteService, ServicoClienteService>();
builder.Services.AddScoped<IServicoClienteRepository, ServicoClienteRepository>();

builder.Services.AddScoped<IServicoCuidadorRepository, ServicoCuidadorRepository>();
builder.Services.AddScoped<IServicoCuidadorService, ServicoCuidadorService>();

builder.Services.AddScoped<IAvaliacaoRepository, AvaliacaoRepository>();
builder.Services.AddScoped<IAvaliacaoService, AvaliacaoService>();

builder.Services.AddDbContext<MainContext>(
    options => options.UseSqlServer(connectionString)
);

builder.Services.AddTransient<IEmailSender, NoEmailSender>();

//////////////////////////
var app = builder.Build();
//////////////////////////



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();