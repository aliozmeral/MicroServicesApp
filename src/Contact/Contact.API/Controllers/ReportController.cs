using Contact.API.Entities;
using Contact.API.RabbitMQ;
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
    public class ReportController : ControllerBase
    {
        private readonly IContactRepository _repository;
        private readonly ILogger<ReportController> _logger;

        public ReportController(IContactRepository repository, ILogger<ReportController> logger)
        {
            _repository = repository;
            _logger = logger;

        }

        [HttpGet("{location}", Name = "GetLocation")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<Kisiler>), (int)HttpStatusCode.OK)]
        [CapSubscribe("producer.transaction", Group = "group1")]
        public async Task<ActionResult<IEnumerable<Kisiler>>> GetReportByLocation(string location,string active)
        {
           
            var contactDetail = await _repository.GetReportByLocation(location);

            if (contactDetail == null)
            {
                _logger.LogError($".... with id: {location}, not found.");
                return NotFound();
            }

            ReportSender rp = new ReportSender();

            rp.Sender();

            return Ok(contactDetail);
        }

    }
}
