using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.API.Entities
{
    public class IletisimBilgileri
    {
        public string Id { get; set; }
        public string BilgiTipi { get; set; }

        public string BilgiIcerik { get; set; }

    }
}
