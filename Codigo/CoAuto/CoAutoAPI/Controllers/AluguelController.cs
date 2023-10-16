using AutoMapper;
using Core;
using Core.Service;
using CoAutoWeb.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoAutoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AluguelController : ControllerBase
    {
        private readonly IAluguelService _aluguelService;
        private readonly IMapper _mapper;

        public AluguelController(IAluguelService aluguelService, IMapper mapper)
        {
            _aluguelService = aluguelService;
            _mapper = mapper;
        }


        // GET: api/<AluguelController>
        [HttpGet]
        public ActionResult Get()
        {
            var listaAluguel = _aluguelService.GetAll();
            if (listaAluguel == null)
                return NotFound();

            return Ok(listaAluguel);
        }

        // GET api/<AluguelController>/5
        [HttpGet("{id}")]
        public ActionResult Get(uint id)
        {
            Aluguel aluguel = _aluguelService.Get(id);
            if (aluguel == null)
                return NotFound();

            return Ok(aluguel);
        }

        // POST api/<AluguelController>
        [HttpPost]
        public ActionResult Post([FromBody] AluguelViewModel aluguelView)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados invalidos.");

            var aluguel = _mapper.Map<Aluguel>(aluguelView);
            _aluguelService.Create(aluguel);

            return Ok();
        }

        // PUT api/<AluguelController>/5
        [HttpPut("{id}")]
        public ActionResult Put(uint id, [FromBody] AluguelViewModel aluguelView)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados Invalidos.");

            var aluguel = _mapper.Map<Aluguel>(aluguelView);
            if (aluguel == null)
                return NotFound();

            _aluguelService.Edit(aluguel);

            return Ok();
        }

        // DELETE api/<AluguelController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(uint id)
        {
            Aluguel aluguel = _aluguelService.Get(id);
            if (aluguel == null)
                return NotFound();

            _aluguelService.Delete(id);
            return Ok();
        }
    }
}
