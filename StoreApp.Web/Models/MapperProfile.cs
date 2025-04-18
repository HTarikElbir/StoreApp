using AutoMapper;
using StoreApp.Data.Entities;

namespace StoreApp.Web.Models;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Product, ProductViewModel>();
    }
    
}