using Contact.API.Entities;
using Contact.API.Repositories.Interfaces;
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
    public class ContactController:ControllerBase
    {
        private readonly IContactRepository _repository;
        private readonly ILogger<ContactController> _logger;

        public ContactController(IContactRepository repository, ILogger<ContactController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Kisiler>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Kisiler>>> GetContacts()
        {
            var contacts = await _repository.GetContacts();

            return Ok(contacts);
        }

    }
}
