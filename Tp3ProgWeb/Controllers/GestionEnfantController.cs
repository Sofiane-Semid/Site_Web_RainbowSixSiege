using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tp2ProgWeb.Models;

namespace Tp2ProgWeb.Controllers
{
    public class GestionEnfantController : Controller
    {
        private Database _db { get; set; }

        public GestionEnfantController(Database db)
        {
            _db = db;
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var enfant = _db.Enfants.FirstOrDefault(x => x.Id == id);

            if (enfant == null)
            {
                return View("NotFound");
            }
            return View("Index", enfant);
        }

        // POST: GestionEnfantController/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, Enfant item)
        {
            try
            {
                var enfant = _db.Enfants.FirstOrDefault(e => e.Id == id);

                if (enfant == null)
                {
                    
                    return View("NotFound");
                }

                var parent = _db.Parents.FirstOrDefault(p => p.Id == enfant.IdParent);

                if (parent != null)
                {
                    
                    parent.Enfants.Remove(enfant);
                }

                _db.Enfants.Remove(enfant);

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }
    }
}
