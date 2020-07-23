using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PhonebookApp.Models
{
    public class City
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column(Order = 1)]
        public int CityId { get; set; }

        [Display(Name = "City Name")]
        [Required]
        public String CityName { get; set; }
        public bool IsActive { get; set; } = true;


        [Required]
        [ForeignKey("State")]
        public int StateId { get; set; }

        public virtual State State { get; set; }
    }
}