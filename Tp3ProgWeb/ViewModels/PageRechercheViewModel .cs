using Tp2ProgWeb.Models;

namespace Tp2ProgWeb.ViewModels
{
    public class PageRechercheViewModel
    {
        public CritereRechercheViewModel Criteres { get; set; } = new CritereRechercheViewModel();
        public List<Enfant> Resultat { get; set; } = new List<Enfant>();

        public PageRechercheViewModel()
        {
            Criteres = new CritereRechercheViewModel();
            Resultat = new List<Enfant>();
        }
    }
}
