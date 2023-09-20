using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class About: BaseEntity
    { 
        public string ImageUrl { get; set; }
        public string AboutDecription { get; set; }
        public string Title1 { get; set; }
        public string Title12 { get; set; }
        public string Title3 { get; set; }
    }
}
