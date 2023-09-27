using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task7.Models
{
    internal class Teacher
    {
        [Key]
        public int TId { get; set; }

        [Required]
        [StringLength(20)]
        public string nm { get; set; }

        [Required]
        [StringLength(20)]
        public string surnm { get; set; }

        [Required]
        [MaxLength(1)]
        public char gender { get; set; }

        [Required]
        [StringLength(50)]
        public string subjct { get; set; }
    }
}
