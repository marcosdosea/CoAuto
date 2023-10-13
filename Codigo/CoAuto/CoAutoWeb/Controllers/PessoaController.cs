using AutoMapper;
using CoAutoWeb.Models;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace CoAutoWeb.Controllers;

public class PessoaController : Controller
{
    private readonly IPessoaService _pessoaService;
    private readonly IMapper _mapper;

    public PessoaController(IPessoaService pessoaService, IMapper mapper)
    {
        _pessoaService = pessoaService;
        _mapper = mapper;
    }

    // GET: PessoaController
    public ActionResult Index()
    {
        var listaPessoas = _pessoaService.GetAll();
        var listaPessoasModel = _mapper.Map<List<PessoaViewModel>>(listaPessoas);
        return View(listaPessoasModel);
    }

    // GET: PessoaController/Details/5
    public ActionResult Details(uint id)
    {
        Pessoa pessoa = _pessoaService.Get(id);
        PessoaViewModel pessoaModel = _mapper.Map<PessoaViewModel>(pessoa);
        return View(pessoaModel);
    }

    // GET: PessoaController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: PessoaController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(PessoaViewModel pessoaModel)
    {
        if (ModelState.IsValid)
        {
            var pessoa = _mapper.Map<Pessoa>(pessoaModel);
            _pessoaService.Create(pessoa);
        }
        return RedirectToAction(nameof(Index));
    }

    // GET: PessoaController/Edit/5
    public ActionResult Edit(uint id)
    {
        return Details(id);
    }

    // POST: PessoaController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(uint id, PessoaViewModel pessoaModel)
    {
        if (ModelState.IsValid)
        {
            var pessoa = _mapper.Map<Pessoa>(pessoaModel);
            _pessoaService.Edit(pessoa);
        }
        return RedirectToAction(nameof(Index));
    }

    // GET: PessoaController/Delete/5
    public ActionResult Delete(uint id)
    {
        Pessoa pessoa = _pessoaService.Get(id);
        PessoaViewModel pessoaModel = _mapper.Map<PessoaViewModel>(pessoa);
        return View(pessoaModel);
    }

    // POST: PessoaController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(uint id, PessoaViewModel pessoaModel)
    {
        _pessoaService.Delete(id);
        return RedirectToAction(nameof(Index));
    }

    //GET: PessoaControler/Perfil
    public ActionResult Perfil(uint id)
    {
        Pessoa pessoa = _pessoaService.Get(id);
        PessoaViewModel pessoaModel = _mapper.Map<PessoaViewModel>(pessoa);
        return View(pessoaModel);
    } 
}
