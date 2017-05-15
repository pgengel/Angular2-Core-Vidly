using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Angular2_Core_Vidly.Core.DbModels
{
    [Table("tb_MembershipType")]
    public class MembershipTypeDbModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }        
    }
}