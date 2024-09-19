using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;

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
}
