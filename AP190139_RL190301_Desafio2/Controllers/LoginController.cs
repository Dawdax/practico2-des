using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public class LoginController : Controller
{
	private readonly ApiService _apiService;

	public LoginController(ApiService apiService)
	{
		_apiService = apiService;
	}

	// Acción para mostrar el formulario de login
	public IActionResult Index()
	{
		return View();
	}

	// Acción para procesar el login
	[HttpPost]
	public async Task<IActionResult> Index(LoginDto loginDto)
	{
		if (ModelState.IsValid)
		{
			var success = await _apiService.LoginAsync(loginDto);
			if (success)
			{
				// Aquí puedes redirigir a la vista del usuario después del login exitoso
				return RedirectToAction("Profile", "Candidato");
			}
			ModelState.AddModelError(string.Empty, "Correo o contraseña incorrectos.");
		}
		return View(loginDto);
	}

	// Acción para redirigir al registro si no está registrado
	public IActionResult Register()
	{
		return RedirectToAction("Register", "Candidato");
	}
}
