using AutoMapper;
using CoAutoWeb.Models;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Service;
using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace CoAutoWeb.Controllers;

public class DevolucaoController : Controller
{
    private readonly IDevolucaoService _devolucaoService;
    private readonly IMapper _mapper;
    public DevolucaoController(IDevolucaoService devolucaoService, IMapper mapper)
    {
        _devolucaoService = devolucaoService;
        _mapper = mapper;
    }

    /// <summary>
    /// Retorna todas as devoluções da ViewModel
    /// </summary>
    /// <returns>View(devoluções)</returns>
    public ActionResult Index()
    {
        var devolucoes = _devolucaoService.GetAll();
        var devolucaoModel = new List<DevolucaoViewModel>();
        foreach (Devolucao devolucao in devolucoes)
        {
            DevolucaoViewModel evm = new DevolucaoViewModel();
            evm.Id = devolucao.Id;
            evm.DataHora = devolucao.DataHora;
            evm.Foto1 = devolucao.Foto1;
            evm.Foto2 = devolucao.Foto2;
            evm.Foto3 = devolucao.Foto3;
            evm.Foto4 = devolucao.Foto4;
            evm.Foto5 = devolucao.Foto5;
            devolucaoModel.Add(evm);
        }
        return View(devolucaoModel);
    }

    // GET: DevolucaoController/Details/5
    public ActionResult Details(uint? id)
    {
        Devolucao devolucao = _devolucaoService.Get((uint)id);
        DevolucaoViewModel devolucaoModel = new DevolucaoViewModel();
        devolucaoModel.Id = devolucao.Id;
        devolucaoModel.DataHora = devolucao.DataHora;
        devolucaoModel.Foto1 = devolucao.Foto1;
        devolucaoModel.Foto2 = devolucao.Foto2;
        devolucaoModel.Foto3 = devolucao.Foto3;
        devolucaoModel.Foto4 = devolucao.Foto4;
        devolucaoModel.Foto5 = devolucao.Foto5;
        return View(devolucaoModel);
    }

    // GET: DevolucaoController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: DevolucaoController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(CreateDevolucaoViewModel devolucaoModel)
    {
        if (ModelState.IsValid)
        {
            Devolucao devolucao = new Devolucao();

            if (devolucaoModel.Foto1 != null && devolucaoModel.Foto1.Length > 0)
            {
                var memoryStream = new MemoryStream();
                devolucaoModel.Foto1.CopyTo(memoryStream);
                var img = Image.FromStream(memoryStream);
                var jpgStream = new MemoryStream();
                img.Save(jpgStream, ImageFormat.Jpeg);
                devolucao.Foto1 = jpgStream.ToArray();
            }

            if (devolucaoModel.Foto2 != null && devolucaoModel.Foto2.Length > 0)
            {
                var memoryStream = new MemoryStream();
                devolucaoModel.Foto2.CopyTo(memoryStream);
                var img = Image.FromStream(memoryStream);
                var jpgStream = new MemoryStream();
                img.Save(jpgStream, ImageFormat.Jpeg);
                devolucao.Foto2 = jpgStream.ToArray();
            }

            if (devolucaoModel.Foto3 != null && devolucaoModel.Foto3.Length > 0)
            {
                var memoryStream = new MemoryStream();
                devolucaoModel.Foto3.CopyTo(memoryStream);
                var img = Image.FromStream(memoryStream);
                var jpgStream = new MemoryStream();
                img.Save(jpgStream, ImageFormat.Jpeg);
                devolucao.Foto3 = jpgStream.ToArray();
            }

            if (devolucaoModel.Foto4 != null && devolucaoModel.Foto4.Length > 0)
            {
                var memoryStream = new MemoryStream();
                devolucaoModel.Foto4.CopyTo(memoryStream);
                var img = Image.FromStream(memoryStream);
                var jpgStream = new MemoryStream();
                img.Save(jpgStream, ImageFormat.Jpeg);
                devolucao.Foto4 = jpgStream.ToArray();
            }

            if (devolucaoModel.Foto5 != null && devolucaoModel.Foto5.Length > 0)
            {
                var memoryStream = new MemoryStream();
                devolucaoModel.Foto5.CopyTo(memoryStream);
                var img = Image.FromStream(memoryStream);
                var jpgStream = new MemoryStream();
                img.Save(jpgStream, ImageFormat.Jpeg);
                devolucao.Foto5 = jpgStream.ToArray();
            }
            // TODO: vincular devolucao a um aluguel
            devolucao.DataHora = devolucaoModel.DataHora;

            _devolucaoService.Create(devolucao);
        }
        return RedirectToAction(nameof(Index));
    }

