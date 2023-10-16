using AutoMapper;
using Core;
using Core.Service;
using CoAutoWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoAutoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BancoController : ControllerBase
    {
        private readonly IBancoService _bancoService;
        private readonly IMapper _mapper;

        public BancoController(IBancoService bancoService, IMapper mapper)
        {
            _bancoService = bancoService;
            _mapper = mapper;
        }


        // GET: api/<BancoController>
        [HttpGet]
        public ActionResult Get()
        {
            var listaBanco = _bancoService.GetAll();
            if (listaBanco == null)
                return NotFound();

            return Ok(listaBanco);
        }

        // GET api/<BancoController>/5
        [HttpGet("{id}")]
        public ActionResult Get(uint id)
        {
            Banco banco = _bancoService.Get(id);
            if (banco == null)
                return NotFound();

            return Ok(banco);
        }

        // POST api/<BancoController>
        [HttpPost]
        public ActionResult Post([FromBody] BancoViewModel bancoView)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados invalidos.");

            var banco = _mapper.Map<Banco>(bancoView);
            _bancoService.Create(banco);

            return Ok();
        }

        // PUT api/<BancoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(uint id, [FromBody] BancoViewModel bancoView)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados Invalidos.");

            var banco = _mapper.Map<Banco>(bancoView);
            if (banco == null)
                return NotFound();

            _bancoService.Edit(banco);

            return Ok();
        }

        // DELETE api/<BancoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(uint id)
        {
            Banco banco = _bancoService.Get(id);
            if (banco == null)
                return NotFound();

            _bancoService.Delete(id);
            return Ok();
        }
    }
}
