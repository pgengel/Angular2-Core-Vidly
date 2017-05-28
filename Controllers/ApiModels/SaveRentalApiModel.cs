using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Vidly.Controllers.ApiModels
{
    public class SaveRentalApiModel
    {
        public int Id { get; set; }
        public string Customer { get; set; }
        public ICollection<int> Movies { get; set; }
        public SaveRentalApiModel()
        {
            Movies = new Collection<int>();
        }
    }

}
