﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
   public class CarKategori:BaseEntity
    {
        public string Name { get; set; }

        public List<Car> Cars { get; set; }
    }
}
