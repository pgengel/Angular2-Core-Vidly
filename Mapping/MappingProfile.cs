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

            CreateMap<RentalDbModel, SaveRentalApiModel>()
                .ForMember(rapi => rapi.Movies, opt => opt.MapFrom(rdb => rdb.Movies.Select(r => r.MovieId)));
            CreateMap<RentalDbModel, RentalApiModel>()
                .ForMember(rapi => rapi.Customer, opt => opt.MapFrom(rdb => rdb.Customer.Name))
                .ForMember(rapi => rapi.Movies, opt => opt.MapFrom(rdb => rdb.Movies.Select(cm => new MovieApiModel { Id = cm.Movie.Id, Name = cm.Movie.Name })));

            //API to Domain
            CreateMap<CustomerApiModel, CustomerDbModel>()
                .ForMember(cdb => cdb.MembershipType, opt => opt.Ignore())
                .ForMember(cdb => cdb.Id, opt => opt.Ignore());

            CreateMap<MovieApiModel, MovieDbModel>()
                .ForMember(mdb => mdb.Genre, opt => opt.Ignore())
                .ForMember(mdb => mdb.Id, opt => opt.Ignore());


            CreateMap<SaveRentalApiModel, RentalDbModel>()
                .ForMember(rdb => rdb.Movies, opt => opt.Ignore())
                .ForMember(rdb => rdb.Customer, opt => opt.Ignore())
                //.ForMember(rdb => rdb.Customer.Name, opt => opt.MapFrom(rapi => rapi.Customer))
                .AfterMap((rapi, rdb) =>
                {
                    //Remove unselected movies
                    var removedMovies = rdb.Movies.Where(m => !rapi.Movies.Contains(m.MovieId));
                    foreach (var m in removedMovies)
                        rdb.Movies.Remove(m);

                    //add new movies
                    var addedMovies = rapi.Movies.Where(id => !rdb.Movies.Any(m => m.MovieId == id)).Select(id => new CustomerMovieDbModel { MovieId = id });
                    foreach (var m in addedMovies)
                        rdb.Movies.Add(m);


                });

        }
    }
}