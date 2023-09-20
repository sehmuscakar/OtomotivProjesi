using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Dtos.AdminDtos
{
   public class AdminBaseDto
    {
        public int Id { get; set; }

        public DateTime? LastUpdatedAt { get; set; }
        public string CreatedFullName { get; set; }

        public int RowOrder { get; set; }
    }
}
