using Microsoft.EntityFrameworkCore;

namespace AcmeCorporation.Data
{
    public class AcmeCorporationContext : DbContext
    {
        public AcmeCorporationContext(DbContextOptions<AcmeCorporationContext> options)
            : base(options)
        {
        }

        public DbSet<AcmeCorporation.Models.Submission> Submission { get; set; } = default!;

        public DbSet<AcmeCorporation.Models.SerialNumber> SerialNumber { get; set; } = default!;

       }
}


