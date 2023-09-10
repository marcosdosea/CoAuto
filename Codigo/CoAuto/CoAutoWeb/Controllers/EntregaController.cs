using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Core.Service;
using CoAutoWeb.Models;
using Core;

namespace CoAutoWeb.Controllers;

public class EntregaController : Controller
{
    private readonly IEntregaService _entregaService;
    private readonly IMapper _mapper;
    public EntregaController(IEntregaService entregaService, IMapper mapper)
    {
        _entregaService = entregaService;
        _mapper = mapper;
    }

    /// <summary>
    /// Retorna todas as entregas da ViewModel
    /// </summary>
    /// <returns>View(entregas)</returns>
    public async Task<ActionResult> Index()
    {
        var entregas = await _entregaService.GetAll();

        if (entregas == null) return BadRequest();

        var entregaModel = _mapper.Map<List<EntregaViewModel>>(entregas);

        return View(entregaModel);
    }

    // GET: EntregaController/Details/5
    public async Task<ActionResult> Details(uint? id)
    {
        var entrega = await _entregaService.GetAll();

        if (entrega == null) return BadRequest();

        var entregaModel = _mapper.Map<List<EntregaViewModel>>(entrega);

        return View(entregaModel);
    }

    // GET: EntregaController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: EntregaController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(EntregaViewModel entregaModel)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var entrega = _mapper.Map<Entrega>(entregaModel);
                await _entregaService.Create(entrega);
            }
            catch
            {
                return View(entregaModel);
            }

            return RedirectToAction(nameof(Index));
        }

        return View(entregaModel);
    }

    // GET: EntregaController/Edit/5
    public async Task<ActionResult> Edit(int id)
    {
        var entrega = await _entregaService.Get(id);

        var entregaModel = _mapper.Map<EntregaViewModel>(entrega);

        return View(entregaModel);
    }

    // POST: EntregaController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(uint id, EntregaViewModel entregaModel)
    {
        if (id != entregaModel.Id) return NotFound();


        if (ModelState.IsValid)
        {
            try
            {
                var entrega = _mapper.Map<Entrega>(entregaModel);
                await _entregaService.Edit(entrega);
            }
            catch
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }

        return View(entregaModel);

    }

    // GET: EntregaController/Delete/5
    public async Task<ActionResult> Delete(int? id)
    {
        if (id == null) return BadRequest();

        var entrega = await _entregaService.Get((int)id);

        if (entrega == null) return NotFound();

        var entregaModel = _mapper.Map<EntregaViewModel>(entrega);

        return View(entregaModel);
    }

    // POST: EntregaController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Delete(int id)
    {
        await _entregaService.Delete(id);

        return RedirectToAction(nameof(Index));
    }
}
