using AutoMapper;
using CoAutoWeb.Models;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoAutoWeb.Controllers;
[Authorize]
public class MarcaController : Controller
{
    private readonly IMarcaService _marcaService;
    private readonly IMapper _mapper;
    public MarcaController(IMarcaService marcaService, IMapper mapper)
    {
        _marcaService = marcaService;
        _mapper = mapper;
    }
    // GET: MarcaController
    public ActionResult Index()
    {
        var listaMarcas = _marcaService.GetAll();
        var listaMarcasModel = _mapper.Map<List<MarcaViewModel>>(listaMarcas);
        return View(listaMarcasModel);
    }
    // GET: MarcaController/Details/5
    public ActionResult Details(uint id)
    {
        Marca marca = _marcaService.Get(id);
        MarcaViewModel marcaModel = _mapper.Map<MarcaViewModel>(marca);
        return View(marcaModel);
    }
    // GET: MarcaController/Create
    public ActionResult Create()
    {
        return View();
    }
    // POST: MarcaController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(MarcaViewModel marcaModel)
    {
        if (ModelState.IsValid)
        {
            var marca = _mapper.Map<Marca>(marcaModel);
            _marcaService.Create(marca);
        }
        return RedirectToAction(nameof(Index));
    }
    // GET: MarcaController/Edit/5
    public ActionResult Edit(uint id)
    {
        return Details(id);
    }
    // POST: MarcaController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(uint id, MarcaViewModel marcaModel)
    {
        if (ModelState.IsValid)
        {
            var marca = _mapper.Map<Marca>(marcaModel);
            _marcaService.Edit(marca);
        }
        return RedirectToAction(nameof(Index));
    }
    // GET: MarcaController/Delete/5
    public ActionResult Delete(uint id)
    {
        Marca marca = _marcaService.Get(id);
        MarcaViewModel marcaModel = _mapper.Map<MarcaViewModel>(marca);
        return View(marcaModel);
    }
    // POST: MarcaController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(uint id, MarcaViewModel marcaModel)
    {
        _marcaService.Delete(id);
        return RedirectToAction(nameof(Index));
    }
}
