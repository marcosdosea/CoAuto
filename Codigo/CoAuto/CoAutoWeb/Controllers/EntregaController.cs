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

public class EntregaController : Controller
{
    private readonly IEntregaService _entregaService;
    private readonly IMapper _mapper;
    public EntregaController(IEntregaService entregaService, IMapper mapper)
    {
        _entregaService = entregaService;
        _mapper = mapper;
    }

    /// <summary>
    /// Retorna todas as entregas da ViewModel
    /// </summary>
    /// <returns>View(entregas)</returns>
    public ActionResult Index()
    {
        var entregas = _entregaService.GetAll();
        var entregaModel = new List<EntregaViewModel>();
        foreach (Entrega entrega in entregas)
        {
            EntregaViewModel evm = new EntregaViewModel();
            evm.Id = entrega.Id;
            evm.DataHora = entrega.DataHora;
            evm.Foto1 = entrega.Foto1;
            evm.Foto2 = entrega.Foto2;
            evm.Foto3 = entrega.Foto3;
            evm.Foto4 = entrega.Foto4;
            evm.Foto5 = entrega.Foto5;
            entregaModel.Add(evm);
        }
        return View(entregaModel);
    }

    // GET: EntregaController/Details/5
    public ActionResult Details(uint id)
    {
        Entrega entrega = _entregaService.Get(id);
        EntregaViewModel entregaModel = new EntregaViewModel();
        entregaModel.Id = entrega.Id;
        entregaModel.DataHora = entrega.DataHora;
        entregaModel.Foto1 = entrega.Foto1;
        entregaModel.Foto2 = entrega.Foto2;
        entregaModel.Foto3 = entrega.Foto3;
        entregaModel.Foto4 = entrega.Foto4;
        entregaModel.Foto5 = entrega.Foto5;
        return View(entregaModel);
    }

    // GET: EntregaController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: EntregaController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(CreateEntregaViewModel entregaModel)
    {
        if (ModelState.IsValid)
        {
            Entrega entrega = new Entrega();

            if(entregaModel.Foto1 != null && entregaModel.Foto1.Length > 0)
            {
                var memoryStream = new MemoryStream();
                entregaModel.Foto1.CopyTo(memoryStream);
                var img = Image.FromStream(memoryStream);
                var jpgStream = new MemoryStream();
                img.Save(jpgStream, ImageFormat.Jpeg);
                entrega.Foto1 = jpgStream.ToArray();
            }

            if (entregaModel.Foto2 != null && entregaModel.Foto2.Length > 0)
            {
                var memoryStream = new MemoryStream();
                entregaModel.Foto2.CopyTo(memoryStream);
                var img = Image.FromStream(memoryStream);
                var jpgStream = new MemoryStream();
                img.Save(jpgStream, ImageFormat.Jpeg);
                entrega.Foto2 = jpgStream.ToArray();
            }

            if (entregaModel.Foto3 != null && entregaModel.Foto3.Length > 0)
            {
                var memoryStream = new MemoryStream();
                entregaModel.Foto3.CopyTo(memoryStream);
                var img = Image.FromStream(memoryStream);
                var jpgStream = new MemoryStream();
                img.Save(jpgStream, ImageFormat.Jpeg);
                entrega.Foto3 = jpgStream.ToArray();
            }

            if (entregaModel.Foto4 != null && entregaModel.Foto4.Length > 0)
            {
                var memoryStream = new MemoryStream();
                entregaModel.Foto4.CopyTo(memoryStream);
                var img = Image.FromStream(memoryStream);
                var jpgStream = new MemoryStream();
                img.Save(jpgStream, ImageFormat.Jpeg);
                entrega.Foto4 = jpgStream.ToArray();
            }

            if (entregaModel.Foto5 != null && entregaModel.Foto5.Length > 0)
            {
                var memoryStream = new MemoryStream();
                entregaModel.Foto5.CopyTo(memoryStream);
                var img = Image.FromStream(memoryStream);
                var jpgStream = new MemoryStream();
                img.Save(jpgStream, ImageFormat.Jpeg);
                entrega.Foto5 = jpgStream.ToArray();
            }
            // TODO: vincular entrega a um aluguel
            entrega.DataHora = entregaModel.DataHora;

            _entregaService.Create(entrega);
        }
        return RedirectToAction(nameof(Index));
    }

