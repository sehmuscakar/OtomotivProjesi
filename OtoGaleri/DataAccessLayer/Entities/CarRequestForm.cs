using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class CarRequestForm:IEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Carİnformation { get; set; }//araç bilgisi
        //yakıt
        public bool Benzin { get; set; }
        public bool Dizel { get; set; }
        public bool LPG { get; set; }
        public bool FarketmezYakit { get; set; }

        //Vites
        public bool Manuel { get; set; }
        public bool Otomatik { get; set; }
        public bool FarketmezVitez { get; set; }

        public int PriceRange { get; set; } // fiyat aralığı

        public string Description { get; set; }
        public int RowOrder { get; set; }


    }
}
