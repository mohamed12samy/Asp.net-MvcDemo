using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Day09.Models
{
    public class Track
    {
        [Key]
        public int ID { get; set; }
    
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [InverseProperty(nameof(Trainee.Track))]
        public virtual ICollection<Trainee> Trainees { get; set; }


        [InverseProperty(nameof(Course.Track))]
        public virtual ICollection<Course> Courses { get; set; }
    }
}
