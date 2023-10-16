using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using CoAutoAPI.Models;

namespace CoAutoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisponibilidadeController : ControllerBase
    {
        private readonly IDisponibilidadeService _disponibilidadeService;
        private readonly IMapper _mapper;

        public DisponibilidadeController(IDisponibilidadeService disponibilidadeService, IMapper mapper)
        {
            _disponibilidadeService = disponibilidadeService;
            _mapper = mapper;
        }

        // GET: api/<DisponibilidadeController>
        [HttpGet]
        public ActionResult Get()
        {
            var listaDisponibilidade = _disponibilidadeService.GetAll();
            if (listaDisponibilidade == null)
                return NotFound();

            return Ok(listaDisponibilidade);
        }

        // GET api/<DisponibilidadeController>/5
        [HttpGet("{id}")]
        public ActionResult Get(uint id)
        {
            Disponibilidade disponibilidade = _disponibilidadeService.Get(id);
            if (disponibilidade == null)
                return NotFound();

            return Ok(disponibilidade);
        }

        // POST api/<DisponibilidadeController>
        [HttpPost]
        public ActionResult Post([FromBody] DisponibilidadeViewModel disponibilidadeView)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados invalidos.");

            var disponibilidade = _mapper.Map<Disponibilidade>(disponibilidadeView);
            _disponibilidadeService.Create(disponibilidade);

            return Ok();
        }

        // PUT api/<DisponibilidadeController>/5
        [HttpPut("{id}")]
        public ActionResult Put(uint id, [FromBody] DisponibilidadeViewModel disponibilidadeView)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados Invalidos.");

            var disponibilidade = _mapper.Map<Disponibilidade>(disponibilidadeView);
            if (disponibilidade == null)
                return NotFound();

            _disponibilidadeService.Edit(disponibilidade);

            return Ok();
        }

        // DELETE api/<DisponibilidadeController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(uint id)
        {
            Disponibilidade disponibilidade = _disponibilidadeService.Get(id);
            if (disponibilidade == null)
                return NotFound();

            _disponibilidadeService.Delete(id);
            return Ok();
        }
    }
}
