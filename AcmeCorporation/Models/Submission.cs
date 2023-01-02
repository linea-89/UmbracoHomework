using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcmeCorporation.Models
{
    public class Submission
    {

        public int Id { get; set; }

        [Display(Prompt = "First Name", Name = "First Name")]
        public string? FirstName { get; set; }

        [Display(Prompt = "Last Name", Name = "Last Name")]
        public string? LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Prompt = "Email Address", Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Display(Prompt = "Serial Number", Name = "Serial Number")]
        public Guid SerialNumber { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Birthdate")]
        public DateTime Birthdate { get; set; }
    }

}