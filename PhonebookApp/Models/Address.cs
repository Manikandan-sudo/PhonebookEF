//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PhonebookApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Address
    {
        public int ID { get; set; }
        public string AddressOne { get; set; }
        public string AddressTwo { get; set; }
        public int PinCode { get; set; }
        public int CountryName { get; set; }
        public int StateName { get; set; }
        public int CityName { get; set; }
    
        public virtual City City { get; set; }
        public virtual Country Country { get; set; }
        public virtual Person Person { get; set; }
        public virtual State State { get; set; }
    }
}