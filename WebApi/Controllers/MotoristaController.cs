using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model;
using WebApi.Repositorio;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MotoristaController : ControllerBase
    {
        private readonly MotoristaRepositorio _motoristaRepositorio;

        public MotoristaController()
        {
            _motoristaRepositorio = new MotoristaRepositorio();
        }

        // GET api/motorista
        [HttpGet]
        public ActionResult<IEnumerable<Motorista>> Get()
        {
            try
            {
                var lista = _motoristaRepositorio.GetMotoristas();

                if (lista.Count == 0)
                    return NotFound("Lista de motoristas vazia");

                return lista;
            }
            catch (Exception)
            {
                return BadRequest("Erro ao consultar a lista de Motoristas");
            }
        }

        // GET api/motorista/1
        [HttpGet("{codigo}")]
        public ActionResult<Motorista> Get(int codigo)
        {
            try
            {
                Motorista motorista = _motoristaRepositorio.GetMotorista(codigo);

                if(motorista.Nome == null)
                    return NotFound("Motorista não encontrado");

                return motorista;
            }
            catch (Exception)
            {
                return BadRequest("Erro ao consultar o Motorista");
            }
        }

        // POST api/motorista
        [HttpPost]
        public ActionResult Post([FromBody] Motorista motorista)
        {
            try
            {
                _motoristaRepositorio.PostMotorista(motorista);
            }
            catch (Exception)
            {
                return BadRequest("Erro ao cadastrar o motorista.");
            }
            return Ok("Motorista cadastrado com sucesso!");
        }

        // PUT api/motorista
        [HttpPut]
        public ActionResult Put([FromBody] Motorista motorista)
        {
            try
            {
                _motoristaRepositorio.PutMotorista(motorista);
            }
            catch (Exception)
            {
                return BadRequest("Erro ao atualizar o motorista.");
            }
            return Ok("Motorista atualizado com sucesso!");
        }

        // DELETE api/motorista/1
        [HttpDelete]
        public ActionResult Delete(int codigo)
        {
            try
            {
                _motoristaRepositorio.DeleteMotorista(codigo);
            }
            catch (Exception)
            {
                return BadRequest("Erro ao excluir o motorista.");
            }
            return Ok("Motorista excluído com sucesso!");
        }
    }
}
