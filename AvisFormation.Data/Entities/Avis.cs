using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvisFormation.Data.Entities
{
    public class Avis
    {
        public int Id { get; set; }
        [Required]
        public string Auteur { get; set; }
        [Required]
        public string Commentaire { get; set; }
        [Range(1, 5)]
        public int Note { get; set; }
        public DateTime DateAvis { get; set; } = DateTime.Now;
        [ForeignKey("Formation")]
        public int FormationId { get; set; }
        public Formation Formation { get; set; }
    }
}
