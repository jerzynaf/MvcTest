using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using AutoMapper;
using MvcTest.Database.Repositories.Interfaces;
using MvcTest.Database.Repositories.ParameterModels;
using MvcTest.Models.ViewModels;

namespace MvcTest.Web.Areas
{

    public class PeopleApiController : ApiController
    {
        private readonly IPersonRepository _personRepository;

        public PeopleApiController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public IHttpActionResult GetPeopleViewModels()
        {
            var people = _personRepository.GetAllPeople();
            var peopleViewModels = Mapper.Map<List<PersonViewModel>>(people);

            return Json(peopleViewModels);
        }

        [ResponseType(typeof(PersonViewModel))]
        public IHttpActionResult GetPersonViewModel(int id)
        {
            var contact = _personRepository.GetPersonViewModel(id);
            if (contact == null)
            {
                return NotFound();
            }

            return Json(contact);
        }

        // PUT: api/Contacts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPersonViewModel(int id, PersonViewModel personViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personViewModel.PersonId)
            {
                return BadRequest();
            }

            var personParameterModel = Mapper.Map<PersonParameterModel>(personViewModel);
            _personRepository.UpdatePerson(personParameterModel);

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}