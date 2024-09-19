var builder = WebApplication.CreateBuilder(args);

// Inyectar HttpClient y ApiService
builder.Services.AddHttpClient<ApiService>();

builder.Services.AddControllersWithViews();  // Para permitir vistas en MVC

var app = builder.Build();

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
	pattern: "{controller=Candidato}/{action=Register}/{id?}");
app.Run();
