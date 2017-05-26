using System.Collections.Generic;
using AutoMapper;
using Vidly.Controllers.ApiModels;
using Vidly.Core.DbModels;
using System.Linq;

namespace Angular2_Core_Vidly.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to API
            CreateMap<CustomerDbModel, CustomerApiModel>();
            CreateMap<MovieDbModel, MovieApiModel>();
            CreateMap<MembershipTypeDbModel, MembershipTypeApiModel>();
            CreateMap<GenreDbModel, GenreApiModel>();
            CreateMap<RentalDbModel, RentalApiModel>()
                .ForMember(rapi => rapi.Movies, opt => opt.MapFrom(rdb => rdb.Movies.Select(r => r.Id)));

            //API to Domain
            CreateMap<RentalApiModel, RentalDbModel>()
                //.ForMember(rdb => rdb.Id, opt => opt.Ignore())
                //.ForMember(rdb => rdb.Customer, opt => opt.Ignore())
                //.ForMember(rdb => rdb.Customer, opt => opt.MapFrom(rapi => rapi.customerName))
                .ForMember(rdb => rdb.Movies, opt => opt.MapFrom(rapi => rapi.Movies.Select(id => new MovieDbModel { Id = id })));

        }
    }
}