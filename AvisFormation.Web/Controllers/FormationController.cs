using AvisFormation.Data;
using AvisFormation.Logic;
using AvisFormation.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AvisFormation.Web.Controllers
{
    public class FormationController : Controller
    {
        private readonly FormationManager _formationManager;

        public FormationController(FormationManager manager)
        {
            _formationManager = manager;
        }
        public IActionResult Index()
        {
            return View(GetListForIndex());
        }
        public IActionResult DetailsFormation(int id)
        {
            var fvm = GetFormationForDetails(id);
            if (fvm == null)
            {
                return NotFound();
            }
            return View(fvm);
        }




        private FormationViewModel GetFormationForDetails(int id)
        {
            var formation = _formationManager.GetById(id);
            if (formation == null)
            {
                return null;
            }


            var fvm = new FormationViewModel();
            fvm.Id = formation.Id;
            fvm.Titre = formation.Titre;
            fvm.Description = formation.Description;
            fvm.Lien = formation.Lien;
            fvm.ImageURL = formation.ImageURL;
            fvm.Prix = formation.Prix;
            if (formation.Avis.Count > 0)
            {
                fvm.MoyenneAvis = formation.Avis.Average(a => a.Note);
                fvm.NombreAvis = formation.Avis.Count;
            }
            else
            {
                fvm.MoyenneAvis = 0;
                fvm.NombreAvis = 0;
            }
            fvm.EstPopulaire = fvm.MoyenneAvis >= 4.0 && fvm.NombreAvis >= 1;

            fvm.Avis = formation.Avis;
            var similaires = _formationManager.GetAll()
    .Where(f => f.Id != formation.Id)
    .Take(3)


    .Select(f => new FormationViewModel
    {
        Id = f.Id,
        Titre = f.Titre,
        ImageURL = f.ImageURL,
        Prix = f.Prix,
        MoyenneAvis = f.Avis.Any() ? f.Avis.Average(a => a.Note) : 0,
        NombreAvis = f.Avis.Count,
        EstPopulaire = (f.Avis.Count > 0 ? f.Avis.Average(a => a.Note) : 0) >= 4.0 && f.Avis.Count >= 1
    }).ToList();

            fvm.FormationsSimilaires = similaires;

            return fvm;



        }





        private AccueilViewModel GetListForIndex()
        {
            var formations = _formationManager.GetAll();
            var formationViewModels = new List<FormationViewModel>();
            foreach (var formation in formations)
            {
                var fvm = new FormationViewModel();
                fvm.Id = formation.Id;
                fvm.Titre = formation.Titre;
                fvm.Description = formation.Description;
                fvm.Lien = formation.Lien;
                fvm.ImageURL = formation.ImageURL;
                fvm.Prix = formation.Prix;
                if (formation.Avis.Count > 0)
                {
                    fvm.MoyenneAvis = formation.Avis.Average(a => a.Note);
                    fvm.NombreAvis = formation.Avis.Count;
                }
                else
                {
                    fvm.MoyenneAvis = 0;
                    fvm.NombreAvis = 0;
                }
                fvm.EstPopulaire = fvm.MoyenneAvis >= 4.0 && fvm.NombreAvis >= 1;
                formationViewModels.Add(fvm);
            }
            var nomberFormations = formations.Count;
            var nomberAvis = formations.Sum(f => f.Avis.Count);
            var VM = new AccueilViewModel
            {
                Formations = formationViewModels,
                NomberFormations = nomberFormations,
                NomberAvis = nomberAvis
            };
            return VM;
        }
    }
}
