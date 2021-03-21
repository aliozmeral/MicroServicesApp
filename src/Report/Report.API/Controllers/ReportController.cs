using DotNetCore.CAP;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Report.API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly ICapPublisher _capPublisher;
        public ReportController(ICapPublisher capPublisher)
        {
            _capPublisher = capPublisher;
        }

        public async Task<IActionResult> ProducerTransaction()
        {
            using DAPContext context = new DAPContext();
            using var transaction = context.Database.BeginTransaction(_capPublisher, autoCommit: true);
            // var date = DateTime.Now;
            // await _capPublisher.PublishAsync<DateTime>("producer.transaction",);
            var active = false;
            await _capPublisher.PublishAsync<bool>("producer.transaction", active);
            return Ok(active);
        }


    }
}
