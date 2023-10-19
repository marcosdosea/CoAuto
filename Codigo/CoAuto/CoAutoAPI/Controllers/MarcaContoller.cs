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
    public class MarcaController : ControllerBase
    {
        private readonly IMarcaService _marcaService;
        private readonly IMapper _mapper;

        public MarcaController(IMarcaService marcaService, IMapper mapper)
        {
            _marcaService = marcaService;
            _mapper = mapper;
        }


        // GET: api/<MarcaController>
        [HttpGet]
        public ActionResult Get()
        {
            var listaMarca = _marcaService.GetAll();
            if (listaMarca == null)
                return NotFound();

            return Ok(listaMarca);
        }

        // GET api/<MarcaController>/5
        [HttpGet("{id}")]
        public ActionResult Get(uint id)
        {
            Marca marca = _marcaService.Get(id);
            if (marca == null)
                return NotFound();

            return Ok(marca);
        }

        // POST api/<MarcaController>
        [HttpPost]
        public ActionResult Post([FromBody] MarcaViewModel marcaView)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados invalidos.");

            var marca = _mapper.Map<Marca>(marcaView);
            _marcaService.Create(marca);

            return Ok();
        }

        // PUT api/<MarcaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(uint id, [FromBody] MarcaViewModel marcaView)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados Invalidos.");

            var marca = _mapper.Map<Marca>(marcaView);
            if (marca == null)
                return NotFound();

            _marcaService.Edit(marca);

            return Ok();
        }

        // DELETE api/<MarcaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(uint id)
        {
            Marca marca = _marcaService.Get(id);
            if (marca == null)
                return NotFound();

            _marcaService.Delete(id);
            return Ok();
        }
    }
}
