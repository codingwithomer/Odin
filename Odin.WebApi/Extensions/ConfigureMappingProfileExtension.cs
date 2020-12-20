using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Odin.WebApi.AutoMapperProfile;

namespace Odin.WebApi.Extensions
{
    public static class ConfigureMappingProfileExtension
    {
        public static IServiceCollection ConfigureMapping(this IServiceCollection services)
        {
            var mappingConfiguration = new MapperConfiguration(mc => mc.AddProfile(new AutoMapperMappingProfile()));

            IMapper mapper = mappingConfiguration.CreateMapper();

            services.AddSingleton(mapper);

            return services;
        }
    }
}
