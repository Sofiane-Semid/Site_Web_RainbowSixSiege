using Microsoft.AspNetCore.Mvc;
using Tp2ProgWeb.Models;

namespace Tp2ProgWeb.Controllers
{
    public class HomeController : Controller
    {
        private Database _db { get; set; }

        public HomeController(Database db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var parent = _db.Parents.ToList();
            return View(parent);
        }
    }
}
