using Contact.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.API.Repositories.Interfaces
{
    public interface IContactRepository
    {
        Task<IEnumerable<Kisiler>> GetContacts();
    }
}
