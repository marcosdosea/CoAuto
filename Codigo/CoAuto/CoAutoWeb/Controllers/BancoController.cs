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
    // GET: BancoController
    public ActionResult Index()
    {
        var listaBancos = _bancoService.GetAll();
        var listaBancosModel = _mapper.Map<List<BancoViewModel>>(listaBancos);
        return View(listaBancosModel);
    }
    // GET: BancoController/Details/5
    public ActionResult Details(uint id)
    {
        Banco banco = _bancoService.Get(id);
        BancoViewModel bancoModel = _mapper.Map<BancoViewModel>(banco);
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
    public ActionResult Create(BancoViewModel bancoModel)
    {
        if (ModelState.IsValid)
        {
            var banco = _mapper.Map<Banco>(bancoModel);
            _bancoService.Create(banco);
        }
        return RedirectToAction(nameof(Index));
    }
    // GET: BancoController/Edit/5
    public ActionResult Edit(uint id)
    {
        return Details(id);
    }
    // POST: BancoController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(uint id, BancoViewModel bancoModel)
    {
        if (ModelState.IsValid)
        {
            var banco = _mapper.Map<Banco>(bancoModel);
            _bancoService.Edit(banco);
        }
        return RedirectToAction(nameof(Index));
    }
    // GET: BancoController/Delete/5
    public ActionResult Delete(uint id)
    {
        Banco banco = _bancoService.Get(id);
        BancoViewModel bancoModel = _mapper.Map<BancoViewModel>(banco);
        return View(bancoModel);
    }
    // POST: BancoController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(uint id, BancoViewModel bancoModel)
    {
        _bancoService.Delete(id);
        return RedirectToAction(nameof(Index));
    }
}
