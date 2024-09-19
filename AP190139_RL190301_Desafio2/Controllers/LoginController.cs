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
            var candidatoCodigo = await _apiService.LoginAsync(loginDto);
            if (!string.IsNullOrEmpty(candidatoCodigo))
            {
                // Guardar el código del candidato en la sesión
                HttpContext.Session.SetString("CodigoCandidato", candidatoCodigo);

                // Verificar si el candidato ya tiene una hoja de vida
                var hojaDeVida = await _apiService.GetHojaDeVidaAsync(candidatoCodigo);
                if (hojaDeVida != null)
                {
                    // Si ya tiene hoja de vida, mostrarla
                    return RedirectToAction("MostrarHojaDeVida", "HojaDeVida", new { codigo = candidatoCodigo });
                }
                else
                {
                    // Si no tiene hoja de vida, redirigir al formulario para ingresarla
                    return RedirectToAction("IngresarHojaDeVida", "HojaDeVida");
                }
            }
            ModelState.AddModelError(string.Empty, "Correo o contraseña incorrectos.");
        }
        return View(loginDto);
    }

    public IActionResult Register()
    {
        return RedirectToAction("Register", "Candidato");
    }
}
