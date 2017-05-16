using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Angular2_Core_Vidly.Core.DbModels
{
     [Table("tb_Genre")]
    public class GenreDbModel
    {
        public int Id {get; set; }
        [Required]
        [StringLength(255)]
        public string Name {get ; set; }
    }
}