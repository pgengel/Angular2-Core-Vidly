using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Vidly.Core.DbModels
{
    [Table("tb_Movie")]
    public class MovieDbModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public GenreDbModel Genre { get; set; }
        public int GenreId { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? ReleaseDate { get; set; }
        [Range(1, 20)]
        public int NumberInStock { get; set; }
        public int NumberAvailable { get; set; }
    }
}
