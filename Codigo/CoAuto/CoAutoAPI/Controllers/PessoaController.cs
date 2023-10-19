using AutoMapper;
using Core;
using Core.Service;
using CoAutoWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace CoAutoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _pessoaService;
        private readonly IMapper _mapper;

        public PessoaController(IPessoaService pessoaService, IMapper mapper)
        {
            _pessoaService = pessoaService;
            _mapper = mapper;
        }

        // GET: api/<PessoaController>
        [HttpGet]
        public ActionResult Get()
        {
            var listaPessoa = _pessoaService.GetAll();
            if (listaPessoa == null)
                return NotFound();

            return Ok(listaPessoa);
        }

        // GET api/<PessoaController>/5
        [HttpGet("{id}")]
        public ActionResult Get(uint id)
        {
            Pessoa pessoa = _pessoaService.Get(id);
            if (pessoa == null)
                return NotFound();

            return Ok(pessoa);
        }

        // POST api/<PessoaController>
        [HttpPost]
        public ActionResult Post([FromBody] PessoaViewModel pessoaView)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados invalidos.");

            var pessoa = _mapper.Map<Pessoa>(pessoaView);
            _pessoaService.Create(pessoa);

            return Ok();
        }

        // PUT api/<PessoaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(uint id, [FromBody] PessoaViewModel pessoaView)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados Invalidos.");

            var pessoa = _mapper.Map<Pessoa>(pessoaView);
            if (pessoa == null)
                return NotFound();

            _pessoaService.Edit(pessoa);

            return Ok();
        }

        // DELETE api/<PessoaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(uint id)
        {
            Pessoa pessoa = _pessoaService.Get(id);
            if (pessoa == null)
                return NotFound();

            _pessoaService.Delete(id);
            return Ok();
        }
    }
}