using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Day09.Models
{
    public enum Gender { 
        M,
        F
    }
    public class Trainee
    {
        [Key]
        public int ID { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        
        [Required]
        public Gender Gender { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required]
        public string MobileNum { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }


        [Required]
        public int TrackID { get; set; }

        [ForeignKey(nameof(TrackID))]
        [InverseProperty("Trainees")]
        public virtual Track Track { get; set; }
    }
}
