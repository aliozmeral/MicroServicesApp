using Contact.API.Entities;
using Contact.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Contact.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ContactDetailController:ControllerBase
    {
        private readonly IContactRepository _repository;
        private readonly ILogger<ContactController> _logger;

        public ContactDetailController(IContactRepository repository, ILogger<ContactDetailController> logger)
        {
            _repository = repository;
        
        }

        [HttpPost]
        [ProducesResponseType(typeof(IletisimBilgileri), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Kisiler>> CreateProduct([FromBody] IletisimBilgileri iletisimBilgileri,string id)
        {

            await _repository.AddContactDetail(iletisimBilgileri, id);

            return Ok(iletisimBilgileri);
        }

        [HttpDelete("{id:length(24)}")]
        [ProducesResponseType(typeof(Kisiler), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteProductById(string id,string bilgiTipi)
        {
            return Ok(await _repository.DeleteContactDetail(id,bilgiTipi));
        }

        [HttpGet("{id:length(24)}", Name = "GetContact")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<Kisiler>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Kisiler>>>  GetProductById(string id)
        {
            var contactDetail = await _repository.GetContactById(id);

            if (contactDetail == null)
            {
                _logger.LogError($"Contact Detail with id: {id}, not found.");
                return NotFound();
            }

            return Ok(contactDetail);
        }
    }
}
