using Contact.API.Entities;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.API.Repositories.Interfaces
{
    public interface IContactRepository
    {
        Task<IEnumerable<Kisiler>> GetContacts();
        Task<Kisiler> GetContact(string id);
        Task Create(Kisiler kisi);
        Task<bool> Update(Kisiler kisi);
        Task<bool> Delete(string id);

        Task<bool> AddContactDetail(IletisimBilgileri iletisimBilgileri,string id);

        Task<bool> DeleteContactDetail(string id, string bilgiTipi);

        Task<IEnumerable<Kisiler>> GetContactById(string id);

        Task<IEnumerable<Kisiler>> GetReportByLocation(string location);
        

    }
}
