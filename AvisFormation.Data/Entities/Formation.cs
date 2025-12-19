using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvisFormation.Data.Entities
{
    public class Formation
    {
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string Titre { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        [Url]
        public string Lien { get; set; }
        [Url]
        public string ImageURL { get; set; }
        [Range(0, 10000)]
        public double Prix { get; set; }
        public List<Avis> Avis { get; set; }
    }
}
