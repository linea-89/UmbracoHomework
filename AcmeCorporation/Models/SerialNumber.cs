using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcmeCorporation.Models
{
    public class SerialNumber
    {
        public int ID { get; set; }


        [Display(Name = "Product Serial Number")]
        public Guid ProductSerialNumber { get; set; }

      //  public List<Submission> Submissions { get; set; } = new List<Submission>();
    }
}
