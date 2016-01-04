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
using MvcTest.Database.Repositories.Interfaces;
using MvcTest.Models.ViewModels;

namespace MvcTest.Web.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IPersonRepository _personRepository;
        private readonly IColourRepository _colourRepository;

        public PeopleController(IPersonRepository personRepository, IColourRepository colourRepository)
        {
            _personRepository = personRepository;
            _colourRepository = colourRepository;
        }

        // GET: People
        public ActionResult Index()
        {
            var people = _personRepository.GetAllPeople();
            var peopleViewModels = Mapper.Map<List<PersonViewModel>>(people);
            return View(peopleViewModels);
        }

        // GET: People/Edit/5
        public ActionResult Edit(int id)
        {
            var person = _personRepository.GetPerson(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            var personViewModel = Mapper.Map<PersonViewModel>(person);
            var allColours = _colourRepository.GetAllColours();
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
        public ActionResult Edit(PersonViewModel personViewModel)
        {
            if (ModelState.IsValid)
            {
                UpdatePerson(personViewModel);
                return RedirectToAction("Index");
            }
            return View(personViewModel);
        }

        private void UpdatePerson(PersonViewModel personViewModel)
        {
            var person = _personRepository.GetPerson(personViewModel.PersonId);
            // _context.People.Include(c => c.Colours).Single(p => p.PersonId == personViewModel.PersonId);
            person.IsAuthorised = personViewModel.IsAuthorised;
            person.IsEnabled = personViewModel.IsEnabled;
            person.Colours.Clear();
            var pickedColours = personViewModel.Colours.Where(c => c.IsChecked == true).Select(c => c.ColourId);
            for (int i = 0; i < pickedColours.Count(); i++)
            {
                var colour = _colourRepository.GetColour(pickedColours.ElementAt(i));
                person.Colours.Add(colour);
            }

            _personRepository.SaveChanges();
        }
    }
}
