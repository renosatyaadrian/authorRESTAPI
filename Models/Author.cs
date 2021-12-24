using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace authorRESTAPI.Models
{
    public class Author
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string MainCategory { get; set; }

        ICollection<Enrollment> Enrollments { get; set;}
    }
}