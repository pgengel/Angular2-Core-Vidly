using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Vidly.Core.DbModels
{
    [Table("tb_Genre")]
    public class GenreDbModel
    {
        [Key]
        public int GenreId { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}
