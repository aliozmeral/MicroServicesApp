using Contact.API.Entities;
using Contact.API.Repositories.Interfaces;
using DotNetCore.CAP;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Contact.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _repository;
        private readonly ILogger<ContactController> _logger;

        public ContactController(IContactRepository repository, ILogger<ContactController> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        //Tüm kişileri listeme
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Kisiler>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Kisiler>>> GetContacts()
        {
            var contacts = await _repository.GetContacts();

            return Ok(contacts);
        }


        [HttpPost]
        [ProducesResponseType(typeof(Kisiler), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Kisiler>> CreateProduct([FromBody] Kisiler kisi)
        {
            await _repository.Create(kisi);

            return CreatedAtRoute("GetContacts", new { id = kisi.Id }, kisi);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Kisiler), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateProduct([FromBody] Kisiler kisi)
        {
            return Ok(await _repository.Update(kisi));
        }

        [HttpDelete("{id:length(24)}")]
        [ProducesResponseType(typeof(Kisiler), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteProductById(string id)
        {
            return Ok(await _repository.Delete(id));
        }

        


        //[NonAction]
        //[CapSubscribe("producer.transaction", Group = "group1")]
        //public async Task<IActionResult> GetReport(bool active)
        //{
        //    Console.WriteLine(active);

            
        //    return Ok(active);
        //}
    }

    
}
