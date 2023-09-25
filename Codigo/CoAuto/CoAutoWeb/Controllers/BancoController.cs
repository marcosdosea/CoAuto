using AutoMapper;
using CoAutoWeb.Models;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace CoAutoWeb.Controllers;

public class BancoController : Controller
{
    private readonly IBancoService _bancoService;
    private readonly IMapper _mapper;
    public BancoController(IBancoService bancoService, IMapper mapper)
    {
        _bancoService = bancoService;
        _mapper = mapper;
    }

    /// <summary>
    /// Retorna todas os bancos da ViewModel
    /// </summary>
    /// <returns>View(bancos)</returns>
    public async Task<ActionResult> Index()
    {
        var bancos = await _bancoService.GetAll();

        if (bancos == null) return BadRequest();

        var bancoModel = _mapper.Map<List<BancoViewModel>>(bancos);
        return View(bancoModel);
    }

    // GET: BancoController/Details/5
    [HttpGet]
    public async Task<ActionResult> Details(uint id)
    {
        var banco = await _bancoService.Get(id);

        if (banco == null) return BadRequest();

        var bancoModel = _mapper.Map<BancoViewModel>(banco);

        return View(bancoModel);
    }

    // GET: BancoController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: BancoController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(BancoViewModel bancoModel)
    {

        if (ModelState.IsValid)
        {
            try
            {
                var banco = _mapper.Map<Banco>(bancoModel);
                await _bancoService.Create(banco);
            }
            catch
            {
                return View(bancoModel);
            }

            return RedirectToAction(nameof(Index));
        }

        return View(bancoModel);

    }

    // GET: BancoController/Edit/5
    [HttpGet]
    public async Task<ActionResult> Edit(uint id)
    {
        var banco = await _bancoService.Get(id);

        var bancoModel = _mapper.Map<BancoViewModel>(banco);

        return View(bancoModel);
    }

    // POST: BancoController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(uint id, BancoViewModel bancoModel)
    {
        if (id != bancoModel.Id) return NotFound();


        if (ModelState.IsValid)
        {
            try
            {
                var banco = _mapper.Map<Banco>(bancoModel);
                await _bancoService.Edit(banco);
            }
            catch
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }

        return View(bancoModel);

    }

    // GET: BancoController/Delete/5
    [HttpGet]
    public async Task<ActionResult> Delete(uint? id)
    {
        if (id == null) return BadRequest();

        var banco = await _bancoService.Get((uint)id);

        if (banco == null) return NotFound();

        var bancoModel = _mapper.Map<BancoViewModel>(banco);

        return View(bancoModel);
    }

    // POST: BancoController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Delete(uint id)
    {
        await _bancoService.Delete(id);

        return RedirectToAction(nameof(Index));
    }
}
