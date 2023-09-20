using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Dtos.AdminDtos
{
    public class CarListDto:AdminBaseDto
    {
        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public int CarKategoriId { get; set; } //seçilen verileri getirmek için home da parçalama olduğu için buda lazım 
        public int CarDetayId { get; set; } // bu ilgili idnin detayını gitmesi için href te 
        public string CarKategoriName { get; set; }
    
     //   public string CarDetayName { get; set; } buna gerek yok

    }
}
