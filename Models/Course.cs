using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Day09.Models
{
    public class Course
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Topic { get; set; }

        [Required]
        public int Grade { get; set; }
        
        [Required]
        public int TrackID { get; set; }

        [ForeignKey(nameof(TrackID))]
        [InverseProperty("Courses")]
        public virtual Track Track { get; set; }
    }
}
