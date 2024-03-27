using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class Student
    {
        public int Id { get; set; }



        [Required(ErrorMessage = "This field is required")]
        //[StringLength(15, MinimumLength = 3 )]
        [RegularExpression(@"^(?=(?:.*[^\s]){3})\s*\S(?:\s*\S){2,}\s*$", ErrorMessage = "FirstName must be between 3 and 15 letters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        //[StringLength(18, MinimumLength = 2)]
        [RegularExpression(@"^(?=(?:.*[^\s]){2})\s*\S(?:\s*\S){1,}\s*$", ErrorMessage = "LastName must be between 2 and 18 letters")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Range(5, 99, ErrorMessage = "Age should be between 5 & 99")]

        public int Age { get; set; }
        public string Class { get; set; }
        public string Address { get; set; }

        [Required(ErrorMessage = "This field is required")]

        public DateTime DateOfBirth { get; set; }
    }
}
