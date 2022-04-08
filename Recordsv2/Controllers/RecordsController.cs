using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Recordsv2.Manager;
using Recordsv2.Models;


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
        public ActionResult<Record> Get(int id){
            return _manager.GetById(id);
        }

        // POST api/<RecordsController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<Record> Post([FromBody] Record newRecord){
            Record createdRecord = new Record();
            if (newRecord.Title == null){
                return BadRequest();
            }
            createdRecord = _manager.AddRecord(newRecord);
            return Created("api/Records/" + createdRecord.Id, createdRecord);
        }

        // PUT api/<RecordsController>/5
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public ActionResult<Record> Put(int id, [FromBody] Record recordValue){
            if (recordValue.Title == null || recordValue.Artist == null){
                return BadRequest();
            }
            Record record = _manager.GetById(id);
            if(record == null){
                return NotFound();
            }
            return Ok(_manager.UpdateRecord(id, recordValue));
        }

        // DELETE api/<RecordsController>/5
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpDelete("{id}")]
        public ActionResult<Record> Delete(int id){
            Record recordToBeDeleted = _manager.GetById(id);
            if (recordToBeDeleted == null){
                return NotFound();
            }

            _manager.DeleteRecord(id);
            return Ok(recordToBeDeleted);
        }

        
    }
}
