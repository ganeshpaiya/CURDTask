using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class StaffDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Gender { get; set; }

        public string Nationality { get; set; }

        public DateTime? DOB { get; set; }

        public string job { get; set; }
        public string maritalstatus { get; set; }
        public string Religion { get; set; }
    }
}
