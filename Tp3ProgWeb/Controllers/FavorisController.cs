using Tp2ProgWeb.Models;
using Microsoft.AspNetCore.Mvc;




namespace Tp2ProgWeb.Controllers
{
    public class FavorisController : Controller
    {
       
        private Database _db { get; set; }

        public FavorisController(Database db)
        {
            _db = db;
        }
        [Route("Favoris/Favoris")]
        [Route("Favoris")]
        public IActionResult Favoris()
        {
            var enfantIDs = HttpContext.Session.Get<List<int>>("enfantIDs");
            if(enfantIDs == null)
            {
                enfantIDs = new List<int>();
            }

            var enfantsDeLaBD = _db.Enfants.Where(e => enfantIDs.Contains(e.Id))
                .ToList();

            return View(enfantsDeLaBD);
        }
       
        [HttpPost]
        public IActionResult AjouterUnEnfant(int id)
        {
            var enfantIDs = HttpContext.Session.Get<List<int>>("enfantIDs");
            if(enfantIDs == null)
            {
                enfantIDs = new List<int>();
            }
            if (!enfantIDs.Contains(id))
            {
                enfantIDs.Add(id);
                HttpContext.Session.Set("enfantIDs", enfantIDs);
            }

            return RedirectToAction("Favoris");
        }

        [HttpPost]
        public IActionResult SupprimerUnEnfant(int id)
        {
            var enfantIDs = HttpContext.Session.Get<List<int>>("enfantIDs");
            if (enfantIDs == null)
            {
                enfantIDs = new List<int>();
            }
            if (enfantIDs.Contains(id))
            {
                enfantIDs.Remove(id);
                HttpContext.Session.Set("enfantIDs", enfantIDs);
            }

            return RedirectToAction("Favoris");
        }
    }
}
