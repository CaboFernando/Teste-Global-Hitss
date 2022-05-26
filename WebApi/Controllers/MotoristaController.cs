using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MotoristaController : ControllerBase
    {
        // GET api/motorista
        [HttpGet]
        public ActionResult<IEnumerable<Motorista>> Get()
        {
            return new Motorista[] { new Motorista() };
        }

        // GET api/motorista/1
        [HttpGet("{id}")]
        public ActionResult<Motorista> Get(int id)
        {
            return new Motorista();
        }

        // POST api/motorista
        [HttpPost]
        public void Post([FromBody] Motorista motorista)
        {
            
        }

        // PUT api/motorista
        [HttpPut("{id}")]
        public void Post(int id, [FromBody] Motorista motorista)
        {

        }

        // DELETE api/motorista/1
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
