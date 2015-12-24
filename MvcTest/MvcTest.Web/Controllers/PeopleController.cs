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
        private NhsContext db = new NhsContext();

        // GET: People
        public ActionResult Index()
        {
            var people = db.People.OrderBy(p => p.FirstName).ToList();
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
            var person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            var personViewModel = Mapper.Map<PersonViewModel>(person);
            return View(personViewModel);
        }

        // POST: People/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonId,FirstName,LastName,IsAuthorised,IsValid,IsEnabled")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(person);
        }
    }
}
