using AutoMapper;

namespace MvcTest.Web
{
    public static class AutoMapperWebConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                //TODO swap to interfaces
                cfg.AddProfile(new PersonProfile());
                cfg.AddProfile(new ColourProfile());
            });
        }
    }
}