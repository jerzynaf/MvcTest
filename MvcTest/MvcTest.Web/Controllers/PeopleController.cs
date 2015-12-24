using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using MvcTest.Database;
using MvcTest.Database.Models;
using MvcTest.Models.ViewModels;

namespace MvcTest.Web.Controllers
{
    public class PeopleController : Controller
    {
        private NhsContext _context = new NhsContext();

        // GET: People
        public ActionResult Index()
        {
            var people = _context.People.OrderBy(p => p.FirstName).ToList();
            var peopleViewModels = Mapper.Map<List<PersonViewModel>>(people);
            return View(peopleViewModels);
        }

        // GET: People/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var person = _context.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            var personViewModel = Mapper.Map<PersonViewModel>(person);
            var allColours = _context.Colours.Where(c=>c.IsEnabled==true).ToList();
            var allColourViewModels = Mapper.Map<List<ColourViewModel>>(allColours);
            personViewModel.Colours.Clear();
            var favouriteColourIds = person.Colours.Select(c => c.ColourId);

            for (int i = 0; i < allColourViewModels.Count; i++)
            {
                var tempColour = allColourViewModels.ElementAt(i);
                if (favouriteColourIds.Contains(tempColour.ColourId))
                {
                    tempColour.IsChecked = true;
                }
                personViewModel.Colours.Add(tempColour);
            }

            return View(personViewModel);
        }

        // POST: People/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonId,FirstName,LastName,IsAuthorised,IsValid,IsEnabled")] Person person)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(person).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(person);
        }
    }
}
