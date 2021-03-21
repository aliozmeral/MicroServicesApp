using Contact.API.Data.Interfaces;
using Contact.API.Entities;
using Contact.API.Repositories.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.API.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly IContactContext _context;

        public ContactRepository(IContactContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Kisiler>> GetContacts()
        {
            return await _context
                  .Contacts
                  .Find(p => true)
                  .ToListAsync();
        }

        public async Task<Kisiler> GetContact(string id)
        {
            return await _context
                           .Contacts
                           .Find(p => p.Id == id)
                           .FirstOrDefaultAsync();
        }


        public async Task Create(Kisiler kisi)
        {
            await _context.Contacts.InsertOneAsync(kisi);
        }

        public async Task<bool> Update(Kisiler kisi)
        {
            var updateResult = await _context
                                        .Contacts
                                        .ReplaceOneAsync(filter: g => g.Id == kisi.Id, replacement: kisi);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> Delete(string id)
        {
            FilterDefinition<Kisiler> filter = Builders<Kisiler>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _context
                                                .Contacts
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }


        public async Task<bool> AddContactDetail(IletisimBilgileri iletisimBilgileri, string id)
        {
            var builder = Builders<Kisiler>.Filter;
            var filter = builder.Eq(x => x.Id, id);

            var update = Builders<Kisiler>.Update
                .AddToSet(x => x.IletisimBilgileri, iletisimBilgileri);
            var updateResult = await _context.Contacts.UpdateOneAsync(filter, update);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteContactDetail(string id, string bilgiTipi)
        {
            var filter = Builders<Kisiler>.Filter.Where(x => x.Id == id);
            var update = Builders<Kisiler>.Update.PullFilter(ym => ym.IletisimBilgileri, Builders<IletisimBilgileri>.Filter.Where(nm => nm.BilgiTipi == bilgiTipi));
            var updateResult = await _context.Contacts.UpdateOneAsync(filter, update);
            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }


        public async Task<IEnumerable<Kisiler>> GetContactById(string id)
        {
            var filter = Builders<Kisiler>.Filter.Eq(x => x.Id, id);
   
            var  iletisim = await _context.Contacts.Find(filter).As<Kisiler>().ToListAsync();
         
            return iletisim;
        }

        public async Task<IEnumerable<Kisiler>> GetReportByLocation(string location)
        {
            var filter = Builders<Kisiler>.Filter.ElemMatch(s => s.IletisimBilgileri ,iletisim => iletisim.BilgiTipi ==location);

            var iletisim = await _context.Contacts.Find(filter).As<Kisiler>().ToListAsync();

            return iletisim;
        }

    }
}
 