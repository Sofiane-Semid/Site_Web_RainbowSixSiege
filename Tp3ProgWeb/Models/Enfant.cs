namespace Tp2ProgWeb.Models
{
    public class Enfant
    {
        public string Nom { get; set; }
        public string Description { get; set; }
        public string Âge { get; set; }
        public string Camp { get; set; }
        public string Clan { get; set; }
        public string Abilité { get; set; }
        public string Fonction { get; set; }
        public string ImageEnfant { get; set; }
        public int NiveauDeDifficultés { get; set; }
        public int Id { get; set; }
        public int IdParent { get; set; }
        public Parent Parent { get; set; }


    }
}
