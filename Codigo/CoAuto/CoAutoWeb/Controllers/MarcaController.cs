using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Core.Service;
using CoAutoWeb.Models;
using Core;

namespace CoAutoWeb.Controllers;

public class MarcaController : Controller
{
    private readonly IMarcaService _marcaService;
    private readonly IMapper _mapper;
    public MarcaController(IMarcaService marcaService, IMapper mapper)
    {
        _marcaService = marcaService;
        _mapper = mapper;
    }

    /// <summary>
    /// Retorna todas as marcas da ViewModel
    /// </summary>
    /// <returns>View(companies)</returns>
    public async Task<ActionResult> Index()
    {
        var marcas = await _marcaService.GetAll();

        if (marcas == null) return BadRequest();

        var marcaModel = _mapper.Map<List<MarcaViewModel>>(marcas);

        return View(marcaModel);
    }

    // GET: CompanyController/Details/5
    [HttpGet]
    public async Task<ActionResult> Details(int id)
    {
        var marca = await _marcaService.Get(id);

        if (marca == null) return BadRequest();

        var marcaModel = _mapper.Map<MarcaViewModel>(marca);

        return View(marcaModel);
    }

    // GET: CompanyController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: CompanyController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(MarcaViewModel marcaModel)
    {

        if (ModelState.IsValid)
        {
            try
            {
                var marca = _mapper.Map<Marca>(marcaModel);
                await _marcaService.Create(marca);
            }
            catch
            {
                return View(marcaModel);
            }

            return RedirectToAction(nameof(Index));
        }

        return View(marcaModel);

    }

    // GET: CompanyController/Edit/5
    [HttpGet]
    public async Task<ActionResult> Edit(int id)
    {
        var marca = await _marcaService.Get(id);

        var marcaModel = _mapper.Map<MarcaViewModel>(marca);

        return View(marcaModel);
    }

    // POST: CompanyController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(int id, MarcaViewModel marcaModel)
    {
        if (id != marcaModel.Id) return NotFound();


        if (ModelState.IsValid)
        {
            try
            {
                var marca = _mapper.Map<Marca>(marcaModel);
                await _marcaService.Edit(marca);
            }
            catch
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }

        return View(marcaModel);

    }

    // GET: CompanyController/Delete/5
    [HttpGet]
    public async Task<ActionResult> Delete(int? id)
    {
        if (id == null) return BadRequest();

        var marca = await _marcaService.Get((int)id);

        if (marca == null) return NotFound();

        var marcaModel = _mapper.Map<MarcaViewModel>(marca);

        return View(marcaModel);
    }

    // POST: CompanyController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Delete(int id)
    {
        await _marcaService.Delete(id);

        return RedirectToAction(nameof(Index));
    }
}
