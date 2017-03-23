using System.ComponentModel.DataAnnotations;

namespace UserManagement.Models
{
    public class UserDetails
    {
        public string Id { get; set; }
        [Required(ErrorMessage="Please Enter Name")]
        [DataType(DataType.Text,ErrorMessage ="Please Enter a String")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Name")]
        [DataType(DataType.Text,ErrorMessage ="Please Enter An Integer")]
        [Range(0,100,ErrorMessage ="Please Enter A Valid Age")]
        public int Age { get; set; }
     
        public string Department { get; set; }
        public string Band { get; set; }
    }
}