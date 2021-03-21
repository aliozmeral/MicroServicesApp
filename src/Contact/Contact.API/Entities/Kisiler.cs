using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.API.Entities
{
    public class Kisiler
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string UUID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Firma { get; set; }
        public IletisimBilgileri[] IletisimBilgileri { get; set; }

    }
}
