using Contact.API.Data.Interfaces;
using Contact.API.Entities;
using Contact.API.Repositories.Interfaces;
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
    }
}
