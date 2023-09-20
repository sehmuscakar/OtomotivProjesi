using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Team : BaseEntity
    {
       

        public string Image { get; set; }
     
        public string FullName { get; set; }
  
        public string Duty { get; set; }
    
        public string Twitter { get; set; }
      
        public string Facebook { get; set; }
      
        public string Instegram { get; set; }
        public string LinkedIn { get; set; }
    }
}
