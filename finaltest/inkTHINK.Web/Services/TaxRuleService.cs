public class TaxRuleService
{
    private readonly HttpClient _http;

    public TaxRuleService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<TaxRuleService>> GetTaxRulesAsync()
    {
        return await _http.GetFromJsonAsync<List<TaxRuleService>>("https://localhost:5062/api/taxrules");
    }
}
