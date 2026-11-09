using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Tp2ProgWeb.Models;
using Tp2ProgWeb.ViewModels;

namespace Tp2ProgWeb.Controllers
{
    public class EnfantController : Controller
    {
        private Database _db { get; set; }

        public EnfantController(Database db)
        {
            _db = db;
        }
        [Route("/Enfant/Recherche")]
        public IActionResult Recherche()
        {
            var model = new PageRechercheViewModel();
            model.Criteres = new CritereRechercheViewModel();
            model.Criteres.EstSupport = true;
            model.Criteres.EstBreacher = true;
            model.Criteres.EstAntiGadget = true;
            model.Resultat = _db.Enfants.ToList();
            return View(model);

        }
        [Route("/Enfant/Filtrer")]
        public IActionResult Filtrer(CritereRechercheViewModel criteres)
        {
            var model = new PageRechercheViewModel();
            model.Criteres = criteres;


            IEnumerable<Enfant> operateurs = _db.Enfants;

            if (criteres.MotsCles != null)
            {
                operateurs = operateurs.Where(o => o.Nom.Contains(criteres.MotsCles));
            }

            if (criteres.MinNiveauDifficultés != null)
            {
                operateurs = operateurs.Where(i => i.NiveauDeDifficultés >= criteres.MinNiveauDifficultés);
            }

            if (criteres.MaxNiveauDifficultés != null)
            {
                operateurs = operateurs.Where(a => a.NiveauDeDifficultés <= criteres.MaxNiveauDifficultés);
            }

            if (criteres.OperatorType != null && criteres.OperatorType != "")
            {
                operateurs = operateurs.Where(o => o.Camp.Contains(criteres.OperatorType));
            }

            if (criteres.EstSupport)
            {
                operateurs = operateurs.Where(s => s.Fonction.Contains("Support"));
            }

            if (criteres.EstBreacher)
            {
                operateurs = operateurs.Where(b => b.Fonction.Contains("Breacher"));
            }

            if (criteres.EstAntiGadget)
            {
                operateurs = operateurs.Where(a => a.Fonction.Contains("Anti-Gadget"));
            }

            if (criteres.EstAntiGadget && criteres.EstSupport&& !criteres.EstBreacher)
            {
                operateurs = operateurs.Where(a => a.Fonction.Contains("Anti-Gadget"));
                operateurs = operateurs.Where(s => s.Fonction.Contains("Support"));
            }
            if (criteres.EstSupport && criteres.EstBreacher && !criteres.EstAntiGadget)
            {
                operateurs = operateurs.Where(b => b.Fonction.Contains("Breacher"));
                operateurs = operateurs.Where(s => s.Fonction.Contains("Support"));
            }
            if (criteres.EstAntiGadget && criteres.EstBreacher && !criteres.EstSupport)
            {
                operateurs = operateurs.Where(a => a.Fonction.Contains("Anti-Gadget"));
                operateurs = operateurs.Where(b => b.Fonction.Contains("Breacher"));
            }
            if (criteres.EstAntiGadget && criteres.EstBreacher && criteres.EstSupport)
            {
                model.Resultat = operateurs.ToList();
            }
            model.Resultat = operateurs.ToList();
            return View("Recherche", model);
        }

        [Route("/Enfant/Detail/{id:int}")]
        [Route("/Enfant/{id:int}")]
        [Route("/{id:int}")]
        public IActionResult DetailParId(int id)
        {
            var enfant = _db.Enfants.FirstOrDefault(x => x.Id == id);
                
            if(enfant == null)
            {
                return View("NotFound");
            }
            return View("Detail", enfant);
        }
        
        [Route("/Enfant/Detail/{nom}")]
        [Route("/Enfant/{nom}")]
        [Route("/{nom}")]
        public IActionResult DetailParNom(string nom)
        {
            var enfant = _db.Enfants.Where(x => x.Nom.ToUpper() == nom.ToUpper()).
                SingleOrDefault();
            if (enfant == null)
            {
                return View("NotFound");

            }         
            return View("Detail", enfant);
            
                
        }
    }
}
