using AutoMapper;
using CoAutoWeb.Models;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoAutoWeb.Controllers;

public class VeiculoController : Controller
{
    private readonly IVeiculoService _veiculoService;
    private readonly IModeloService _modeloService;
    private readonly IMapper _mapper;
    public VeiculoController(IVeiculoService veiculoService, IModeloService modeloService, IMapper mapper)
    {
        _veiculoService = veiculoService;
        _modeloService = modeloService;
        _mapper = mapper;
    }

    [HttpGet]
    /// <summary>
    /// Retorna todos os veiculos da ViewModel
    /// </summary>
    /// <returns>View(veiculos)</returns>
    public async Task<ActionResult> Index()
    {
        var veiculos = await _veiculoService.GetAll();

        if (veiculos == null) return BadRequest();

        var modelos = await _modeloService.GetAll();
        var veiculoModel = veiculos.Select(veiculo => new VeiculoViewModel
        {
            Ano = veiculo.Ano,
            Autorizado = veiculo.Autorizado,
            Bairro = veiculo.Bairro,
            Cambio = veiculo.Cambio,
            Carroceria = veiculo.Carroceria,
            Cep = veiculo.Cep,
            Cidade = veiculo.Cidade,
            Cilindradas = veiculo.Cilindradas,
            Combustivel = veiculo.Combustivel,
            Crlv = veiculo.Crlv,
            Estado = veiculo.Estado,
            Id = veiculo.Id,
            IdModelo = veiculo.IdModelo,
            IdPessoa = veiculo.IdPessoa,
            Modelo = modelos.FirstOrDefault(modelo => modelo.Id == veiculo.IdModelo).Nome,
            Numero = veiculo.Numero,
            Passageiro = veiculo.Passageiro,
            Placa = veiculo.Placa,
            Portas = veiculo.Portas,
            Rua = veiculo.Rua,
            Tipo = veiculo.Tipo,
            Valor = veiculo.Valor
        }).ToList();
        return View(veiculoModel);
    }

    // GET: VeiculoController/Details/5
    [HttpGet]
    public async Task<ActionResult> Details(uint id)
    {
        var veiculo = await _veiculoService.Get(id);

        if (veiculo == null) return BadRequest();

        var modelos = await _modeloService.GetAll();
        var veiculoModel = new VeiculoViewModel
        {
            Ano = veiculo.Ano,
            Autorizado = veiculo.Autorizado,
            Bairro = veiculo.Bairro,
            Cambio = veiculo.Cambio,
            Carroceria = veiculo.Carroceria,
            Cep = veiculo.Cep,
            Cidade = veiculo.Cidade,
            Cilindradas = veiculo.Cilindradas,
            Combustivel = veiculo.Combustivel,
            Crlv = veiculo.Crlv,
            Estado = veiculo.Estado,
            Id = veiculo.Id,
            IdModelo = veiculo.IdModelo,
            IdPessoa = veiculo.IdPessoa,
            Modelo = modelos.FirstOrDefault(modelo => modelo.Id == veiculo.IdModelo).Nome,
            Numero = veiculo.Numero,
            Passageiro = veiculo.Passageiro,
            Placa = veiculo.Placa,
            Portas = veiculo.Portas,
            Rua = veiculo.Rua,
            Tipo = veiculo.Tipo,
            Valor = veiculo.Valor
        };
        return View(veiculoModel);
    }

    // GET: VeiculoController/Create
    public async Task<ActionResult> Create()
    {
        var modelos = await _modeloService.GetAll();
        var items = modelos.Select(modelo => new SelectListItem { Value = modelo.Id.ToString(), Text = modelo.Nome }).ToList();
        var selectList = new SelectList(items, "Value", "Text");
        ViewBag.ModelosSelectList = selectList;
        return View();
    }

    // POST: VeiculoController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(VeiculoViewModel veiculoModel)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var veiculo = _mapper.Map<Veiculo>(veiculoModel);
                await _veiculoService.Create(veiculo);
            }
            catch
            {
                return View(veiculoModel);
            }
            return RedirectToAction(nameof(Index));
        }
        return View(veiculoModel);
    }

    // GET: VeiculoController/Edit/5
    public async Task<ActionResult> Edit(uint id)
    {
        var veiculo = await _veiculoService.Get(id);
        var veiculoModel = _mapper.Map<VeiculoViewModel>(veiculo);
        var modelos = await _modeloService.GetAll();
        var items = modelos.Select(modelo => new SelectListItem { Value = modelo.Id.ToString(), Text = modelo.Nome }).ToList();
        var selectList = new SelectList(items, "Value", "Text");
        ViewBag.ModelosSelectList = selectList;
        return View(veiculoModel);
    }

    // POST: VeiculoController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(uint id, VeiculoViewModel veiculoModel)
    {
        if (id != veiculoModel.Id) return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                var veiculo = _mapper.Map<Veiculo>(veiculoModel);
                await _veiculoService.Edit(veiculo);
            }
            catch
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }
        return View(veiculoModel);
    }

    // GET: VeiculoController/Delete/5
    [HttpGet]
    public async Task<ActionResult> Delete(uint? id)
    {
        if (id == null) return BadRequest();

        var veiculo = await _veiculoService.Get((uint)id);

        if (veiculo == null) return NotFound();

        var modelos = await _modeloService.GetAll();
        var veiculoModel = new VeiculoViewModel
        {
            Ano = veiculo.Ano,
            Autorizado = veiculo.Autorizado,
            Bairro = veiculo.Bairro,
            Cambio = veiculo.Cambio,
            Carroceria = veiculo.Carroceria,
            Cep = veiculo.Cep,
            Cidade = veiculo.Cidade,
            Cilindradas = veiculo.Cilindradas,
            Combustivel = veiculo.Combustivel,
            Crlv = veiculo.Crlv,
            Estado = veiculo.Estado,
            Id = veiculo.Id,
            IdModelo = veiculo.IdModelo,
            IdPessoa = veiculo.IdPessoa,
            Modelo = modelos.FirstOrDefault(modelo => modelo.Id == veiculo.IdModelo).Nome,
            Numero = veiculo.Numero,
            Passageiro = veiculo.Passageiro,
            Placa = veiculo.Placa,
            Portas = veiculo.Portas,
            Rua = veiculo.Rua,
            Tipo = veiculo.Tipo,
            Valor = veiculo.Valor
        };
        return View(veiculoModel);
    }

    // POST: VeiculoController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Delete(uint id)
    {
        await _veiculoService.Delete(id);
        return RedirectToAction(nameof(Index));
    }
}
