using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataCrawler.Model.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using DataCrawler.Producer;
using DataCrawler.Model.InterFace;

namespace DataCrawler.Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatapumpController : ControllerBase
    {
        private readonly IDataDumpService _dataDumpService;

        public DatapumpController(IDataDumpService dataDumpService)
        {
            _dataDumpService = dataDumpService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async Task<MessageQueueResponse> QueueMessageAsync([FromBody] MessageQueueRequest messageQueueRequest)
        {
            var response = await _dataDumpService.QueueMessageAsync(messageQueueRequest);
            if (response?.Errors.Any() == false)
                Ok(response);
            return BadRequest(response);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