    // GET: EntregaController/Edit/5
    public ActionResult Edit(uint id)
    {
        var entrega = _entregaService.Get(id);
        UpdateEntregaViewModel updateEntregaViewModel = new UpdateEntregaViewModel();
        updateEntregaViewModel.Id = entrega.Id;
        updateEntregaViewModel.DataHora = entrega.DataHora;
        updateEntregaViewModel.Foto1 = entrega.Foto1;
        updateEntregaViewModel.Foto2 = entrega.Foto2;
        updateEntregaViewModel.Foto3 = entrega.Foto3;
        updateEntregaViewModel.Foto4 = entrega.Foto4;
        updateEntregaViewModel.Foto5 = entrega.Foto5;
        return View(updateEntregaViewModel);
    }

    // POST: EntregaController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(uint id, UpdateEntregaViewModel updateEntregaViewModel)
    {
        if (ModelState.IsValid)
        {
            var entrega = _entregaService.Get(id);
            entrega.Id = updateEntregaViewModel.Id;
            entrega.DataHora = updateEntregaViewModel.DataHora;

            if (updateEntregaViewModel.FormFoto1 != null && updateEntregaViewModel.FormFoto1.Length > 0)
            {
                var memoryStream = new MemoryStream();
                updateEntregaViewModel.FormFoto1.CopyTo(memoryStream);
                var img = Image.FromStream(memoryStream);
                var jpgStream = new MemoryStream();
                img.Save(jpgStream, ImageFormat.Jpeg);
                entrega.Foto1 = jpgStream.ToArray();
            }

            if (updateEntregaViewModel.FormFoto2 != null && updateEntregaViewModel.FormFoto2.Length > 0)
            {
                var memoryStream = new MemoryStream();
                updateEntregaViewModel.FormFoto2.CopyTo(memoryStream);
                var img = Image.FromStream(memoryStream);
                var jpgStream = new MemoryStream();
                img.Save(jpgStream, ImageFormat.Jpeg);
                entrega.Foto2 = jpgStream.ToArray();
            }

            if (updateEntregaViewModel.FormFoto3 != null && updateEntregaViewModel.FormFoto3.Length > 0)
            {
                var memoryStream = new MemoryStream();
                updateEntregaViewModel.FormFoto3.CopyTo(memoryStream);
                var img = Image.FromStream(memoryStream);
                var jpgStream = new MemoryStream();
                img.Save(jpgStream, ImageFormat.Jpeg);
                entrega.Foto3 = jpgStream.ToArray();
            }

            if (updateEntregaViewModel.FormFoto4 != null && updateEntregaViewModel.FormFoto4.Length > 0)
            {
                var memoryStream = new MemoryStream();
                updateEntregaViewModel.FormFoto4.CopyTo(memoryStream);
                var img = Image.FromStream(memoryStream);
                var jpgStream = new MemoryStream();
                img.Save(jpgStream, ImageFormat.Jpeg);
                entrega.Foto4 = jpgStream.ToArray();
            }

            if (updateEntregaViewModel.FormFoto5 != null && updateEntregaViewModel.FormFoto5.Length > 0)
            {
                var memoryStream = new MemoryStream();
                updateEntregaViewModel.FormFoto5.CopyTo(memoryStream);
                var img = Image.FromStream(memoryStream);
                var jpgStream = new MemoryStream();
                img.Save(jpgStream, ImageFormat.Jpeg);
                entrega.Foto5 = jpgStream.ToArray();
            }
            _entregaService.Edit(entrega);
        }
        return RedirectToAction(nameof(Index));
    }

    // GET: EntregaController/Delete/5
    public ActionResult Delete(uint id)
    {
        Entrega entrega = _entregaService.Get(id);
        EntregaViewModel entregaModel = _mapper.Map<EntregaViewModel>(entrega);
        return View(entregaModel);
    }

    // POST: EntregaController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(uint id, EntregaViewModel entregaModel)
    {
        _entregaService.Delete(id);
        return RedirectToAction(nameof(Index));
    }
}
