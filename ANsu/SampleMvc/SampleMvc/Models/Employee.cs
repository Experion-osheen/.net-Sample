using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SampleMvc.Models
{
    public class Employee
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(2)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Age is required")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Age must be numeric")]
        [Range(21, 30, ErrorMessage = "Age must be between 21 and 30")]
        public int Age { get; set; }
        public bool IsThere { get; set; }
    }
}