using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public class HojaDeVidaController : Controller
{
    private readonly ApiService _apiService;

    public HojaDeVidaController(ApiService apiService)
    {
        _apiService = apiService;
    }

    // Acción para mostrar la hoja de vida
    public async Task<IActionResult> MostrarHojaDeVida(string codigo)
    {
        var hojaDeVida = await _apiService.GetHojaDeVidaAsync(codigo);
        if (hojaDeVida == null)
        {
            return RedirectToAction("IngresarHojaDeVida");
        }

        return View(hojaDeVida);
    }

    // Acción para mostrar el formulario para ingresar una nueva hoja de vida (GET)
    [HttpGet]
    public IActionResult IngresarHojaDeVida()
    {
        // Obtener el código del candidato desde la sesión
        var candidatoCodigo = HttpContext.Session.GetString("CodigoCandidato");

        if (string.IsNullOrEmpty(candidatoCodigo))
        {
            return RedirectToAction("Index", "Login");
        }

        // Pasar el código del candidato a la vista (por ejemplo, en un campo oculto)
        ViewBag.CandidatoCodigo = candidatoCodigo;

        return View();
    }

    // Acción para procesar el ingreso de la hoja de vida (POST)
    [HttpPost]
    public async Task<IActionResult> IngresarHojaDeVida(HojaDeVidaDto hojaDeVidaDto)
    {
        // Obtener el código del candidato desde la sesión
        var candidatoCodigo = HttpContext.Session.GetString("CodigoCandidato");

        if (string.IsNullOrEmpty(candidatoCodigo))
        {
            return RedirectToAction("Index", "Login");
        }

        // Asignar el código del candidato al DTO
        hojaDeVidaDto.CandidatoCodigo = candidatoCodigo;

        // Llamar al servicio para guardar la hoja de vida
        var success = await _apiService.IngresarHojaDeVidaAsync(hojaDeVidaDto);
        if (success)
        {
            return RedirectToAction("MostrarHojaDeVida", new { codigo = candidatoCodigo });
        }

        ModelState.AddModelError(string.Empty, "Error al ingresar la hoja de vida.");
        return View(hojaDeVidaDto);
    }

    [HttpGet]
    public async Task<IActionResult> EditarHojaDeVida()
    {
        // Obtener el código del candidato desde la sesión
        var candidatoCodigo = HttpContext.Session.GetString("CodigoCandidato");

        if (string.IsNullOrEmpty(candidatoCodigo))
        {
            return RedirectToAction("Index", "Login");
        }

        // Obtener los datos actuales de la hoja de vida desde la API
        var hojaDeVida = await _apiService.GetHojaDeVidaAsync(candidatoCodigo);
        if (hojaDeVida == null)
        {
            return RedirectToAction("IngresarHojaDeVida");
        }

        // Pasar los datos de la hoja de vida a la vista
        return View(hojaDeVida);
    }
    [HttpPost]
    public async Task<IActionResult> EditarHojaDeVida(HojaDeVidaDto hojaDeVidaDto)
    {
        // Obtener el código del candidato desde la sesión
        var candidatoCodigo = HttpContext.Session.GetString("CodigoCandidato");

        if (string.IsNullOrEmpty(candidatoCodigo))
        {
            return RedirectToAction("Index", "Login");
        }

        // Asignar el código del candidato al DTO
        hojaDeVidaDto.CandidatoCodigo = candidatoCodigo;

        // Llamar al servicio para actualizar la hoja de vida
        var success = await _apiService.ActualizarHojaDeVidaAsync(hojaDeVidaDto, "Edición realizada");
        if (success)
        {
            return RedirectToAction("MostrarHojaDeVida", new { codigo = candidatoCodigo });
        }

        ModelState.AddModelError(string.Empty, "Error al actualizar la hoja de vida.");
        return View(hojaDeVidaDto);
    }


}
