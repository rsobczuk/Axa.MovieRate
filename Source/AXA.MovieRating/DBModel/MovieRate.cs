using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AXA.MovieRating.DBModel
{
    public class MovieRate
    {
        [Key]
        public int MovieRateId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string MovieId { get; set; }

        [Required]
        public int Rate { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }
    }
}