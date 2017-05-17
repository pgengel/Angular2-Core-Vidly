using System;
using Angular2_Core_Vidly.Core.DbModels;

namespace Angular2_Core_Vidly.Controllers.ApiModels
{
    public class CustomerApiModel
    {
       public int Id {get; set; }
       public string Name {get; set;}
       public bool isSubscribedToNewsLetter {get; set;}
       public MembershipTypeApiModel MembershipType { get; set; }
       public DateTime? Birthdate {get; set; }
    }
}