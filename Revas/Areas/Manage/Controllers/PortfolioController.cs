using Microsoft.AspNetCore.Mvc;
using Revas.DAL;
using Revas.Models;

namespace Revas.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class PortfolioController : Controller
    {

        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public PortfolioController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public IActionResult Index()
        {
            return View(_context.portfolios.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Create(Portfolio portfolios)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (!portfolios.ImgFile.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("image", "File duzgun daxil edin");
            }
            string path = _environment.WebRootPath + @"\Upload\";
            string filename = Guid.NewGuid() + portfolios.ImgFile.FileName;
            using (FileStream stream = new FileStream(path + filename, FileMode.Create))
            {
                portfolios.ImgFile.CopyTo(stream);
            }
            portfolios.ImgUrl = filename;
            _context.portfolios.Add(portfolios);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var portfolios = _context.portfolios.FirstOrDefault(x => x.Id == id);
            if (portfolios == null)
            {
                return View();
            }
            return View(portfolios);

        }
        [HttpPost]

        public IActionResult Update(Portfolio portfolios)
        {
            var oldservices = _context.portfolios.FirstOrDefault(x => x.Id == portfolios.Id);
            if (oldservices == null)
            {
                return View();
            }
            if (portfolios.ImgFile != null)
            {
                string path = _environment.WebRootPath + @"\Upload\";
                FileInfo fileInfo = new FileInfo(path + oldservices.ImgUrl);
                if (fileInfo.Exists)
                {
                    fileInfo.Delete();
                }
                string filename = portfolios.ImgFile.FileName;
                using (FileStream stream = new FileStream(path + filename, FileMode.Create))
                {
                    portfolios.ImgFile.CopyTo(stream);
                }
                oldservices.ImgUrl = filename;
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var services = _context.portfolios.FirstOrDefault(x => x.Id == id);
            if (services == null)
            {
                return View();
            }
            _context.portfolios.Remove(services);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}