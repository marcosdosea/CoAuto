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

    /// <summary>
    /// Retorna todos os Aluguel da ViewModel
    /// </summary>
    /// <returns>View(Aluguel)</returns>
    public async Task<ActionResult> Index()
    {
        var aluguels = await _aluguelService.GetAll();

        if (aluguels == null) return BadRequest();

        var aluguelModel = _mapper.Map<List<AluguelViewModel>>(aluguels);

        return View(aluguelModel);
    }

    // GET: AluguelController/Details/5
    [HttpGet]
    public async Task<ActionResult> Details(int id)
    {
        var aluguel = await _aluguelService.Get(id);

        if (aluguel == null) return BadRequest();

        var aluguelModel = _mapper.Map<AluguelViewModel>(aluguel);

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
    public async Task<ActionResult> Create(AluguelViewModel aluguelModel)
    {

        if (ModelState.IsValid)
        {
            try
            {
                var aluguel = _mapper.Map<Aluguel>(aluguelModel);
                await _aluguelService.Create(aluguel);
            }
            catch
            {
                return View(aluguelModel);
            }

            return RedirectToAction(nameof(Index));
        }

        return View(aluguelModel);

    }

    // GET: AluguelController/Edit/5
    [HttpGet]
    public async Task<ActionResult> Edit(int id)
    {
        var aluguel = await _aluguelService.Get(id);

        var aluguelModel = _mapper.Map<MarcaViewModel>(aluguel);

        return View(aluguelModel);
    }

    // POST: AluguelController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(int id, AluguelViewModel aluguelModel)
    {
        if (id != aluguelModel.Id) return NotFound();


        if (ModelState.IsValid)
        {
            try
            {
                var aluguel = _mapper.Map<Aluguel>(aluguelModel);
                await _aluguelService.Edit(aluguel);
            }
            catch
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }

        return View(aluguelModel);

    }

    // GET: AluguelController/Delete/5
    [HttpGet]
    public async Task<ActionResult> Delete(int? id)
    {
        if (id == null) return BadRequest();

        var aluguel = await _aluguelService.Get((int)id);

        if (aluguel == null) return NotFound();

        var aluguelModel = _mapper.Map<MarcaViewModel>(aluguel);

        return View(aluguelModel);
    }

    // POST: AluguelController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Delete(int id)
    {
        await _aluguelService.Delete(id);

        return RedirectToAction(nameof(Index));
    }
}
