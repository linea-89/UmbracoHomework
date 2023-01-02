using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcmeCorporation.Models
{
    public class SerialNumber
    {
        public int ID { get; set; }


        public Guid ProductSerialNumber { get; set; }


    }
}
