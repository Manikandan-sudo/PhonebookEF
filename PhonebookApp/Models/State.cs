using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PhonebookApp.Models
{
    public class State
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column(Order = 1)]
        public int StateId { get; set; }

        [Display(Name = "State Name")]
        [Required]
        public String StateName { get; set; }

        public bool IsActive { get; set; } = true;


        [Required]
        [ForeignKey("Country")]
        [Display(Name = "Country Name")]
        public int CountryId { get; set; }


        public virtual Country Country { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}