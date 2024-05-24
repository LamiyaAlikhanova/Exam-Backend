using Microsoft.AspNetCore.Mvc;
using Revas.DAL;
using Revas.Models;
using System.Diagnostics;

namespace Revas.Controllers
{
	public class HomeController : Controller
	{
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
		{
			return View(_context.portfolios.ToList());
		}
 
	}
}
