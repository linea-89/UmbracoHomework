using Microsoft.EntityFrameworkCore;
using AcmeCorporation.Data;

namespace AcmeCorporation.Models;

public static class SeedDataGuid
{

    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new AcmeCorporationContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<AcmeCorporationContext>>()))
        {
            if (context.SerialNumber.Any())
            {
                return;
            }

            for (int i = 0; i < 100; i++)
            { 
                context.SerialNumber.Add(new SerialNumber
                {
                    ProductSerialNumber = Guid.NewGuid()
                });
            }


            context.SaveChanges();

        }
    }
}

