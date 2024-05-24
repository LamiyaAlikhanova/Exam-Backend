using Microsoft.AspNetCore.Mvc;
using Revas.DAL;
using Revas.Models;

namespace Revas.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.portfolios.ToList());
        }

    

    }
}
