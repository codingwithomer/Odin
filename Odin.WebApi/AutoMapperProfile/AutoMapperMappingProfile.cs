using AutoMapper;
using Odin.Data.Models;
using Odin.Models;

namespace Odin.WebApi.AutoMapperProfile
{
    public class AutoMapperMappingProfile : Profile
    {
        public AutoMapperMappingProfile()
        {
            CreateMap(typeof(ProductDTO), typeof(Product)).ReverseMap();
            CreateMap(typeof(CustomerDTO), typeof(Customer)).ReverseMap();
        }
    }
}
