using Microsoft.EntityFrameworkCore;
using SistemaCadastro.Data;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Adicionar serviços MVC
builder.Services.AddControllersWithViews();

// 🔹 Adicionar autorização (resolve seu erro)
builder.Services.AddAuthorization();

// 🔹 Conexão com banco
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// 🔹 Pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// 🔹 Ordem IMPORTA
app.UseAuthorization();

// 🔹 Rotas
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();