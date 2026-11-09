namespace Tp2ProgWeb.ViewModels
{
    public class CritereRechercheViewModel
    {
        public string MotsCles { get; set; }
        public int? MinNiveauDifficultés { get; set; }
        public int? MaxNiveauDifficultés { get; set; }
        public string OperatorType { get; set; }
        public bool EstSupport { get; set; }
        public bool EstBreacher { get; set; }
        public bool EstAntiGadget { get; set; }
    }
}
