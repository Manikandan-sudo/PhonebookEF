using Phonebook.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;


namespace Phonebook.Service
{
    public class CountryService
    {
        private PersonContext personContext;
        public CountryService()
        {
            personContext = new PersonContext();
        }
        public IEnumerable<Country> GetCountries()
        {
            return personContext.Countries.Where(c => c.IsActive.Equals(true));
        }


        public IEnumerable<Country> GetCountriesByID(int id)
        {
            return personContext.Countries.Where(p => p.CountryId.Equals(id));
        }
        public IEnumerable<Country> AddCountries(Country country)
        {
            personContext.Countries.Add(country);
            personContext.SaveChanges();
            return personContext.Countries;
        }

        public Country UpdateCountries(Country country)
        {
            if (!personContext.Countries.Any(x => x.CountryId == country.CountryId))
            {
                throw new InvalidOperationException("Country Id NotFound");
            }
            personContext.Countries.AddOrUpdate(country);
            personContext.SaveChanges();
            return country;
        }

        public Country DeleteCountries(Country country)
        {
            Country co = personContext.Countries.Where(c => c.CountryName.Contains(country.CountryName)).FirstOrDefault();
            personContext.Countries.Remove(co);
            personContext.SaveChanges();
            return country;
        }

    }
}
