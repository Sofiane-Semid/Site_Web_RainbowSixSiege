namespace Tp2ProgWeb.Models
{
    public class Favoris
    {
        public int IdFavoris { get; set; }
        public List<Enfant> Enfants { get; set; }
        public string ImageFavoris { get; set; }
        public string NomFavoris { get;set; }
        public string FonctionFavoris { get; set; }
        public int NiveauDeDifficultésFavoris { get; set; }

    }
}
