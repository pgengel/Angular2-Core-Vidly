using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vidly.Core.DbModels;

namespace Vidly.Controllers.ApiModels
{
    public class MovieApiModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public GenreDbModel Genre { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int NumberInStock { get; set; }
        public int NumberAvailable { get; set; }
    }
}
