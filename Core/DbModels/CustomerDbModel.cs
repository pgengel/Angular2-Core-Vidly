using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Angular2_Core_Vidly.Core.DbModels
{
    [Table("tb_Customer")]
    public class CustomerDbModel
    {
       public int Id {get; set; }
       [Required]
       [StringLength(255)]
       public string Name {get; set;}
       public bool isSubscribedToNewsLetter {get; set;} 
       public int MembershipTypeId { get; set; }//This is needed when we have a foreign key.
       public MembershipTypeDbModel MembershipType { get; set; }
    }
}