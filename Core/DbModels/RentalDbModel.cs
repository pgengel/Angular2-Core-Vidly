﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Vidly.Core.DbModels
{
    [Table("tb_Rental")]
    public class RentalDbModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public CustomerDbModel Customer { get; set; }
        public int MovieId { get; set; }
        public ICollection<MovieDbModel> Movies { get; set; }

        public RentalDbModel()
        {
            Movies = new Collection<MovieDbModel>();
        }
    }
}
