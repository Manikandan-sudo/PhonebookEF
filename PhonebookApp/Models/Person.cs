using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PhonebookApp.Models
{
    public class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column(Order = 1)]
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter the First Name")]
        [Display(Name = "First Name")]
        [StringLength(30, ErrorMessage = "First name cannot be longer than 30 characters.", MinimumLength = 1)]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "Please enter the Last Name")]
        [Display(Name = "Last Name")]
        [StringLength(30, ErrorMessage = "Last name cannot be longer than 30 characters.", MinimumLength = 1)]
        public String LastName { get; set; }

        [Display(Name = "Phone")]
        [Required(ErrorMessage = "Please enter the Phone Number")]
        [StringLength(13, ErrorMessage = "Phone Number cannot be longer than 13 characters.", MinimumLength = 10)]
        public String PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string EmailAddress { get; set; }


        //Address section
        [Display(Name = "AddressLine One")]
        [Required(ErrorMessage = "Please enter the AddressLine")]
        public String AddressOne { get; set; }

        [Display(Name = "AddressLine Two")]
        public String AddressTwo { get; set; }

        [Display(Name = "PinCode")]
        [Required(ErrorMessage = "Please enter the Pincode")]
        public int PinCode { get; set; }

        public Boolean IsActive { get; set; } = true;

        [Required(ErrorMessage = "Please Chose the Country")]
        [ForeignKey("Country")]
        [Display(Name = "Country")]
        public int CountryName { get; set; }

        [Required(ErrorMessage = "Please Chose the State")]
        [ForeignKey("State")]
        [Display(Name = "State")]
        public int StateName { get; set; }

        [Required(ErrorMessage = "Please Chose the City")]
        [ForeignKey("City")]
        public int CityName { get; set; }

        public virtual Country Country { get; set; }
        public virtual State State { get; set; }
        public virtual City City { get; set; }
    }
}