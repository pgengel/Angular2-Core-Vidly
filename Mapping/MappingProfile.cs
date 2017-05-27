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
                .ForMember(rapi => rapi.Movies, opt => opt.MapFrom(rdb => rdb.Movies.Select(r => r.MovieId)));

            //API to Domain
            CreateMap<CustomerApiModel, CustomerDbModel>()
                .ForMember(cdb => cdb.MembershipType, opt => opt.Ignore())
                .ForMember(cdb => cdb.Id, opt => opt.Ignore());

            CreateMap<MovieApiModel, MovieDbModel>()
                .ForMember(mdb => mdb.Genre, opt => opt.Ignore())
                .ForMember(mdb => mdb.Id, opt => opt.Ignore());

                
            CreateMap<RentalApiModel, RentalDbModel>()
                .ForMember(rdb => rdb.Movies, opt => opt.Ignore())
                .AfterMap((rapi, rdb) => {
                    //Remove unselected movies
                    var removedMovies = new List<CustomerMovieDbModel>();
                    foreach (var r in rdb.Movies)
                        if (!rapi.Movies.Contains(r.MovieId))
                            removedMovies.Add(r);
                    foreach (var r in removedMovies)
                        rapi.Movies.Remove(r.MovieId);

                    //add new movies
                    foreach (var id in rapi.Movies)
                        if (!rdb.Movies.Any(r => r.MovieId == id))
                            rdb.Movies.Add(new CustomerMovieDbModel { MovieId = id });  
                });

        }
    }
}