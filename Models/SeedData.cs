using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MyWeeFee.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
/*
            using (var db = new MyWeeFeeContext(
                serviceProvider.GetRequiredService<DbContextOptions<MyWeeWeeContext>>()))
            {
                // Look for any movies.
                if (db.T_APEncryptions.Any())
                {
                    return;   // DB has been seeded
                }

                db.T_APEncryptions.AddRange(
                    new APEncryption { Id = 0, Encryption = "Ohne (Offen)" },
                    new APEncryption { Id = 1, Encryption = "WEP" },
                    new APEncryption { Id = 2, Encryption = "WPA" },
                    new APEncryption { Id = 3, Encryption = "WPA2 (AES)" },
                    new APEncryption { Id = 4, Encryption = "WPA2 (TKIP)" }
                    );

                // benötigt, um 'FOREIGN KEY constraint' SqliteException auszuschliessen
                db.T_Classes.AddRange(
                    new Class { Id = 0, ClassName = "Ohne" }
                    );
                    
                db.SaveChanges();
            }
*/
        }
    }
}