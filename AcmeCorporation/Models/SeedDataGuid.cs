using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AcmeCorporationNewDatabase;
using System;
using System.Linq;
using static Azure.Core.HttpHeader;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

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

