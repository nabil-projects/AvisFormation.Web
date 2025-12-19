using AvisFormation.Data.Entities;

namespace AvisFormation.Web.ViewModels
{
    public class AccueilViewModel
    {
        public List<FormationViewModel> Formations { get; set; }
        public int NomberFormations { get; set; }
        public int NomberAvis { get; set; }
    }
}
