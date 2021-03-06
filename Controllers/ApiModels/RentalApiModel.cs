﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Vidly.Controllers.ApiModels
{
    public class RentalApiModel
    {
        public int Id { get; set; }
        public CustomerApiModel Customer { get; set; }
        public ICollection<MovieApiModel> Movies { get; set; }

        public RentalApiModel()
        {
            Movies = new Collection<MovieApiModel>();
        }
    }
}
