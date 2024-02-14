using Domain;
using Microsoft.AspNetCore.Mvc;
using ParsaCoffeeShop.Models;
using Service.Interfaces;
using Service.Services;
using System.Diagnostics;

namespace ParsaCoffeeShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ParsaDbContext _context = new ParsaDbContext();
        ICategoryService _categoryService;
        public HomeController()
        {
            _categoryService = new CategoryService(_context);
        }

        public IActionResult Index()
        {
            return View(_categoryService.GetAllCategories());
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