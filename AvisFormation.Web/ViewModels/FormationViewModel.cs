using AvisFormation.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace AvisFormation.Web.ViewModels
{
    public class FormationViewModel
    {
        public int Id { get; set; }

        public string Titre { get; set; }
        
        public string Description { get; set; }
        
        public string Lien { get; set; }
      
        public string ImageURL { get; set; }
        
        public double Prix { get; set; }

        public double MoyenneAvis { get; set; }

        public int NombreAvis { get; set; }

        public bool EstPopulaire { get; set; }

        public List<Avis> Avis { get; set; } = new List<Avis>();

        public List<FormationViewModel> FormationsSimilaires { get; set; }

    }
}
