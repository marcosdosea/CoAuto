﻿using AutoMapper;
using CoAutoWeb.Models;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace CoAutoWeb.Controllers;

public class DisponibilidadeController : Controller
{
    private readonly IDisponibilidadeService _disponibilidadeService;
    private readonly IMapper _mapper;

    public DisponibilidadeController(IDisponibilidadeService disponibilidadeService, IMapper mapper)
    {
        _disponibilidadeService = disponibilidadeService;
        _mapper = mapper;
    }

    // GET: DisponibilidadeController
    public ActionResult Index()
    {
        var listaDisponibilidades = _disponibilidadeService.GetAll();
        var listaDisponibilidadeModel = _mapper.Map<List<DisponibilidadeModel>>(listaDisponibilidades);
        return View(listaDisponibilidadeModel);
    }

    // GET: DisponibilidadeController/Details/5
    public ActionResult Details(uint id)
    {
        var disponibilidade = _disponibilidadeService.Get(id);
        var disponibilidadeModel = _mapper.Map<DisponibilidadeModel>(disponibilidade);
        return View(disponibilidadeModel);
    }

    // GET: DisponibilidadeController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: DisponibilidadeController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(DisponibilidadeModel disponibilidadeModel)
    {
        if (ModelState.IsValid)
        {
            var disponibilidade = _mapper.Map<Disponibilidade>(disponibilidadeModel);
            _disponibilidadeService.Create(disponibilidade);
        }
        return RedirectToAction(nameof(Index));
    }

    // GET: DisponibilidadeController/Edit/5
    public ActionResult Edit(uint id)
    {
        Disponibilidade disponibilidade = _disponibilidadeService.Get(id);
        DisponibilidadeModel disponibilidadeModel = _mapper.Map<DisponibilidadeModel>(disponibilidade);
        return View(disponibilidadeModel);
    }

    // POST: DisponibilidadeController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(uint id, DisponibilidadeModel disponibilidadeModel)
    {
        if (ModelState.IsValid)
        {
            var disponibilidade = _mapper.Map<Disponibilidade>(disponibilidadeModel);
            _disponibilidadeService.Edit(disponibilidade);
        }
        return RedirectToAction(nameof(Index));
    }

    // GET: DisponibilidadeController/Delete/5
    public ActionResult Delete(uint id)
    {
        Disponibilidade disponibilidade = _disponibilidadeService.Get(id);
        DisponibilidadeModel disponibilidadeModel = _mapper.Map<DisponibilidadeModel>(disponibilidade);
        return View(disponibilidadeModel);
    }

    // POST: DisponibilidadeController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(uint id, IFormCollection collection)
    {
        _disponibilidadeService.Delete(id);
        return RedirectToAction(nameof(Index));
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(uint id, DisponibilidadeModel disponibilidadeModel)
    {
        _disponibilidadeService.Delete(id);
        return RedirectToAction(nameof(Index));
    }
}
