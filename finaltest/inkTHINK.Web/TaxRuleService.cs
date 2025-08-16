using System.Net.Http.Json;
using inkTHINK.Web.Models;

public class TaxRuleService
{
    private readonly HttpClient _http;

    public TaxRuleService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<TaxRuleService>> GetTaxRulesAsync()
    {
#pragma warning disable CS8603 // Possible null reference return.
        return await _http.GetFromJsonAsync<List<TaxRuleService>>("https://localhost:5062/api/taxrules");
#pragma warning restore CS8603 // Possible null reference return.
    }
}
