using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System.IO;
using Newtonsoft.Json;
using MyWeeFee.Models;

namespace MyWeeFee
{
    public static class DbContextExtension
    {
/*
        public static bool AllMigrationsApplied(this DbContext db)
        {
            var applied = db.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);
 
            var total = db.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);
 
            return !total.Except(applied).Any();
        }
*/

// ALTERNATIVELY (with JSON)
/*
        public static void EnsureSeeded(this MyWeeFeeContext db)
        {
            // Ensure we have some APEncryptions 
            if (!db.T_APEncryptions.Any())
            {
                var ape = JsonConvert.DeserializeObject<List<APEncryption>>(File.ReadAllText(@"Seed" + Path.DirectorySeparatorChar + "APEncryptions.json"));
                db.T_APEncryptions.AddRange(ape);
                db.SaveChanges();
            }
        }
*/
 
// ALTERNATIVELY (without JSON)
/*
        public static void EnsureSeeded(this MyWeeFeeContext db)
        {
            AddAPEncryption(db);
        }

        private static async void AddAPEncryption(MyWeeFeeContext db)
        {
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
                
            db.SaveChanges();
        }
*/
    }
}