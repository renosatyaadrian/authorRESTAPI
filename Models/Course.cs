using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace authorRESTAPI.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}