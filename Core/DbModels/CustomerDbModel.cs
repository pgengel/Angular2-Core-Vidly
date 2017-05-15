using System.ComponentModel.DataAnnotations.Schema;

namespace Angular2_Core_Vidly.Core.DbModels
{
    [Table("tb_Customer")]
    public class CustomerDbModel
    {
       public int Id {get; set; }
       public string Name {get; set;}
       public bool isSubscribedToNewsLetter {get; set;} 
       public int MembershipTypeId { get; set; }
       public MembershipTypeDbModel MembershipType { get; set; }
    }
}