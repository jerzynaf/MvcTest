using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using MvcTest.Database.Repositories.Interfaces;
using MvcTest.Models.ViewModels;

namespace MvcTest.Web.Areas.API.Controllers
{

    public class PeopleApiController : ApiController
    {
        private readonly IPersonRepository _personRepository;

        public PeopleApiController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public IHttpActionResult GetPeople()
        {
            var people = _personRepository.GetAllPeople();
            var peopleViewModels = Mapper.Map<List<PersonViewModel>>(people);

            return Json(peopleViewModels);
        }
    }
}