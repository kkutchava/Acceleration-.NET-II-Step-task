using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace task7.Models
{
    internal class TP
    {
        [Key]
        [Column(Order = 0)] 
        public int TId { get; set; }

        [Key]
        [Column(Order = 1)] 
        public int PId { get; set; }

        [ForeignKey("TId")]
        public Teacher Teacher { get; set; }

        [ForeignKey("PId")]
        public Pupil Pupil { get; set; }
    }
}
