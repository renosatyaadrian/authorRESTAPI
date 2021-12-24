using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using authorRESTAPI.ValidationAttributes;

namespace authorRESTAPI.Dtos
{
    [AuthorFirstLastNameMustBeDifferent]
    public class AuthorForUpdateDto
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        
        [Required]
        public DateTime DateOfBirth { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string MainCategory { get; set; }
    }
}