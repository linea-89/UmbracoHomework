using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcmeCorporation.Models
{
    public class Submission
    {

        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string? FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }


        [Display(Name = "Product Serial Number")]
        public Guid SerialNumber { get; set; }

        
       /* public Guid SerialNumberProductSerialNumber { get; set; }
        public SerialNumber SerialNumber { get; set; }
        
        */
    } 

}