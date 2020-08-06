using Phonebook.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

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



        public IEnumerable<Country> AddCountries(Country country)
        {
            personContext.Countries.Add(country);
            personContext.SaveChanges();
            return personContext.Countries;
        }

        public IEnumerable<Country> UpdateCountries(Country country)
        {

        }
    }
}
