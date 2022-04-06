using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Recordsv2.Manager;
using Recordsv2.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Recordsv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        private RecordsManager _manager = new RecordsManager();
        // GET: api/<RecordsController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<IEnumerable<Record>> GetAll(string filterString, string year)
        {
            IEnumerable<Record> result = _manager.GetAll(filterString, year);
            if (result.Count() == 0)
            {
                NoContent();
            }
            return Ok(result);
        }

        // GET api/<RecordsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RecordsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RecordsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RecordsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
