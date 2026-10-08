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

        var request = new HttpRequestMessage(
    HttpMethod.Get,
    $"{url}/rest/v1/congregacoes"
);

        request.Headers.Add("apikey", key);

        var response = await _httpClient.SendAsync(request);

        var igrejas = await response.Content.ReadFromJsonAsync<List<Igreja>>(
    new JsonSerializerOptions
    {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
    }
);

        return Ok(igrejas);
    }

    [HttpGet("busca")]
    public async Task<IActionResult> BuscarIgrejas([FromQuery] string q)
    {
        if (string.IsNullOrWhiteSpace(q))
        {
            return BadRequest("Informe um termo para pesquisa.");
        }

        var url = _configuration["Supabase:Url"];
        var key = _configuration["Supabase:Key"];

        var request = new HttpRequestMessage(
            HttpMethod.Post,
            $"{url}/rest/v1/rpc/buscar_igrejas"
        );

        request.Headers.Add("apikey", key);

        request.Content = JsonContent.Create(new
        {
            search_term = q
        });

        var response = await _httpClient.SendAsync(request);

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();

            return StatusCode(
                (int)response.StatusCode,
                error
            );
        }

        var igrejas = await response.Content.ReadFromJsonAsync<List<Igreja>>(
            new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
            }
        );

        return Ok(igrejas);
    }
}