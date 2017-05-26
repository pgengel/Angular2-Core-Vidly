using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vidly.Core.DbModels
{
    public class CustomerMovieDbModel
    {
        public int CustomerId { get; set; }
        public int MovieId { get; set; }
        public CustomerDbModel Customer { get; set; }
        public MovieDbModel Movie { get; set; }
    }
}
