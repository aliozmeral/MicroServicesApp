using Contact.API.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.API.Data
{
    public class ContactContextSeed
    {
        public static void SeedData(IMongoCollection<Kisiler> contactCollection)
        {

            bool existContact = contactCollection.Find(p => true).Any();
            if (!existContact)
            {
                contactCollection.InsertManyAsync(GetPreconfiguresContacts());
            }
        }

        private static IEnumerable<Kisiler> GetPreconfiguresContacts()
        {
            //esto me puedo fijar que lo saque de un json, está horrible hardcodeado acá
            return new List<Kisiler>()
            {
                 new Kisiler()
                {
                     UUID ="2d3606ea-d51c-4ce5-9687-a44bf79531d0",
                     Ad="Ali",
                     Soyad="Can",
                     Firma="ABC Firması",
                     IletisimBilgileri =  new IletisimBilgileri[] { 
                         new IletisimBilgileri() { BilgiTipi = "Email", BilgiIcerik = "ali@deneme.com" },
                         new IletisimBilgileri() { BilgiTipi = "Konum", BilgiIcerik = "Istanbul" },
                         new IletisimBilgileri() { BilgiTipi = "Telefon", BilgiIcerik = "555-5555555" }
                     }
                 },
                     new Kisiler()
                {
                     UUID ="123123-1312313",
                     Ad="Ayse",
                     Soyad="Can",
                     Firma="XYZ Firması",
                     IletisimBilgileri =  new IletisimBilgileri[] {
                         new IletisimBilgileri() { BilgiTipi = "Email", BilgiIcerik = "ayse@deneme.com" },
                         new IletisimBilgileri() { BilgiTipi = "Konum", BilgiIcerik = "Ankara" },
                         new IletisimBilgileri() { BilgiTipi = "Telefon", BilgiIcerik = "555-3333333" }
                     }
                 }
            };
        }
    }
}