using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Vidly.Controllers.ApiModels
{
    public class RentalApiModel
    {
        public string customerName { get; set; }
        public ICollection<int> Movies { get; set; }
        public RentalApiModel()
        {
            Movies = new Collection<int>();
        }
    }

}
