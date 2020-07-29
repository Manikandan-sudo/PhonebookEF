using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using PhonebookApp.DAL;
using PhonebookApp.Models;
using System.Data;
using System.Collections;

namespace PhonebookApp.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        private PersonContext db = new PersonContext();

        public ActionResult Index()
        {
            List<SelectListItem> listGroup = new List<SelectListItem>();
            listGroup.Add(new SelectListItem { Text = "Email", Value = "Email" });
            listGroup.Add(new SelectListItem { Text = "Phone", Value = "Phone" });
            listGroup.Add(new SelectListItem { Text = "State", Value = "State" });
            listGroup.Add(new SelectListItem { Text = "Country", Value = "Country" });
            listGroup.Add(new SelectListItem { Text = "City", Value = "City" });
            List<SelectListItem> listorderGroup = new List<SelectListItem>();
            listorderGroup.Add(new SelectListItem { Text = "Ascending", Value = "Ascending" });
            listorderGroup.Add(new SelectListItem { Text = "Descending", Value = "Descending" });
            ViewBag.listDropDown = listGroup;
            ViewBag.order = listorderGroup;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FormCollection group)
        {
            List<SelectListItem> listGroup = new List<SelectListItem>();
            listGroup.Add(new SelectListItem { Text = "Email", Value = "Email" });
            listGroup.Add(new SelectListItem { Text = "Phone", Value = "Phone" });
            listGroup.Add(new SelectListItem { Text = "State", Value = "State" });
            listGroup.Add(new SelectListItem { Text = "Country", Value = "Country" });
            listGroup.Add(new SelectListItem { Text = "City", Value = "City" });
            List<SelectListItem> listorderGroup = new List<SelectListItem>();
            listorderGroup.Add(new SelectListItem { Text = "Ascending", Value = "Ascending" });
            listorderGroup.Add(new SelectListItem { Text = "Descending", Value = "Descending" });
            ViewBag.listDropDown = listGroup;
            ViewBag.order = listorderGroup;
            if (!String.IsNullOrEmpty(group["selects"]))
            {
                switch (group["selects"])
                {
                    case "Email":
                        if (!String.IsNullOrEmpty(group["Start"]))
                        {
                            var start = group["Start"];
                            var nr = group["count"];
                            if (group["order"] == "Ascending")
                            {
                                var li = db.Persons.Where(p => p.IsActive).Skip(int.Parse(start) - 1).OrderBy(p => p.EmailAddress).Select(p => new { p.FirstName, p.LastName, p.EmailAddress });
                                var nli = li.Take(int.Parse(nr));
                                return View(nli);
                            }
                            else
                            {
                                var li = db.Persons.Where(p => p.IsActive).Skip(int.Parse(start) - 1).OrderByDescending(p => p.EmailAddress).Select(p => new { p.FirstName, p.LastName, p.EmailAddress });
                                var nli = li.Take(int.Parse(nr));
                                return View(nli);
                            }
                        }
                        else
                        {
                            break;
                        }

                    case "Phone":
                        if (!String.IsNullOrEmpty(group["Start"]))
                        {
                            var start = group["Start"];
                            var nr = group["count"];
                            if (group["order"] == "Ascending")
                            {
                                var li = db.Persons.Where(p => p.IsActive).Skip(int.Parse(start) - 1).OrderBy(p => p.PhoneNumber).Select(p => new { p.FirstName, p.LastName, p.PhoneNumber });
                                var nli = li.Take(int.Parse(nr));
                                return View(nli);
                            }
                            else
                            {
                                var li = db.Persons.Where(p => p.IsActive).Skip(int.Parse(start) - 1).OrderByDescending(p => p.PhoneNumber).Select(p => new { p.FirstName, p.LastName, p.PhoneNumber });
                                var nli = li.Take(int.Parse(nr));
                                return View(nli);
                            }
                        }
                        else
                        {
                            break;
                        }
                    case "State":
                        if (!String.IsNullOrEmpty(group["Start"]))
                        {
                            var start = group["Start"];
                            var nr = group["count"];
                            if (group["order"] == "Ascending")
                            {
                                var li = db.Persons.Where(p => p.IsActive).Skip(int.Parse(start) - 1).OrderBy(p => p.StateName).Select(p => new { p.FirstName, p.LastName, p.StateName });
                                var nli = li.Take(int.Parse(nr));
                                return View(nli);
                            }
                            else
                            {
                                var li = db.Persons.Where(p => p.IsActive).Skip(int.Parse(start) - 1).OrderByDescending(p => p.StateName).Select(p => new { p.FirstName, p.LastName, p.StateName });
                                var nli = li.Take(int.Parse(nr));
                                return View(nli);
                            }
                        }
                        else
                        {
                            break;
                        }

                    case "Country":
                        if (!String.IsNullOrEmpty(group["Start"]))
                        {
                            var start = group["Start"];
                            var nr = group["count"];
                            if (group["order"] == "Ascending")
                            {
                                var li = db.Persons.Where(p => p.IsActive).Skip(int.Parse(start) - 1).OrderBy(p => p.CountryName).Select(p => new { p.FirstName, p.LastName, p.CountryName });
                                var nli = li.Take(int.Parse(nr));
                                return View(nli);
                            }
                            else
                            {
                                var li = db.Persons.Where(p => p.IsActive).Skip(int.Parse(start) - 1).OrderByDescending(p => p.CountryName).Select(p => new { p.FirstName, p.LastName, p.CountryName });
                                var nli = li.Take(int.Parse(nr));
                                return View(nli);
                            }
                        }
                        else
                        {
                            break;
                        }
                    case "City":
                        if (!String.IsNullOrEmpty(group["Start"]))
                        {
                            var start = group["Start"];
                            var nr = group["count"];
                            if (group["order"] == "Ascending")
                            {
                                var li = db.Persons.Where(p => p.IsActive).Skip(int.Parse(start) - 1).OrderBy(p => p.CityName).Select(p => new { p.FirstName, p.LastName, p.CityName });
                                var nli = li.Take(int.Parse(nr));
                                return View(nli);
                            }
                            else
                            {
                                var li = db.Persons.Where(p => p.IsActive).Skip(int.Parse(start) - 1).OrderByDescending(p => p.CityName).Select(p => new { p.FirstName, p.LastName, p.CityName });
                                var nli = li.Take(int.Parse(nr));
                                return View(nli);
                            }
                        }
                        else
                        {
                            break;
                        }

                }
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }







        // GET: Search
        public ActionResult Search()
        {

            List<Person> peoples = db.Persons.ToList();

            List<SelectListItem> listGroup = new List<SelectListItem>();
            listGroup.Add(new SelectListItem { Text = "City", Value = "City" });
            listGroup.Add(new SelectListItem { Text = "State", Value = "State" });
            listGroup.Add(new SelectListItem { Text = "Country", Value = "Country" });
            listGroup.Add(new SelectListItem { Text = "Pin Code", Value = "Pin Code" });

            ViewBag.listDropDown = listGroup;
            ViewBag.Count = 0;
            return View(peoples);
        }





        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(FormCollection groupByString)
        {


            if (!String.IsNullOrEmpty(groupByString["select"]))
            {


                List<SelectListItem> listGroup = new List<SelectListItem>();

                listGroup.Add(new SelectListItem { Text = "City", Value = "City" });
                listGroup.Add(new SelectListItem { Text = "State", Value = "State" });
                listGroup.Add(new SelectListItem { Text = "Country", Value = "Country" });
                listGroup.Add(new SelectListItem { Text = "Pin Code", Value = "Pin Code" });

                ViewBag.listDropDown = listGroup;
                List<Person> people = db.Persons.Where(p => p.IsActive).ToList();


                switch (groupByString["select"])
                {
                    case "City":
                        var peoplecGroup = db.Persons.GroupBy(p => p.CityName).OrderBy(p => p.Key);

                        foreach (var g in peoplecGroup)
                        {
                            var cid = g.Key;
                            foreach (var s in g)
                            {
                                List<Person> speople = people.Where(p => p.CityName.Equals(cid)).ToList();
                                people.Concat(speople);
                            }


                        }
                        ViewBag.Count = people.Count();
                        break;


                    case "State":
                        var peoplesGroup = db.Persons.GroupBy(p => p.StateName).OrderBy(p => p.Key);

                        foreach (var g in peoplesGroup)
                        {
                            var sid = g.Key;
                            foreach (var s in g)
                            {
                                List<Person> speople = people.Where(p => p.StateName.Equals(sid)).ToList();
                                people.Concat(speople);
                            }


                        }
                        ViewBag.Count = people.Count();
                        break;
                    case "Country":
                        var peopleCGroup = db.Persons.GroupBy(p => p.CountryName).OrderBy(p => p.Key);

                        foreach (var g in peopleCGroup)
                        {
                            var Cid = g.Key;
                            foreach (var s in g)
                            {
                                List<Person> speople = people.Where(p => p.CountryName.Equals(Cid)).ToList();
                                people.Concat(speople);
                            }


                        }
                        ViewBag.Count = people.Count();
                        break;
                    case "Pin Code":
                        var peoplepGroup = db.Persons.GroupBy(p => p.PinCode).OrderBy(p => p.Key);

                        foreach (var g in peoplepGroup)
                        {
                            var pid = g.Key;
                            foreach (var s in g)
                            {
                                List<Person> speople = people.Where(p => p.CountryName.Equals(pid)).ToList();
                                people.Concat(speople);
                            }


                        }
                        ViewBag.Count = people.Count();
                        break;
                }
                return View(people);
            }


            return RedirectToAction("Search");
        }



    }
}

    
