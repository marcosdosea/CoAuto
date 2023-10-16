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
    public class PagamentoController : ControllerBase
    {
        private readonly IPagamentoService _pagamentoService;
        private readonly IMapper _mapper;

        public PagamentoController(IPagamentoService pagamentoService, IMapper mapper)
        {
            _pagamentoService = pagamentoService;
            _mapper = mapper;
        }


        // GET: api/<PagamentoController>
        [HttpGet]
        public ActionResult Get()
        {
            var listaPagamento = _pagamentoService.GetAll();
            if (listaPagamento == null)
                return NotFound();

            return Ok(listaPagamento);
        }

        // GET api/<PagamentoController>/5
        [HttpGet("{id}")]
        public ActionResult Get(uint id)
        {
            Pagamento pagamento = _pagamentoService.Get(id);
            if (pagamento == null)
                return NotFound();

            return Ok(pagamento);
        }

        // POST api/<PagamentoController>
        [HttpPost]
        public ActionResult Post([FromBody] PagamentoViewModel pagamentoView)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados invalidos.");

            var pagamento = _mapper.Map<Pagamento>(pagamentoView);
            _pagamentoService.Create(pagamento);

            return Ok();
        }

        // PUT api/<PagamentoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(uint id, [FromBody] PagamentoViewModel pagamentoView)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados Invalidos.");

            var pagamento = _mapper.Map<Pagamento>(pagamentoView);
            if (pagamento == null)
                return NotFound();

            _pagamentoService.Edit(pagamento);

            return Ok();
        }

        // DELETE api/<PagamentoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(uint id)
        {
            Pagamento pagamento = _pagamentoService.Get(id);
            if (pagamento == null)
                return NotFound();

            _pagamentoService.Delete(id);
            return Ok();
        }
    }
}
