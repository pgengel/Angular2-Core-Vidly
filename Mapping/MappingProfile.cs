using System.Collections.Generic;
using Angular2_Core_Vidly.Controllers.ApiModels;
using Angular2_Core_Vidly.Core.DbModels;
using AutoMapper;

namespace Angular2_Core_Vidly.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerDbModel, CustomerApiModel>();
            CreateMap<MovieDbModel, MovieApiModel>();
            CreateMap<List<MembershipTypeDbModel>, List<MembershipTypeApiModel>>();

        }
    }
}