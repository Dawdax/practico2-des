using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public class CandidatoController : Controller
{
	private readonly ApiService _apiService;

	public CandidatoController(ApiService apiService)
	{
		_apiService = apiService;
	}

	// Acción para mostrar el formulario de registro
	public IActionResult Register()
	{
		return View();
	}

	// Acción para procesar el registro del candidato
	[HttpPost]
	public async Task<IActionResult> Register(CandidatoDto candidatoDto)
	{
		if (ModelState.IsValid)
		{
			var success = await _apiService.RegisterCandidatoAsync(candidatoDto);
			if (success)
			{
				return RedirectToAction("Success");
			}
			ModelState.AddModelError(string.Empty, "Error al registrar el candidato.");
		}
		return View(candidatoDto);
	}

	// Acción para mostrar la página de éxito
	public IActionResult Success()
	{
		return View();
	}
}
