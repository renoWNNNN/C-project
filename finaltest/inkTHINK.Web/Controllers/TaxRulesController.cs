using Microsoft.AspNetCore.Mvc;

public class TaxRulesController : Controller
{
    private readonly TaxRuleService _service;

    public TaxRulesController(TaxRuleService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var rules = await _service.GetTaxRulesAsync();
        return View(rules);
    }
}
