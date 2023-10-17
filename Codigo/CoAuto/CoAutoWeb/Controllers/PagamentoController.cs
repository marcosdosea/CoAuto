using AutoMapper;
using CoAutoWeb.Models;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoAutoWeb.Controllers;
[Authorize]
public class PagamentoController : Controller
{


    private readonly IPagamentoService _PagamentoService;
    private readonly IMapper _mapper;
    private readonly IAluguelService _aluguelService;

 

    public PagamentoController(IPagamentoService pagamentoService, IMapper mapper, IAluguelService aluguelService)
    {
        _PagamentoService = pagamentoService;
        _mapper = mapper;
        _aluguelService = aluguelService;
    }

    
    // GET: PagamentoController
    public ActionResult Index()
    {
        var listaPagamento = _PagamentoService.GetAll();
        var listaPagamentoModel = _mapper.Map<List<PagamentoViewModel>>(listaPagamento);
        return View(listaPagamentoModel);
    }

    // GET: PagamentoController/Details/5
    public ActionResult Details(uint id)
    {
        var pagamento = _PagamentoService.Get(id);
        var pagamentoModel = _mapper.Map<PagamentoViewModel>(pagamento);
        return View(pagamentoModel);
    }

    // GET: PagamentoController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: PagamentoController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(PagamentoViewModel pagamentoModel)
    {
        if (ModelState.IsValid)
        {
            var pagamento = _mapper.Map<Pagamento>(pagamentoModel);
            _PagamentoService.Create(pagamento);
        }
        return RedirectToAction(nameof(Index));
    }

    // GET: PagamentoController/Edit/5
    public ActionResult Edit(uint id)
    {
        Pagamento pagamento = _PagamentoService.Get(id);
        PagamentoViewModel pagamentoModel = _mapper.Map<PagamentoViewModel>(pagamento);
        return View(pagamentoModel);
    }

    // POST: PagamentoController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(uint id, PagamentoViewModel pagamentoModel)
    {
        if (ModelState.IsValid)
        {
            var pagamento = _mapper.Map<Pagamento>(pagamentoModel);
            _PagamentoService.Edit(pagamento);
        }
        return RedirectToAction(nameof(Index));
    }

    // GET: PagamentoController/Delete/5
    public ActionResult Delete(uint id)
    {
        Pagamento pagamento = _PagamentoService.Get(id);
        PagamentoViewModel pagamentoModel = _mapper.Map<PagamentoViewModel>(pagamento);
        return View(pagamentoModel);
    }

    // POST: PagamentoController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(uint id, PagamentoViewModel collection)
    {
        _PagamentoService.Delete(id);
        return RedirectToAction(nameof(Index));
    }
}
