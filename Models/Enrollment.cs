using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace authorRESTAPI.Models
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int AuthorID { get; set; }
        public int CourseID { get; set; }
        public Author Author { get; set; }
        public Course Course { get; set; }
    }
}