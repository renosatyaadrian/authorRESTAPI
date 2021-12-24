using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace authorRESTAPI.Dtos
{
    public class CourseForUpdateDto
    {
        
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        
        [Required]
        [MaxLength(1500)]
        public string Description { get; set; }
    }
}