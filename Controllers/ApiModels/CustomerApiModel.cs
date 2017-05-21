using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vidly.Core.DbModels;

namespace Vidly.Controllers.ApiModels
{
    public class CustomerApiModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool isSubscribedToNewsLetter { get; set; }
        public MembershipTypeDbModel MembershipType { get; set; }
        public DateTime? Birthday { get; set; }
    }
}