    // GET: DevolucaoController/Edit/5
    public ActionResult Edit(uint id)
    {
        var devolucao = _devolucaoService.Get(id);
        UpdateDevolucaoViewModel updateDevolucaoViewModel = new UpdateDevolucaoViewModel();
        updateDevolucaoViewModel.Id = devolucao.Id;
        updateDevolucaoViewModel.DataHora = devolucao.DataHora;
        updateDevolucaoViewModel.Foto1 = devolucao.Foto1;
        updateDevolucaoViewModel.Foto2 = devolucao.Foto2;
        updateDevolucaoViewModel.Foto3 = devolucao.Foto3;
        updateDevolucaoViewModel.Foto4 = devolucao.Foto4;
        updateDevolucaoViewModel.Foto5 = devolucao.Foto5;
        return View(updateDevolucaoViewModel);
    }

    // POST: DevolucaoController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(uint id, UpdateDevolucaoViewModel updateDevolucaoViewModel)
    {
        if (ModelState.IsValid)
        {
            var devolucao = _devolucaoService.Get(id);
            devolucao.Id = updateDevolucaoViewModel.Id;
            devolucao.DataHora = updateDevolucaoViewModel.DataHora;

            if (updateDevolucaoViewModel.Foto1 != null && updateDevolucaoViewModel.Foto1.Length > 0)
            {
                var memoryStream = new MemoryStream();
                updateDevolucaoViewModel.FormFoto1.CopyTo(memoryStream);
                var img = Image.FromStream(memoryStream);
                var jpgStream = new MemoryStream();
                img.Save(jpgStream, ImageFormat.Jpeg);
                devolucao.Foto1 = jpgStream.ToArray();
            }

            if (updateDevolucaoViewModel.Foto2 != null && updateDevolucaoViewModel.Foto2.Length > 0)
            {
                var memoryStream = new MemoryStream();
                updateDevolucaoViewModel.FormFoto2.CopyTo(memoryStream);
                var img = Image.FromStream(memoryStream);
                var jpgStream = new MemoryStream();
                img.Save(jpgStream, ImageFormat.Jpeg);
                devolucao.Foto2 = jpgStream.ToArray();
            }

            if (updateDevolucaoViewModel.Foto3 != null && updateDevolucaoViewModel.Foto3.Length > 0)
            {
                var memoryStream = new MemoryStream();
                updateDevolucaoViewModel.FormFoto3.CopyTo(memoryStream);
                var img = Image.FromStream(memoryStream);
                var jpgStream = new MemoryStream();
                img.Save(jpgStream, ImageFormat.Jpeg);
                devolucao.Foto3 = jpgStream.ToArray();
            }

            if (updateDevolucaoViewModel.Foto4 != null && updateDevolucaoViewModel.Foto4.Length > 0)
            {
                var memoryStream = new MemoryStream();
                updateDevolucaoViewModel.FormFoto4.CopyTo(memoryStream);
                var img = Image.FromStream(memoryStream);
                var jpgStream = new MemoryStream();
                img.Save(jpgStream, ImageFormat.Jpeg);
                devolucao.Foto4 = jpgStream.ToArray();
            }

            if (updateDevolucaoViewModel.Foto5 != null && updateDevolucaoViewModel.Foto5.Length > 0)
            {
                var memoryStream = new MemoryStream();
                updateDevolucaoViewModel.FormFoto5.CopyTo(memoryStream);
                var img = Image.FromStream(memoryStream);
                var jpgStream = new MemoryStream();
                img.Save(jpgStream, ImageFormat.Jpeg);
                devolucao.Foto5 = jpgStream.ToArray();
            }
            // TODO: vincular devolucao a um aluguel
            devolucao.DataHora = updateDevolucaoViewModel.DataHora;

            _devolucaoService.Create(devolucao);
        }
        return RedirectToAction(nameof(Index));
    }

    // GET: DevolucaoController/Delete/5
    public ActionResult Delete(uint? id)
    {
        Devolucao devolucao = _devolucaoService.Get((uint)id);
        DevolucaoViewModel devolucaoModel = _mapper.Map<DevolucaoViewModel>(devolucao);
        return View(devolucaoModel);
    }

    // POST: DevolucaoController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(uint id)
    {
        _devolucaoService.Delete(id);
        return RedirectToAction(nameof(Index));
    }
}
