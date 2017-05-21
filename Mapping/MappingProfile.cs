using System.Collections.Generic;
using AutoMapper;
using Vidly.Controllers.ApiModels;
using Vidly.Core.DbModels;

namespace Angular2_Core_Vidly.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<List<CustomerDbModel>, List<CustomerApiModel>>();
            CreateMap<CustomerDbModel, CustomerApiModel>();

            //CreateMap<List<MovieDbModel>, List<MovieApiModel>>();
            CreateMap<MovieDbModel, MovieApiModel>();

            //CreateMap<List<MembershipTypeDbModel>, List<MembershipTypeApiModel>>();
            CreateMap<MembershipTypeDbModel, MembershipTypeApiModel>();

            //CreateMap<List<GenreDbModel>, List<GenreApiModel>>();
            CreateMap<GenreDbModel, GenreApiModel>();


        }
    }
}