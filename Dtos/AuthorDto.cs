using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace authorRESTAPI.Dtos
{
    public class AuthorDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string MainCategory { get; set; }
    }
}