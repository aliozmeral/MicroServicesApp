using Contact.API.Data.Interfaces;
using Contact.API.Entities;
using Contact.API.Settings;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.API.Data
{
    public class ContactContext: IContactContext
    {
        public ContactContext(IContactDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            Contacts = database.GetCollection<Kisiler>(settings.CollectionName);
            ContactContextSeed.SeedData(Contacts);
        }
        public IMongoCollection<Kisiler> Contacts { get; }
    }
}
