using Contact.API.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.API.Data.Interfaces
{
    public interface IContactContext
    {
        IMongoCollection<Kisiler> Contacts { get; }
    }
}
