using AvisFormation.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvisFormation.Logic
{
    public class FormationManager
    {
        private readonly Data.ApplicationDbContext _context;
        public FormationManager(Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Formation> GetAll()
        {
            return _context.Formations.Include(f => f.Avis).ToList();
        }
        public Formation GetById(int id)
        {
            var formation = _context.Formations.Find(id);
            if (formation != null)
            {
                return _context.Formations.Include(f => f.Avis).FirstOrDefault(f => f.Id == id);
            }
            else
            {
                return null;
            }

        }
    }
}
