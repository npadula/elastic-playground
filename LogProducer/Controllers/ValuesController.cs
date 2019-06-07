using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LogProducer.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private ILogger _logger;

        public ValuesController(ILogger<ValuesController> logger)
        {
            _logger = logger;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
            var obj = new { Prop = "Val", Prop2 = 123 };
            _logger.LogInformation("My Test Obj: {obj}",obj);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody]string value)
        {
            var ex = new Exception("Inner");
            var ex2 = new Exception("Outer", ex);
            throw ex2;
            return "ok";

            
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return "ok";
        }
    }
}
