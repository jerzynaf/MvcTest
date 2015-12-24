using AutoMapper;
using MvcTest.Database.Models;
using MvcTest.Models.ViewModels;

namespace MvcTest.Web
{
    public class ColourProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Colour, ColourViewModel>();
            Mapper.CreateMap<ColourViewModel, Colour>();
        }
    }
}