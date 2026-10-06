using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using igreja_cristo_net_api.Models;

namespace igreja_cristo_net_api.Controllers;

[ApiController]
[Route("api/igrejas")]
public class IgrejasController : ControllerBase
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public IgrejasController(
        HttpClient httpClient,
        IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    [HttpGet]
    public async Task<IActionResult> GetIgrejas()
    {
        var url = _configuration["Supabase:Url"];

        var key = _configuration["Supabase:Key"];

        _httpClient.DefaultRequestHeaders.Add("apikey", key);

        var response = await _httpClient.GetAsync(
            $"{url}/rest/v1/congregacoes"
        );

        var igrejas = await response.Content.ReadFromJsonAsync<List<Igreja>>(
    new JsonSerializerOptions
    {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
    }
);

        return Ok(igrejas);
    }

    [HttpGet("{cidade}")]
    public IActionResult GetIgreja(string cidade)
    {
        return Ok($"Vamos buscar a igreja de {cidade} no Supabase");
    }
}