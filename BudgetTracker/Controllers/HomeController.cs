using BudgetTracker.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BudgetTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IEnumerable<EndpointDataSource> endpointDataSources)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var myBudgets = new List<Budget>() {
                new Budget()
                {
                    Id = 1,
                    Name= "Test 1",
                    Amount= 150000,
                    Description= "Test Description 1",
                },
                new Budget()
                {
                    Id = 2,
                    Name= "Test 2",
                    Amount= 20000,
                    Description="Test Description 2"
                },
                new Budget() {
                    Id = 3,
                    Amount= 35500.58M ,
                    Name="Test 3",
                    Description="Test Description 3",

                }
            };
            return View(myBudgets);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}