var builder = WebApplication.CreateBuilder(args);

// Inyectar HttpClient y ApiService
builder.Services.AddHttpClient<ApiService>();

builder.Services.AddControllersWithViews();  // Para permitir vistas en MVC

// Agregar soporte para la sesión
builder.Services.AddDistributedMemoryCache();  // Usar una cache en memoria para las sesiones
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);  // Duración de la sesión
    options.Cookie.HttpOnly = true;  // La cookie solo se accede a través de HTTP
    options.Cookie.IsEssential = true;  // Asegura que la cookie es esencial
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Habilitar el middleware de sesión antes de la autorización
app.UseSession();  // Necesario para habilitar la sesión

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
