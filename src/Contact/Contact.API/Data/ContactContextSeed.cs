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
            };
        }
    }
}