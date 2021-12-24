using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace authorRESTAPI.Dtos
{
    public class CourseDto
    {
        public int CourseID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<int> AuthorID { get; set; }
    }
}