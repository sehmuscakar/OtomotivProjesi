using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Dtos.AdminDtos
{
    public class AboutListDto:AdminBaseDto
    {
        public string ImageUrl { get; set; }
        public string AboutDecription { get; set; }
        public string Title1 { get; set; }
        public string Title12 { get; set; }
        public string Title3 { get; set; }
    }
}
