using AutoMapper;
using CoAutoWeb.Models;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace CoAutoWeb.Controllers;
public class AluguelController : Controller
{
    private readonly IAluguelService _aluguelService;
    private readonly IMapper _mapper;
    public AluguelController(IAluguelService aluguelService, IMapper mapper)
    {
        _aluguelService = aluguelService;
        _mapper = mapper;
    }
    // GET: AluguelController
    public ActionResult Index()
    {
        var listaAluguels = _aluguelService.GetAll();
        var listaAluguelsModel = _mapper.Map<List<AluguelViewModel>>(listaAluguels);
        return View(listaAluguelsModel);
    }
    // GET: AluguelController/Details/5
    public ActionResult Details(uint id)
    {
        Aluguel aluguel = _aluguelService.Get(id);
        AluguelViewModel aluguelModel = _mapper.Map<AluguelViewModel>(aluguel);
        return View(aluguelModel);
    }
    // GET: AluguelController/Create
    public ActionResult Create()
    {
        return View();
    }
    // POST: AluguelController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(AluguelViewModel aluguelModel)
    {
        if (ModelState.IsValid)
        {
            var aluguel = _mapper.Map<Aluguel>(aluguelModel);
            _aluguelService.Create(aluguel);
        }
        return RedirectToAction(nameof(Index));
    }
    // GET: AluguelController/Edit/5
    public ActionResult Edit(uint id)
    {
        return Details(id);
    }
    // POST: AluguelController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(uint id, AluguelViewModel aluguelModel)
    {
        if (ModelState.IsValid)
        {
            var aluguel = _mapper.Map<Aluguel>(aluguelModel);
            _aluguelService.Edit(aluguel);
        }
        return RedirectToAction(nameof(Index));
    }
    // GET: AluguelController/Delete/5
    public ActionResult Delete(uint id)
    {
        Aluguel aluguel = _aluguelService.Get(id);
        AluguelViewModel aluguelModel = _mapper.Map<AluguelViewModel>(aluguel);
        return View(aluguelModel);
    }
    // POST: AluguelController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(uint id, AluguelViewModel aluguelModel)
    {
        _aluguelService.Delete(id);
        return RedirectToAction(nameof(Index));
    }
}
