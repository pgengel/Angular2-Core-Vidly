using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Vidly.Core.DbModels
{
    [Table("tb_Customer")]
    public class CustomerDbModel
    {
        [Key]
        public int CustomerId { get; set; }
        //[Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool isSubscribedToNewsLetter { get; set; }
        public int MembershipTypeId { get; set; }
        public MembershipTypeDbModel MembershipType { get; set; }
        public DateTime? Birthday { get; set; }
    }
}
