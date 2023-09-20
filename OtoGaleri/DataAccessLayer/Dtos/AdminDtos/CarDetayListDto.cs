using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Dtos.AdminDtos
{
    public class CarDetayListDto:AdminBaseDto
    {
        public string ImageUrl { get; set; }
        public int Year { get; set; }
        public int Km { get; set; }
        public int Price { get; set; }
        public DateTime AdvertTime { get; set; } //ilan zamanı

        public string Description { get; set; }


    }
}
