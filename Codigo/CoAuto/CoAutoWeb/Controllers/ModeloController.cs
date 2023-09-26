using AutoMapper;
using CoAutoWeb.Models;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace CoAutoWeb.Controllers;

public class ModeloController : Controller
{
    private readonly IModeloService _modeloService;
    private readonly IMapper _mapper;
    public ModeloController(IModeloService modeloController, IMapper mapper)
    {
        _modeloService = modeloController;
        _mapper = mapper;
    }
    // GET: ModeloController
    public ActionResult Index()
    {
        var listaModelos = _modeloService.GetAll();
        var listaModelosModel = _mapper.Map<List<ModeloViewModel>>(listaModelos);
        return View(listaModelosModel);
    }
    // GET: ModeloController/Details/5
    public ActionResult Details(uint id)
    {
        Modelo modelo = _modeloService.Get(id);
        ModeloViewModel modeloModel = _mapper.Map<ModeloViewModel>(modelo);
        return View(modeloModel);
    }
    // GET: ModeloController/Create
    public ActionResult Create()
    {
        return View();
    }
    // POST: ModeloController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(ModeloViewModel modeloModel)
    {
        if (ModelState.IsValid)
        {
            var modelo = _mapper.Map<Modelo>(modeloModel);
            _modeloService.Create(modelo);
        }
        return RedirectToAction(nameof(Index));
    }
    // GET: ModeloController/Edit/5
    public ActionResult Edit(uint id)
    {
        return Details(id);
    }
    // POST: ModeloController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(uint id, ModeloViewModel modeloModel)
    {
        if (ModelState.IsValid)
        {
            var modelo = _mapper.Map<Modelo>(modeloModel);
            _modeloService.Edit(modelo);
        }
        return RedirectToAction(nameof(Index));
    }
    // GET: ModeloController/Delete/5
    public ActionResult Delete(uint id)
    {
        Modelo modelo = _modeloService.Get(id);
        ModeloViewModel modeloModel = _mapper.Map<ModeloViewModel>(modelo);
        return View(modeloModel);
    }
    // POST: ModeloController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(uint id, ModeloViewModel modeloModel)
    {
        _modeloService.Delete(id);
        return RedirectToAction(nameof(Index));
    }
}
