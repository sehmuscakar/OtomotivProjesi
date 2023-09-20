using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
   public class Car:BaseEntity
    {
        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public int CarKategoriId { get; set; }
        public CarKategori CarKategori { get; set; }

        public int CarDetayId { get; set; }

        public CarDetay CarDetay { get; set; }

       

    }
}
