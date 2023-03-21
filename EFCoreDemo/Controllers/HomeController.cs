using EFCoreDemo.Context;
using EFCoreDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EFCoreDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        EFCoreDemoContext _context;

        public HomeController(EFCoreDemoContext eFCoreDemoContext, ILogger<HomeController> logger)
        {
            _context = eFCoreDemoContext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            //Yazar yazar = _context.Yazars.FirstOrDefault(x => x.ID == 1);
            //Kitap kitap = new Kitap()
            //{
            //    Name = "Sefiller",
            //    Type = "Novel",
            //    Price = 5,
            //    Yazar = yazar
            //};
            //_context.Kitaps.Add(kitap);
            //_context.SaveChanges();
            return View();
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