using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Vidly.Core.DbModels
{
    [Table("tb_MembershipType")]
    public class MembershipTypeDbModel
    {
        [Key]
        public int MembershipTypeId { get; set; }
        [Required]
        public string Name { get; set; }
        public int SignUpFee { get; set; }
        public int DurationInMonths { get; set; }
        public int DiscountRate { get; set; }
        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;
    }
}
