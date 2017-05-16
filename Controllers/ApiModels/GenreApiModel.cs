using System;
using Angular2_Core_Vidly.Core.DbModels;

namespace Angular2_Core_Vidly.Controllers.ApiModels
{
    public class GenreApiModel
    {
        public int Id {get; set; }
        public string Name {get ; set; }
        public GenreDbModel Genre {get; set;}
        public int GenreId {get; set;}
        public DateTime DateAdded { get; set; }
        public DateTime ReleaseDate { get; set; }
        public byte NumberInStock { get; set; }
        public byte NumberAvailable { get; set; }
    }
}