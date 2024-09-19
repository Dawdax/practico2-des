using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using Newtonsoft.Json;

public class ApiService
{
	private readonly HttpClient _httpClient;

	public ApiService(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	public async Task<bool> RegisterCandidatoAsync(CandidatoDto candidatoDto)
	{
		var response = await _httpClient.PostAsJsonAsync("https://localhost:7116/api/Candidato/register", candidatoDto);
		return response.IsSuccessStatusCode;
	}
    public async Task<string> LoginAsync(LoginDto loginDto)
    {
        var response = await _httpClient.PostAsJsonAsync("https://localhost:7116/api/Candidato/login", loginDto);
        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<LoginResultDto>(jsonString);
            return result?.Codigo;  // Devolver el código del candidato
        }
        return null;
    }

    public async Task<HojaDeVidaDto> GetHojaDeVidaAsync(string codigoCandidato)
    {
        var response = await _httpClient.GetAsync($"https://localhost:7116/api/HojaDeVida/hojadevida/{codigoCandidato}");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<HojaDeVidaDto>();
        }
        return null;
    }

    public async Task<bool> IngresarHojaDeVidaAsync(HojaDeVidaDto hojaDeVidaDto)
    {
        var candidatoCodigo = hojaDeVidaDto.CandidatoCodigo;
        var response = await _httpClient.PostAsJsonAsync($"https://localhost:7116/api/HojaDeVida/ingresarHojaDeVida?candidatoCodigo={candidatoCodigo}", hojaDeVidaDto);
        return response.IsSuccessStatusCode;
    }
    public async Task<bool> ActualizarHojaDeVidaAsync(HojaDeVidaDto hojaDeVidaDto, string modificacion)
    {
        var candidatoCodigo = hojaDeVidaDto.CandidatoCodigo;
        var response = await _httpClient.PutAsJsonAsync($"https://localhost:7116/api/HojaDeVida/actualizarHojaDeVida?candidatoCodigo={candidatoCodigo}&modificacion={modificacion}", hojaDeVidaDto);
        return response.IsSuccessStatusCode;
    }

}
