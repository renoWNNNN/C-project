using Microsoft.AspNetCore.Mvc;
using inkTHINK.Web.Models;

namespace inkTHINK.Web.Controllers
{
    public class TaxController(ITaxService taxService) : Controller
    {
        private readonly ITaxService _taxService = taxService;

        [HttpGet]
        public IActionResult Index() => View();

        [HttpPost]
        public IActionResult CalculateITBIS(decimal amount)
        {
            var result = _taxService.CalculateITBIS(amount);
            return View("Index", result);
        }

        [HttpPost]
        public IActionResult CalculateIncomeTax(decimal amount)
        {
            var result = _taxService.CalculateIncomeTax(amount);
            return View("Index", result);
        }
    }
}
