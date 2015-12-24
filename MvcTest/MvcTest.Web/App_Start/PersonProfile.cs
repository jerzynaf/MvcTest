using AutoMapper;
using MvcTest.Database.Models;
using MvcTest.Models.ViewModels;

namespace MvcTest.Web
{
    public class PersonProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Person, PersonViewModel>();
            Mapper.CreateMap<PersonViewModel, Person>();
        }
    }
}