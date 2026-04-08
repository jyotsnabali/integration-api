using Microsoft.AspNetCore.Mvc;

namespace IntegrationApi.Controllers;

[ApiController]
[Route("process")]
public class ProcessController : ControllerBase
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string _backendApiUrl;

    public ProcessController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _backendApiUrl = configuration["DownstreamServices:BackendApiUrl"]
            ?? throw new InvalidOperationException("DownstreamServices:BackendApiUrl is not configured.");
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var client = _httpClientFactory.CreateClient();
        using var response = await client.GetAsync($"{_backendApiUrl}/process");
        response.EnsureSuccessStatusCode();
        return Ok("Integration processed request");
    }
}
