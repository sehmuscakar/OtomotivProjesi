using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class ContactCity:BaseEntity
    {
        public string Address { get; set; }
        public string MailCity { get; set; }
        public string Phone { get; set; }

        public string Twiter { get; set; }
        public string Facebook { get; set; }
        public string Instegram { get; set; }
        public string Linkedin { get; set; }
        public string Skype { get; set; }
    }
}
