using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.API.Entities
{
    public class IletisimBilgileri
    {
      
        public string BilgiTipi { get; set; }

        public string BilgiIcerik { get; set; }

    }
}
