using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PhonebookApp.DAL;
using PhonebookApp.Models;

namespace PhonebookApp.Controllers
{
    public class PeopleController : Controller
    {
        private PersonContext db = new PersonContext();

        // GET: People
        public ActionResult Index(String searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                var people = db.Persons.Where(p => (p.FirstName.Contains(searchString) ||
                                                   p.LastName.Contains(searchString) ||
                                                   p.Country.CountryName.Contains(searchString) ||
                                                   p.State.StateName.Contains(searchString) ||
                                                   p.City.CityName.Contains(searchString) ||
                                                   p.PhoneNumber.Contains(searchString)) &&
                                                   p.IsActive);
                return View(people.ToList());
            }
            var peoples = db.Persons.Include(p => p.City).Include(p => p.Country).Include(p => p.State);
            peoples = peoples.Where(p => p.IsActive.Equals(true));
            return View(peoples.ToList());
        }

        // GET: People/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Persons.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: People/Create
        public ActionResult Create()
        {

            var country = db.Countries.Where(p => p.IsActive).ToList();
            List<SelectListItem> countryList = new List<SelectListItem>();
            countryList.Add(new SelectListItem
            {
                Text = "---Select Country---",
                Value = "0"
            });

            foreach (var c in country)
            {
                countryList.Add(new SelectListItem
                {
                    Text = c.CountryName,
                    Value = c.CountryId.ToString()
                });
                ViewBag.country = countryList;
            }
            
            return View();
        }

        public JsonResult GetStates(int id)
        {
            var states = db.States.Where(s => s.CountryId == id && s.IsActive).ToList();
            List<SelectListItem> stateList = new List<SelectListItem>();

            stateList.Add(new SelectListItem { Text = "---Select State---", Value = "0" });
            if (states != null)
            {
                foreach (var s in states)
                {
                    stateList.Add(new SelectListItem { Text = s.StateName, Value = s.StateId.ToString() });
                }
            }

            return Json(new SelectList(stateList, "Value", "Text", JsonRequestBehavior.AllowGet));
        }

        public JsonResult GetCities(int id)
        {
            var cities = db.Cities.Where(s => s.StateId == id && s.IsActive).ToList();
            List<SelectListItem> cityList = new List<SelectListItem>();

            cityList.Add(new SelectListItem { Text = "---Select City---", Value = "0" });
            if (cities != null)
            {
                foreach (var c in cities)
                {
                    cityList.Add(new SelectListItem { Text = c.CityName, Value = c.CityId.ToString() });
                }
            }

            return Json(new SelectList(cityList, "Value", "Text", JsonRequestBehavior.AllowGet));
        }

        // POST: People/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,PhoneNumber,EmailAddress,AddressOne,AddressTwo,PinCode,IsActive,CountryName,StateName,CityName")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Persons.Add(person);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.CityName = new SelectList(db.Cities, "CityId", "CityName", person.CityName);
            //ViewBag.CountryName = new SelectList(db.Countries, "CountryId", "CountryName", person.CountryName);
            //ViewBag.StateName = new SelectList(db.States, "StateId", "StateName", person.StateName);
            return View(person);
        }

        // GET: People/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Persons.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityName = new SelectList(db.Cities, "CityId", "CityName", person.CityName);
            ViewBag.CountryName = new SelectList(db.Countries, "CountryId", "CountryName", person.CountryName);
            ViewBag.StateName = new SelectList(db.States, "StateId", "StateName", person.StateName);
            return View(person);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,PhoneNumber, EmailAddress, AddressOne,AddressTwo,PinCode,IsActive,CountryName,StateName,CityName")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityName = new SelectList(db.Cities, "CityId", "CityName", person.CityName);
            ViewBag.CountryName = new SelectList(db.Countries, "CountryId", "CountryName", person.CountryName);
            ViewBag.StateName = new SelectList(db.States, "StateId", "StateName", person.StateName);
            return View(person);
        }

        // GET: People/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Persons.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Person person = db.Persons.Find(id);
            db.Persons.Remove(person);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
